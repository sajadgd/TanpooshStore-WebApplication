using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Order.Commands.AddNewOrder.Dto
{
    public class AddNewOrderRequestDto
    {
        public int CartId { get; set; }
        public int RequestPayId { get; set; }
        public int UserId { get; set; }
        public int RefId { get; set; } = 0;
        public string Authority { get; set; }
    }
}
