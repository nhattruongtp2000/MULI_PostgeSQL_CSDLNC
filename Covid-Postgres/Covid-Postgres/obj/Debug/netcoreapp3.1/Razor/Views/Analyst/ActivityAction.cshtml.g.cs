#pragma checksum "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\ActivityAction.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9dfec37c5fe7b407fbc20e513c7da039e63d55d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Analyst_ActivityAction), @"mvc.1.0.view", @"/Views/Analyst/ActivityAction.cshtml")]
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
#line 1 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\_ViewImports.cshtml"
using Covid_Postgres;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\_ViewImports.cshtml"
using Covid_Postgres.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9dfec37c5fe7b407fbc20e513c7da039e63d55d8", @"/Views/Analyst/ActivityAction.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8201ef3324989b259847eaa6e311b30e6d22bc14", @"/Views/_ViewImports.cshtml")]
    public class Views_Analyst_ActivityAction : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Covid_Postgres.Models.ActivityVm>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\ActivityAction.cshtml"
  
    ViewData["Title"] = "Activity";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Lịch sử hoạt động của ");
#nullable restore
#line 7 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\ActivityAction.cshtml"
                     Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\ActivityAction.cshtml"
           Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 18 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\ActivityAction.cshtml"
           Write(Html.DisplayNameFor(model => model.Activity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\ActivityAction.cshtml"
           Write(Html.DisplayNameFor(model => model.DayCreate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 26 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\ActivityAction.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 30 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\ActivityAction.cshtml"
               Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 34 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\ActivityAction.cshtml"
               Write(Html.DisplayFor(modelItem => item.Activity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 37 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\ActivityAction.cshtml"
               Write(Html.DisplayFor(modelItem => item.DayCreate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 40 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\ActivityAction.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Covid_Postgres.Models.ActivityVm>> Html { get; private set; }
    }
}
#pragma warning restore 1591