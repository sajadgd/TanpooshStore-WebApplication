using System.Collections.Generic;

namespace EndPoint.Site.Areas.Admin.Models.ProductViewModel
{
    public class AdminProductPagingViewModel
    {
        public List<AdminProductRequestViewModel> Products { get; set; }
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
