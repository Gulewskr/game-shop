#pragma checksum "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Partial\SingleGameMainBanner.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb32f298013e000367cd70e0136bf99c8348a1d3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Partial_SingleGameMainBanner), @"mvc.1.0.view", @"/Views/Partial/SingleGameMainBanner.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb32f298013e000367cd70e0136bf99c8348a1d3", @"/Views/Partial/SingleGameMainBanner.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c080b26fe0577ed42d50670c81b4fb74fa9dc44", @"/Views/_ViewImports.cshtml")]
    public class Views_Partial_SingleGameMainBanner : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<gameshop.WebApplication.Models.GameVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"col-lg-4 col-md-6 col-12\">\r\n    <div class=\"single-banner\">\r\n        <img src=\"https://via.placeholder.com/600x370\" alt=\"#\">\r\n        <div class=\"content\">\r\n            <p>");
#nullable restore
#line 7 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Partial\SingleGameMainBanner.cshtml"
          Write(ViewData["Category"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <h3>\r\n                ");
#nullable restore
#line 9 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Partial\SingleGameMainBanner.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                ");
#nullable restore
#line 10 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Partial\SingleGameMainBanner.cshtml"
           Write(ViewData["Developer"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                <!--");
#nullable restore
#line 11 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Partial\SingleGameMainBanner.cshtml"
               Write(ViewData["Publisher"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("-->\r\n            </h3>\r\n            <a href=\"#\">Discover Now</a>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<gameshop.WebApplication.Models.GameVM> Html { get; private set; }
    }
}
#pragma warning restore 1591