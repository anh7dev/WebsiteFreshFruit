#pragma checksum "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32356fd4dec1f413613b97355cb9d2a93b95759e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Index), @"mvc.1.0.view", @"/Views/Blog/Index.cshtml")]
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
#line 1 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\_ViewImports.cshtml"
using FruistAndVegetables;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\_ViewImports.cshtml"
using FruistAndVegetables.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
using PagedList.Core.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32356fd4dec1f413613b97355cb9d2a93b95759e", @"/Views/Blog/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe8312d730cad39cb5a5ccc8b2f4483a4d59e8d4", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList.Core.IPagedList<FruistAndVegetables.Models.TinTuc>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-full"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
  
    ViewData["Title"] = "Blog Index - " + ViewBag.CurrentPage;
    Layout = "~/Views/Shared/_Layout.cshtml";
    int PageCurrent = ViewBag.CurrentPage;
    int PageNext = PageCurrent + 1;
    int PagePrevious = PageCurrent - 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Begin Main Content Area -->
<main class=""main-content"">
    <div class=""breadcrumb-area breadcrumb-height"" data-bg-image=""~/assets/images/breadcrumb/bg/1-1-1920x373.jpg"">
        <div class=""container h-100"">
            <div class=""row h-100"">
                <div class=""col-lg-12"">
                    <div class=""breadcrumb-item"">
                        <h2 class=""breadcrumb-heading"">Tin nổi bật tuần qua</h2>

                        <ul>
                            <li>
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "32356fd4dec1f413613b97355cb9d2a93b95759e5478", async() => {
                WriteLiteral("Trang chủ<i class=\"pe-7s-angle-right\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </li>
                            <li>Tin nổi bật</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""blog-area blog-column-2 section-space-y-axis-100"">
        <div class=""container"">
            <div class=""row"">
");
#nullable restore
#line 34 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
                 if (Model != null && Model.Count() > 0)
                {
                    foreach (var item in Model)
                    {
                        string url = $"/tin-tuc/{item.Alias}-{item.PostId}.html";

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-md-6\">\r\n                            <div class=\"blog-item\">\r\n                                <div class=\"blog-img img-zoom-effect\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1748, "\"", 1759, 1);
#nullable restore
#line 42 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
WriteAttributeValue("", 1755, url, 1755, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "32356fd4dec1f413613b97355cb9d2a93b95759e8318", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1830, "~/images/news/", 1830, 14, true);
#nullable restore
#line 43 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
AddHtmlAttributeValue("", 1844, item.Thumb, 1844, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 43 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
AddHtmlAttributeValue("", 1862, item.Title, 1862, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    </a>
                                </div>
                                <div class=""blog-content"">
                                    <div class=""blog-meta text-dim-gray pb-3"">
                                        <ul>
                                            <li class=""date""><i class=""fa fa-calendar-o me-2""></i>");
#nullable restore
#line 49 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
                                                                                             Write(item.CreatedDate.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                                            <li>
                                                <span class=""comments me-3"">
                                                    <a href=""javascript:void(0)"">2 Comments</a>
                                                </span>
                                                <span class=""link-share"">
                                                    <a href=""javascript:void(0)"">Share</a>
                                                </span>
                                            </li>
                                        </ul>
                                    </div>
                                    <h5 class=""title mb-4"">
                                        <a");
            BeginWriteAttribute("href", " href=\"", 3044, "\"", 3055, 1);
#nullable restore
#line 61 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
WriteAttributeValue("", 3051, url, 3051, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 61 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
                                                  Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </h5>\r\n                                    <p class=\"short-desc mb-5\">");
#nullable restore
#line 63 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
                                                          Write(item.Scontents);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <div class=\"button-wrap\">\r\n                                        <a class=\"btn btn-custom-size lg-size btn-dark rounded-0\"");
            BeginWriteAttribute("href", " href=\"", 3361, "\"", 3372, 1);
#nullable restore
#line 65 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
WriteAttributeValue("", 3368, url, 3368, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Xem thêm</a>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 70 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-lg-12\">\r\n                    <div class=\"pagination-area pt-10\">\r\n                        <nav aria-label=\"Page navigation example\">\r\n                            <ul class=\"pagination justify-content-center\">\r\n");
#nullable restore
#line 77 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
                                 if (PageCurrent > 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"page-item\">\r\n                                        <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4036, "\"", 4076, 2);
            WriteAttributeValue("", 4043, "/blogs.html?page=", 4043, 17, true);
#nullable restore
#line 80 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
WriteAttributeValue("", 4060, PageCurrent-1, 4060, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-label=\"Previous\">\r\n                                            <span class=\"fa fa-chevron-left\"></span>\r\n                                        </a>\r\n                                    </li>\r\n");
#nullable restore
#line 84 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <li class=""page-item disabled"">
                                        <a class=""page-link"" href=""#"" aria-label=""Previous"">
                                            <span class=""fa fa-chevron-left""></span>
                                        </a>
                                    </li>
");
#nullable restore
#line 92 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <li class=\"page-item active\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4841, "\"", 4877, 2);
            WriteAttributeValue("", 4848, "/blogs.html?page=", 4848, 17, true);
#nullable restore
#line 94 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
WriteAttributeValue("", 4865, PageCurrent, 4865, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 94 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
                                                                                                                  Write(PageCurrent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                                <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 4976, "\"", 5018, 2);
            WriteAttributeValue("", 4983, "/blogs.html?page=", 4983, 17, true);
#nullable restore
#line 95 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5000, PageCurrent + 1, 5000, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 95 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
                                                                                                                 Write(PageNext);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                                <li class=\"page-item\">\r\n                                    <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 5152, "\"", 5194, 2);
            WriteAttributeValue("", 5159, "/blogs.html?page=", 5159, 17, true);
#nullable restore
#line 97 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Blog\Index.cshtml"
WriteAttributeValue("", 5176, PageCurrent + 1, 5176, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" aria-label=""Next"">
                                        <span class=""fa fa-chevron-right""></span>
                                    </a>
                                </li>
                            </ul>
                        </nav>
                    </div>
                </div>

            </div>
        </div>
    </div>
</main>
<!-- Main Content Area End Here -->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList.Core.IPagedList<FruistAndVegetables.Models.TinTuc>> Html { get; private set; }
    }
}
#pragma warning restore 1591