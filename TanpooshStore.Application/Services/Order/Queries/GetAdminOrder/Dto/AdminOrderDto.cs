using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Order;

namespace TanpooshStore.Application.Services.Order.Queries.GetAdminOrder.Dto
{
    public class AdminOrderDto
    {
        public int OrderId { get; set; }
        public int RequestPayId { get; set; }
        public int UserId { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime InsertTime { get; set; }
        public int ProductCount { get; set; }
    }
}
