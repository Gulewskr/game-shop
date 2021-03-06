#pragma checksum "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78d05f96c57f276e23e2de4ee37956f217ad85db"
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
#nullable restore
#line 1 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
using gameshop.WebApplication.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"78d05f96c57f276e23e2de4ee37956f217ad85db", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c080b26fe0577ed42d50670c81b4fb74fa9dc44", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    List<GameVM> games = await StaticPublicRequests.GetGames();
    List<CategoryVM> categories = await StaticPublicRequests.GetCategories();
    List<PlatformVM> platforms = await StaticPublicRequests.GetPlatforms();
    List<CompanyVM> publishers = await StaticPublicRequests.GetPublishers();
    List<CompanyVM> developers = await StaticPublicRequests.GetDevelopers();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n<!--<h1 class=\"display-4\">Welcome</h1>\r\n<p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core POGU</a>.</p>\r\n    -->\r\n");
#nullable restore
#line 15 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
 if (games != null && games.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <!-- Slider Area -->\r\n    <section class=\"hero-slider\">\r\n        <!-- Single Slider -->\r\n        <div class=\"single-slider\">\r\n            <img style=\"position: absolute; transform: translate(-50%, 0); max-height:500px\"");
            BeginWriteAttribute("src", " src=\"", 925, "\"", 949, 1);
#nullable restore
#line 21 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
WriteAttributeValue("", 931, games[0].ImageURL, 931, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
            <div class=""container"">
                <div class=""row no-gutters"">
                    <div class=""col-lg-9 offset-lg-3 col-12"">
                        <div class=""text-inner"">
                            <div class=""row"">
                                <div class=""col-lg-7 col-12"">
                                    <div class=""hero-text""  style=""background: rgba(255,255,255,0.75); padding: 5px"">
                                        <h1><span>TEST NEWEST GAME</span>");
#nullable restore
#line 29 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
                                                                    Write(games[0].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                                        <p>");
#nullable restore
#line 30 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
                                      Write(games[0].Description.Substring(0, 100));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ...</p>
                                        <div class=""button"">
                                            <a href=""#"" class=""btn"">Shop Now!</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--/ End Single Slider -->
    </section>
    <!--/ End Slider Area -->
");
#nullable restore
#line 45 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
 if( games != null && games.Count > 4)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <section class=\"small-banner section\">\r\n        <div class=\"container-fluid\">\r\n            <div class=\"row\">\r\n                ");
#nullable restore
#line 51 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
           Write(await Html.PartialAsync("~/Views/Partial/SingleGameMainBanner.cshtml", games[1], new ViewDataDictionary(ViewData)
                        {
                            { "Category", categories.FirstOrDefault(x => x.Id == games[1].CategoryID).Name },
                            { "Developer", developers.FirstOrDefault(x => x.Id == games[1].DeveloperID).Name },
                            //{ "Publisher", publishers.FirstOrDefault(x => x.Id == games[0].PublisherID).Name },
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 57 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
           Write(await Html.PartialAsync("~/Views/Partial/SingleGameMainBanner.cshtml", games[2], new ViewDataDictionary(ViewData)
                        {
                            { "Category", categories.FirstOrDefault(x => x.Id == games[2].CategoryID).Name },
                            { "Developer", developers.FirstOrDefault(x => x.Id == games[2].DeveloperID).Name },
                            //{ "Publisher", publishers.FirstOrDefault(x => x.Id == games[0].PublisherID).Name },
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 63 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
           Write(await Html.PartialAsync("~/Views/Partial/SingleGameMainBanner.cshtml", games[3], new ViewDataDictionary(ViewData)
                        {
                            { "Category", categories.FirstOrDefault(x => x.Id == games[3].CategoryID).Name },
                            { "Developer", developers.FirstOrDefault(x => x.Id == games[3].DeveloperID).Name },
                            //{ "Publisher", publishers.FirstOrDefault(x => x.Id == games[0].PublisherID).Name },
                        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </section>\r\n");
#nullable restore
#line 72 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Start Product Area -->
<div class=""product-area section"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""section-title"">
                    <h2>Featured Items</h2>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-12"">
                <div class=""product-info"">
                    <div class=""tab-content"" id=""myTabContent"">
                        <!-- Start Single Tab -->
                        <div class=""tab-pane fade show active"" id=""man"" role=""tabpanel"">
                            <div class=""tab-single"">
                                <div class=""row"">
");
#nullable restore
#line 92 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
                                     if(games != null )
                                    foreach (GameVM game in games)
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 95 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
                                   Write(await Html.PartialAsync("~/Views/Partial/SingleGameBanner.cshtml", game, new ViewDataDictionary(ViewData)
                                        {
                                            { "Category", categories.FirstOrDefault(x => x.Id == game.CategoryID) == null ? "-" :  categories.FirstOrDefault(x => x.Id == game.CategoryID).Name },
                                            { "Developer", developers.FirstOrDefault(x => x.Id == game.DeveloperID) == null ? "-" :  developers.FirstOrDefault(x => x.Id == game.DeveloperID).Name },
                                            //{ "Publisher", publishers.FirstOrDefault(x => x.Id == games[0].PublisherID).Name },
                                        }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 100 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Home\Index.cshtml"
                                          
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                            </div>
                        </div>
                        <!--/ End Single Tab -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- End Product Area -->");
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
