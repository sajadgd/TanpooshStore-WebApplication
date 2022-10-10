using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Order;

namespace TanpooshStore.Application.Services.Order.Queries.GetAdminOrder.Dto
{
    public class AdminOrderRequestDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public OrderState OrderState { get; set; }
    }
}
