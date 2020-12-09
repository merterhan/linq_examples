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
            var numbersPerCountries = from customer in _context.Customers
                                      group customer by customer.Country into g
                                      orderby g.Count() descending
                                      select new { Ulke = g.Key, MusteriSayisi = g.Count() };
            return Json(new { sql = numbersPerCountries.ToQueryString().Replace("\r\n", " "), result = numbersPerCountries });

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
                        }).ToList();

            return Json(new { sql = "", result = linq });

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
