using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Order.Queries.GetAdminOrder.Dto
{
    public class AdminOrderPaginationDto
    {
        public int RowCount { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public List<AdminOrderDto> Orders { get; set; }
    }
}
