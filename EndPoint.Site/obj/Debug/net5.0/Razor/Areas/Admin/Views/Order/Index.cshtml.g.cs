#pragma checksum "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "574c71c815bde10e13fdb04f040776053731d92b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Order_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Order/Index.cshtml")]
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
#line 1 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\_ViewImports.cshtml"
using EndPoint.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\_ViewImports.cshtml"
using EndPoint.Site.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
using TanpooshStore.Application.Services.Order.Queries.GetAdminOrder.Dto;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"574c71c815bde10e13fdb04f040776053731d92b", @"/Areas/Admin/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87685c89e84078b3e134b89a928accf3d0f04a39", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdminOrderPaginationDto>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", "row", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("query-string-key-page-no", "page", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("query-string-key-page-size", "pageSize", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::LazZiya.TagHelpers.PagingTagHelper __LazZiya_TagHelpers_PagingTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""content-header"">
    <h1>
        سفارشات
        <small>لیست</small>
    </h1>
    <ol class=""breadcrumb"">
        <li><a href=""#""><i class=""fa fa-users""></i> خانه</a></li>
        <li><a href=""#"">سفارشات</a></li>
        <li class=""active"">لیست</li>
    </ol>
</section>
<section class=""content"">
    <div class=""row"">
        <div class=""col-xs-12"">

            <div class=""box"">
                <div class=""box-header"">
                    <h3 class=""box-title"">لیست سفارشات</h3>
                </div>
                <!-- /.box-header -->
                <div class=""box-body"">
                    <div id=""example1_wrapper"" class=""dataTables_wrapper form-inline dt-bootstrap"">
                        <div class=""row"">
                            <div class=""col-sm-12"">
                                <table id=""example1"" class=""table table-bordered table-striped dataTable"" role=""grid"" aria-describedby=""example1_info"">
                                    <thead>
     ");
            WriteLiteral(@"                                   <tr role=""row"">
                                            <th class=""sorting_asc"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" aria-label=""شناسه سفارش : activate to sort column descending"" aria-sort=""ascending"" style=""width: 182.225px;"">شناسه سفارش</th>
                                            <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" aria-label=""زمان ثبت : activate to sort column ascending"" style=""width: 340.788px;"">زمان ثبت</th>
                                            <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" aria-label=""شناسه فاکتور : activate to sort column ascending"" style=""width: 327.375px;"">شناسه فاکتور</th>
                                            <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" aria-label=""وضعیت سفارش : activate to sort column ascending"" style=""width: 327.375px;"">وضعیت سفارش</th>
                         ");
            WriteLiteral(@"                   <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" aria-label=""تعداد محصول : activate to sort column ascending"" style=""width: 327.375px;"">تعداد محصول</th>
                                            <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" aria-label=""activate to sort column ascending"" style=""width: 327.375px;""></th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 46 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
                                          
                                            foreach (var item in Model.Orders)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr role=\"row\" class=\"odd\">\r\n                                                    <td class=\"sorting_1\">");
#nullable restore
#line 50 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
                                                                     Write(item.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 51 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
                                                   Write(item.InsertTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 52 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
                                                   Write(item.RequestPayId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 53 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
                                                   Write(item.OrderState);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 54 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
                                                   Write(item.ProductCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                                    <td>
                                                        <a class=""btn btn-info"">کاربر ثبت کننده سفارش</a>
                                                        <a class=""btn btn-danger"">مشاهده فاکتور</a>
                                                    </td>
                                                </tr>
");
#nullable restore
#line 60 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
                                            }
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <th rowspan=""1"" colspan=""1"">شناسه سفارش</th>
                                            <th rowspan=""1"" colspan=""1"">زمان ثبت</th>
                                            <th rowspan=""1"" colspan=""1"">شناسه فاکتور</th>
                                            <th rowspan=""1"" colspan=""1"">وضعیت سفارش</th>
                                            <th rowspan=""1"" colspan=""1"">تعداد محصول</th>
                                            <th rowspan=""1"" colspan=""1""></th>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                        <div class=""col-sm-7"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("paging", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "574c71c815bde10e13fdb04f040776053731d92b11099", async() => {
                WriteLiteral("\r\n                            ");
            }
            );
            __LazZiya_TagHelpers_PagingTagHelper = CreateTagHelper<global::LazZiya.TagHelpers.PagingTagHelper>();
            __tagHelperExecutionContext.Add(__LazZiya_TagHelpers_PagingTagHelper);
            __LazZiya_TagHelpers_PagingTagHelper.Class = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 78 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
__LazZiya_TagHelpers_PagingTagHelper.TotalRecords = Model.RowCount;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("total-records", __LazZiya_TagHelpers_PagingTagHelper.TotalRecords, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 79 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
__LazZiya_TagHelpers_PagingTagHelper.PageNo = Model.Page;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("page-no", __LazZiya_TagHelpers_PagingTagHelper.PageNo, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 80 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
__LazZiya_TagHelpers_PagingTagHelper.PageSize = Model.PageSize;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("page-size", __LazZiya_TagHelpers_PagingTagHelper.PageSize, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 81 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
__LazZiya_TagHelpers_PagingTagHelper.ShowPrevNext = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("show-prev-next", __LazZiya_TagHelpers_PagingTagHelper.ShowPrevNext, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 82 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
__LazZiya_TagHelpers_PagingTagHelper.ShowTotalPages = false;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("show-total-pages", __LazZiya_TagHelpers_PagingTagHelper.ShowTotalPages, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 83 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
__LazZiya_TagHelpers_PagingTagHelper.ShowTotalRecords = false;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("show-total-records", __LazZiya_TagHelpers_PagingTagHelper.ShowTotalRecords, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 84 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
__LazZiya_TagHelpers_PagingTagHelper.ShowPageSizeNav = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("show-page-size-nav", __LazZiya_TagHelpers_PagingTagHelper.ShowPageSizeNav, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 85 "E:\Web\TanpooshStore\EndPoint.Site\Areas\Admin\Views\Order\Index.cshtml"
__LazZiya_TagHelpers_PagingTagHelper.ShowFirstLast = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("show-first-last", __LazZiya_TagHelpers_PagingTagHelper.ShowFirstLast, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __LazZiya_TagHelpers_PagingTagHelper.QueryStringKeyPageNo = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __LazZiya_TagHelpers_PagingTagHelper.QueryStringKeyPageSize = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <!-- /.box-body -->\r\n            </div>\r\n            <!-- /.box -->\r\n        </div>\r\n        <!-- /.col -->\r\n    </div>\r\n    <!-- /.row -->\r\n</section>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdminOrderPaginationDto> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591