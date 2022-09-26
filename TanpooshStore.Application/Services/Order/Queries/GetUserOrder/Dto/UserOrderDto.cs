using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Order;

namespace TanpooshStore.Application.Services.Order.Queries.GetUserOrder.Dto
{
    public class UserOrderDto
    {
        public int OrderId { get; set; }
        public OrderState OrderState { get; set; }
        public int RequestPayId { get; set; }
        public List<UserOrderDetailsDto> OrderDetails { get; set; }
    }
}
