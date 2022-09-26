using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Commons;
using TanpooshStore.Domain.Entities.Product;

namespace TanpooshStore.Domain.Entities.Order
{
    public class OrderDetailEntity : BaseEntity
    {
        public int OrderId { get; set; } //fk
        public int ProductId { get; set; } //fk
        public int Price { get; set; }
        public int Count { get; set; }

        [ForeignKey("OrderId")]
        public virtual OrderEntity Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductEntity Product { get; set; }
    }
}
