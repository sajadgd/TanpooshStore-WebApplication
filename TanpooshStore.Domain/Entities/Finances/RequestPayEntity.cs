using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Commons;
using TanpooshStore.Domain.Entities.Order;
using TanpooshStore.Domain.Entities.Users;

namespace TanpooshStore.Domain.Entities.RequestPay
{
    public class RequestPayEntity : BaseEntity
    {
        public Guid GUId { get; set; }
        public int UserId { get; set; } //fk
        public int Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        public virtual ICollection<OrderEntity> Order { get; set; }
    }
}
