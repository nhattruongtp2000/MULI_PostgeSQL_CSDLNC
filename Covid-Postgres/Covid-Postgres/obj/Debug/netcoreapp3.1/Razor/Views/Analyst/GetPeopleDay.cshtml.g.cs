#pragma checksum "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b7a0a7b192cb3ba7f601deb6b2a7c43490941a50"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Analyst_GetPeopleDay), @"mvc.1.0.view", @"/Views/Analyst/GetPeopleDay.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7a0a7b192cb3ba7f601deb6b2a7c43490941a50", @"/Views/Analyst/GetPeopleDay.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8201ef3324989b259847eaa6e311b30e6d22bc14", @"/Views/_ViewImports.cshtml")]
    public class Views_Analyst_GetPeopleDay : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Person>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
  
    var a = ViewBag.Date;

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Danh sách nhập viện trong ngày ");
#nullable restore
#line 5 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
                              Write(a.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b7a0a7b192cb3ba7f601deb6b2a7c43490941a503923", async() => {
                WriteLiteral("Create New");
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
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
           Write(Html.DisplayNameFor(model => model.PersonID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
           Write(Html.DisplayNameFor(model => model.PersonFullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
           Write(Html.DisplayNameFor(model => model.DateOfBirh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
           Write(Html.DisplayNameFor(model => model.PersonAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
           Write(Html.DisplayNameFor(model => model.PersonStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
           Write(Html.DisplayNameFor(model => model.PlaceOfTreatmentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 33 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
           Write(Html.DisplayNameFor(model => model.ChangeStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 36 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
           Write(Html.DisplayNameFor(model => model.CreateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 39 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
           Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 42 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
           Write(Html.DisplayNameFor(model => model.RelatedPersonId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 47 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 51 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
               Write(item.PersonID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
               Write(Html.DisplayFor(modelItem => item.PersonFullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 57 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateOfBirh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 60 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
               Write(Html.DisplayFor(modelItem => item.PersonAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 62 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
                 if (item.PersonStatus == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>F0</td>\r\n");
#nullable restore
#line 65 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
                }
                else if (item.PersonStatus == 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>F1</td>\r\n");
#nullable restore
#line 69 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
                }
                else if (item.PersonStatus == 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>F2</td>\r\n");
#nullable restore
#line 73 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
                }
                else if (item.PersonStatus == 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>F3</td>\r\n");
#nullable restore
#line 77 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>F4</td>\r\n");
#nullable restore
#line 81 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 83 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
               Write(Html.DisplayFor(modelItem => item.PlaceOfTreatmentId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 86 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
               Write(Html.DisplayFor(modelItem => item.ChangeStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 89 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
               Write(item.CreateDate.Remove(item.CreateDate.Length - 12));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 91 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
                 if (item.Gender == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>Nữ</td>\r\n");
#nullable restore
#line 94 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>Nam</td>\r\n");
#nullable restore
#line 98 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 100 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
               Write(Html.DisplayFor(modelItem => item.RelatedPersonId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 103 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Analyst\GetPeopleDay.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Person>> Html { get; private set; }
    }
}
#pragma warning restore 1591
