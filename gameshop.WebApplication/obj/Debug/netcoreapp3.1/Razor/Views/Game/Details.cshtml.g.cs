#pragma checksum "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ec50c4684d453d8b3430ff18c2bfea152d8146e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Details), @"mvc.1.0.view", @"/Views/Game/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ec50c4684d453d8b3430ff18c2bfea152d8146e", @"/Views/Game/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c080b26fe0577ed42d50670c81b4fb74fa9dc44", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<gameshop.WebApplication.Models.GameVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>GameVM</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CategoryID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
       Write(Html.DisplayFor(model => model.CategoryID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PublisherID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
       Write(Html.DisplayFor(model => model.PublisherID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DeveloperID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
       Write(Html.DisplayFor(model => model.DeveloperID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n");
#nullable restore
#line 52 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
      
        List<GameByPlat> games = ViewBag.GamesByPlat;
        if (ViewBag.Platforms != null && Model != null)
            foreach (PlatformVM plat in ViewBag.Platforms)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n");
#nullable restore
#line 58 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
              
                GameByPlat act = games.FirstOrDefault(x => x.PlatformID == plat.Id);
                if (act == null) act = new GameByPlat()
                {
                    Id = 0,
                    GameID = Model.Id,
                    PlatformID = plat.Id,
                };
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
           Write(await Html.PartialAsync("~/Views/Game/CreateGameByPlat.cshtml", act, new ViewDataDictionary(ViewData)
                        {
                            { "platform", plat.Name }
                        }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
                          ;
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n");
#nullable restore
#line 72 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
            }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<div>\r\n    ");
#nullable restore
#line 76 "C:\Studia\PAWiM\GameShop\gameshop.WebApplication\Views\Game\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ec50c4684d453d8b3430ff18c2bfea152d8146e9571", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
