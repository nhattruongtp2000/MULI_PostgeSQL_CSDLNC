#pragma checksum "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa4e60d7ba61859516171f6497360ba8991148f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_OrderById), @"mvc.1.0.view", @"/Views/Home/OrderById.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa4e60d7ba61859516171f6497360ba8991148f0", @"/Views/Home/OrderById.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8201ef3324989b259847eaa6e311b30e6d22bc14", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_OrderById : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Person>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa4e60d7ba61859516171f6497360ba8991148f04236", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fa4e60d7ba61859516171f6497360ba8991148f04498", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa4e60d7ba61859516171f6497360ba8991148f06384", async() => {
                WriteLiteral("\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 14 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
               Write(Html.DisplayNameFor(model => model.PersonID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 17 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
               Write(Html.DisplayNameFor(model => model.PersonFullName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 20 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
               Write(Html.DisplayNameFor(model => model.DateOfBirh));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 23 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
               Write(Html.DisplayNameFor(model => model.PersonAddress));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 26 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
               Write(Html.DisplayNameFor(model => model.PersonStatus));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 29 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
               Write(Html.DisplayNameFor(model => model.PlaceOfTreatmentId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 32 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
               Write(Html.DisplayNameFor(model => model.ChangeStatus));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 35 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
               Write(Html.DisplayNameFor(model => model.CreateDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 38 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
               Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 41 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
               Write(Html.DisplayNameFor(model => model.RelatedPersonId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <td>\r\n                </td>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 48 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 52 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                   Write(item.PersonID);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 55 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PersonFullName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 58 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                   Write(item.DateOfBirh.Remove(item.DateOfBirh.Length - 12));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 61 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PersonAddress));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 63 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                     if (item.PersonStatus == 0)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>F0</td>\r\n");
#nullable restore
#line 66 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }
                    else if (item.PersonStatus == 1)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>F1</td>\r\n");
#nullable restore
#line 70 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }
                    else if (item.PersonStatus == 2)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>F2</td>\r\n");
#nullable restore
#line 74 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }
                    else if (item.PersonStatus == 3)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>F3</td>\r\n");
#nullable restore
#line 78 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }
                    else if (item.PersonStatus == 4)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>F4</td>\r\n");
#nullable restore
#line 82 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td></td>\r\n");
#nullable restore
#line 86 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 88 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PlaceOfTreatmentId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 90 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                     if (item.ChangeStatus == 0)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>F0</td>\r\n");
#nullable restore
#line 93 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }
                    else if (item.ChangeStatus == 1)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>F1</td>\r\n");
#nullable restore
#line 97 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }
                    else if (item.ChangeStatus == 2)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>F2</td>\r\n");
#nullable restore
#line 101 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }
                    else if (item.PersonStatus == 3)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>F3</td>\r\n");
#nullable restore
#line 105 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }
                    else if (item.ChangeStatus == 4)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>F4</td>\r\n");
#nullable restore
#line 109 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td></td>\r\n");
#nullable restore
#line 113 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 115 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                   Write(item.CreateDate.Remove(item.CreateDate.Length - 12));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 117 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                     if (item.Gender == 0)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>Nữ</td>\r\n");
#nullable restore
#line 120 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <td>Nam</td>\r\n");
#nullable restore
#line 124 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 126 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                   Write(Html.DisplayFor(modelItem => item.RelatedPersonId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td><a");
                BeginWriteAttribute("class", " class=\"", 4248, "\"", 4256, 0);
                EndWriteAttribute();
                WriteLiteral(" id=\"detailsbutton\"");
                BeginWriteAttribute("href", " href=\"", 4276, "\"", 4350, 1);
#nullable restore
#line 128 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
WriteAttributeValue("", 4283, Url.Action("GetPersonDetail","Home",new {PersonId=item.PersonID }), 4283, 67, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Chi tiết</a></td>\r\n                    <td><a id=\"deletebutton\" data-idperson=\"");
#nullable restore
#line 129 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
                                                       Write(item.PersonID);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"");
                BeginWriteAttribute("href", " href=\"", 4446, "\"", 4517, 1);
#nullable restore
#line 129 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
WriteAttributeValue("", 4453, Url.Action("DeletePerson","Home",new {PersonId=item.PersonID }), 4453, 64, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Xóa</a></td>\r\n                </tr>\r\n");
#nullable restore
#line 131 "D:\Visual project\Covid-Postgres\Covid-Postgres\Views\Home\OrderById.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </tbody>\r\n\r\n    </table>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
