using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Commons;
using TanpooshStore.Domain.Entities.RequestPay;
using TanpooshStore.Domain.Entities.Users;

namespace TanpooshStore.Domain.Entities.Order
{
    public class OrderEntity : BaseEntity
    {
        public int UserId { get; set; } //fk
        public int RequestPayId { get; set; } //fk
        public OrderState OrderState { get; set; }
        public string Address { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        [ForeignKey("RequestPayId")]
        public virtual RequestPayEntity RequestPay { get; set; }

        public virtual ICollection<OrderDetailEntity> OrderDeatils { get; set; }
    }
}
