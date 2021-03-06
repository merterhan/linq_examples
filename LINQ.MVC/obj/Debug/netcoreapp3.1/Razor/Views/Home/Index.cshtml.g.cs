#pragma checksum "D:\Development\linq_examples\LINQ.MVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd2b8a6d51b04b238e64d1b9602567320e15903f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Development\linq_examples\LINQ.MVC\Views\_ViewImports.cshtml"
using LINQ.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Development\linq_examples\LINQ.MVC\Views\_ViewImports.cshtml"
using LINQ.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd2b8a6d51b04b238e64d1b9602567320e15903f", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37d680b2d70f5bafcb86852a1424cf92f608edba", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Development\linq_examples\LINQ.MVC\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    a {
        margin-bottom: 1%;
    }
</style>

<div class=""text-center"">
    <h1 class=""display-4"">Northwind Veri Tabanı ile LINQ Örnekleri</h1>
    <p>Daha fazlası için <a target=""_blank"" href=""https://cagrierhan.com"">Tıklayın</a></p>
</div>

<a");
            BeginWriteAttribute("href", " href=\"", 318, "\"", 371, 1);
#nullable restore
#line 17 "D:\Development\linq_examples\LINQ.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 325, Url.Action("CustomerCountPerCountry", "Home"), 325, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">(GROUP BY) Ülkelere Göre Müşteri Sayıları</a>\r\n<br />\r\n\r\n<a");
            BeginWriteAttribute("href", " href=\"", 456, "\"", 495, 1);
#nullable restore
#line 20 "D:\Development\linq_examples\LINQ.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 463, Url.Action("InnerJoin", "Home"), 463, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">(GROUP BY) Siperiş Id ve Tutarı</a>\r\n\r\n<br />\r\n<a");
            BeginWriteAttribute("href", " href=\"", 570, "\"", 632, 1);
#nullable restore
#line 23 "D:\Development\linq_examples\LINQ.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 577, Url.Action("MostExpensiveProductsPerCategory", "Home"), 577, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary disabled\">(GROUP BY) MostExpensiveProductsPerCategory</a>\r\n<br />\r\n<a");
            BeginWriteAttribute("href", " href=\"", 726, "\"", 773, 1);
#nullable restore
#line 25 "D:\Development\linq_examples\LINQ.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 733, Url.Action("AggregateFunction", "Home"), 733, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Sum aggregate fonksiyonu ile her siparişin toplam tutarını getirme</a>\r\n<br />\r\n<a");
            BeginWriteAttribute("href", " href=\"", 881, "\"", 920, 1);
#nullable restore
#line 27 "D:\Development\linq_examples\LINQ.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 888, Url.Action("GroupJoin", "Home"), 888, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">(GROUP JOIN) Sipariş ve Detayları</a>\r\n<br />\r\n<a");
            BeginWriteAttribute("href", " href=\"", 995, "\"", 1046, 1);
#nullable restore
#line 29 "D:\Development\linq_examples\LINQ.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 1002, Url.Action("CategoriesAndProducts", "Home"), 1002, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">(LEFT JOIN) Kategorilerine göre ürünler</a>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
