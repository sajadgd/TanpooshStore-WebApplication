using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Products.Queries.Dto
{
    public class AdminProductPaginationDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<GetAdminProductsDto> Products { get; set; }
    }
}
