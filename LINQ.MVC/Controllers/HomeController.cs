using LINQ.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace LINQ.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext _context;


        public HomeController(ILogger<HomeController> logger, NorthwindContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult CustomerCountPerCountry()
        {
            var s = _context.Customers.GroupBy(g => new { g.Country }).Select(s => new { Ulke = s.Key.Country, MusteriSayisi = s.Count() }).OrderByDescending(o => o.MusteriSayisi);
            var numbersPerCountries = from customer in _context.Customers
                                      group customer by customer.Country into g
                                      orderby g.Count() descending
                                      select new { Ulke = g.Key, MusteriSayisi = g.Count() };
            return Json(new { sql = numbersPerCountries.ToQueryString().Replace("\r\n", " "), result = s });

        }
        public JsonResult InnerJoin()
        {
            var linq = from order in _context.Orders
                       join orderDetail in _context.OrderDetails on order.OrderId equals orderDetail.OrderId
                       select new
                       {
                           OrderId = order.OrderId,
                           unitPrice = orderDetail.UnitPrice
                       };
            var lambda = _context.Orders.Join(_context.OrderDetails
                , od => od.OrderId, o => o.OrderId, (o, od) => new { o.OrderId, od.UnitPrice }).Select(s => s);
            return Json(new { sql = linq.ToQueryString().Replace("\r\n", " "), result = linq });
        }

        /// <summary>
        /// Sum aggregate fonksiyonu ile her siparişin toplam miktarını getirme
        /// </summary>
        /// <returns></returns>
        public JsonResult AggregateFunction()
        {
            var linq = from orderDetail in _context.OrderDetails
                       join order in _context.Orders on orderDetail.OrderId equals order.OrderId
                       group orderDetail by new
                       {
                           orderDetail.OrderId
                           //,order.OrderDate
                       }
                         into grp
                       orderby grp.Key.OrderId
                       select new
                       {
                           SiparisNo = grp.Key.OrderId,
                           ToplamTutar = grp.Sum(s => (s.UnitPrice * s.Quantity))
                       };

            return Json(new { sql = linq.ToQueryString().Replace("\r\n", " "), result = linq });

        }

        public JsonResult GroupJoin()
        {
            var linq = (from order in _context.Orders.ToList()
                        join orderDetail in _context.OrderDetails.ToList()
                        on order.OrderId equals orderDetail.OrderId
                        into grp
                        select new
                        {
                            Siparis = order,
                            Detay = grp
                        }).Take(1).ToList();
            var lambda = _context.Orders.ToList().GroupJoin(_context.OrderDetails.ToList(), od => od.OrderId, o => o.OrderId,
                 (o, od) => new { Siparis = o, Detay = od }).Select(s => s);

            return Json(new { sql = "", result = lambda });

        }

        public JsonResult MostExpensiveProductsPerCategory()
        {

            var categories = from order in _context.Orders
                             group order by order.CustomerId into orders
                             join customer in _context.Customers on orders.Key equals customer.CustomerId
                             select new
                             {
                                 CustomerId = orders.Key,
                                 CompanyName = customer.CompanyName,
                                 Count = orders.Count()
                             };

            return Json(new { sql = categories.ToQueryString().Replace("\r\n", " "), result = categories });
        }

        public JsonResult CategoriesAndProducts()
        {

            var linq = from c in _context.Categories
                       join p in _context.Products on c.CategoryId equals p.CategoryId into ps
                       from p in ps.DefaultIfEmpty()

                       select new
                       {
                           CategoryName = c.CategoryName,
                           ProductName = p.ProductName
                       };

            var lambda = _context.Categories
                .GroupJoin(_context.Products
                , c => c.CategoryId
                , p => p.CategoryId
                ,(x, y) => new { CategoryName = x.CategoryName, ProductName = y })
                .SelectMany(x => x.ProductName.DefaultIfEmpty(), (x, y) => new { CategoryName = x.CategoryName, ProductName = y.ProductName });

            return Json(new { sql = linq.ToQueryString().Replace("\r\n", " "), result = lambda });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
