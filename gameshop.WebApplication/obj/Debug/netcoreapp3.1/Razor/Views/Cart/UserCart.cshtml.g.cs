#pragma checksum "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ed5824045e725d6e863d88df8b83c43fae93174"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_UserCart), @"mvc.1.0.view", @"/Views/Cart/UserCart.cshtml")]
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
#line 1 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\_ViewImports.cshtml"
using gameshop.WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\_ViewImports.cshtml"
using gameshop.WebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ed5824045e725d6e863d88df8b83c43fae93174", @"/Views/Cart/UserCart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c080b26fe0577ed42d50670c81b4fb74fa9dc44", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_UserCart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<gameshop.WebApplication.Models.CartVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
  
    ViewData["Title"] = "UserCart";
    List<OrderVM> orders = (List<OrderVM>)ViewData["orders"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>UserCart</h1>\r\n\r\n<!--\r\n<div>\r\n    <h4>CartVM</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 16 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 19 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 22 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 25 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 28 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
       Write(Html.DisplayNameFor(model => model.CreateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 31 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
       Write(Html.DisplayFor(model => model.CreateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 34 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
       Write(Html.DisplayNameFor(model => model.LastChange));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 37 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
       Write(Html.DisplayFor(model => model.LastChange));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 40 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
       Write(Html.DisplayNameFor(model => model.UserID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 43 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
       Write(Html.DisplayFor(model => model.UserID));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd>
    </dl>
</div>-->
<div class=""shopping-cart section"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12"">
                <!-- Shopping Summery -->
                <table class=""table shopping-summery"">
                    <thead>
                        <tr class=""main-hading"">
                            <th>PRODUCT</th>
                            <th>NAME</th>
                            <th class=""text-center"">Platform</th>
                            <th class=""text-center"">Amount</th>
                            <th class=""text-center""><i class=""ti-trash remove-icon""></i></th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 63 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
                         if (orders != null)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
                             foreach (OrderVM order in orders)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
                           Write(await Html.PartialAsync("~/Views/Order/OrderRowTable.cshtml", order));

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
                                                                                                     ;
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
                <!--/ End Shopping Summery -->
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-12"">
        <!-- Total Amount -->
        <div class=""total-amount"">
            <div class=""row"">
                <div class=""col-lg-8 col-md-5 col-12""></div>
                <div class=""col-lg-4 col-md-7 col-12"">
                    <div class=""right"">
                        <ul>
                            <li>User <span>");
#nullable restore
#line 86 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
                                      Write(Model.UserID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                            <li>Created <span>");
#nullable restore
#line 87 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
                                         Write(Model.CreateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                            <li>Last Change <span>");
#nullable restore
#line 88 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Cart\UserCart.cshtml"
                                             Write(Model.LastChange);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></li>
                        </ul>
                        <div class=""button5"">
                            <a href=""#"" class=""btn"">Checkout</a>
                            <a href=""#"" class=""btn"">Empty Cart</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/ End Total Amount -->
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<gameshop.WebApplication.Models.CartVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
