using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Finances.Queries.GetAdminRequestPay.Dto
{
    public class AdminRequestPayPaginationDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public List<AdminRequestPayDto> RequestPay { get; set; }
    }
}
