using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Products.Queries.GetSiteProductService;

namespace TanpooshStore.Application.Services.Products.Queries.Dto
{
    public class GetSiteProductRequestDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public int? CateId { get; set; }
        public int? ParentCateId { get; set; }
        public GetSiteProductOrdering Ordering { get; set; }
    }
}
