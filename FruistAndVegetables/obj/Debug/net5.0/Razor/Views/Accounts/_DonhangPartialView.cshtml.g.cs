#pragma checksum "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Accounts\_DonhangPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd208acffbc4e19ae6d9e8b6532476682d50d186"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Accounts__DonhangPartialView), @"mvc.1.0.view", @"/Views/Accounts/_DonhangPartialView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd208acffbc4e19ae6d9e8b6532476682d50d186", @"/Views/Accounts/_DonhangPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe8312d730cad39cb5a5ccc8b2f4483a4d59e8d4", @"/Views/_ViewImports.cshtml")]
    public class Views_Accounts__DonhangPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Order>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Accounts\_DonhangPartialView.cshtml"
 if (Model != null && Model.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""table-responsive"">
        <table class=""table table-bordered table-hover"">
            <tbody>
                <tr>
                    <th>Mã đơn hàng</th>
                    <th>Ngày mua hàng</th>
                    <th>Ngày chuyển hàng</th>
                    <th>Trạng thái đơn hàng</th>
                    <th>Tổng tiền</th>
                    <th></th>
                </tr>
");
#nullable restore
#line 19 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Accounts\_DonhangPartialView.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td><a class=\"account-order-id\" href=\"javascript:void(0)\">#");
#nullable restore
#line 22 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Accounts\_DonhangPartialView.cshtml"
                                                                      Write(item.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Accounts\_DonhangPartialView.cshtml"
               Write(item.OrderDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Accounts\_DonhangPartialView.cshtml"
               Write(item.ShipDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> \r\n                <td>");
#nullable restore
#line 25 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Accounts\_DonhangPartialView.cshtml"
               Write(item.TranSactStatus.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <!-- Check if TotalMoney has a value before accessing Value -->\r\n                <td>");
#nullable restore
#line 27 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Accounts\_DonhangPartialView.cshtml"
                Write(item.TotalMoney.HasValue ? item.TotalMoney.Value.ToString("#,##0") + " VNĐ" : "N/A");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 33 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Accounts\_DonhangPartialView.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n");
#nullable restore
#line 38 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Accounts\_DonhangPartialView.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Chưa có đơn hàng</p>\r\n");
#nullable restore
#line 42 "C:\Users\nccuo\Desktop\ASP.NET Đồ án\FruistAndVegetables\FruistAndVegetables\Views\Accounts\_DonhangPartialView.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591