using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Commons;
using TanpooshStore.Domain.Entities.Product;

namespace TanpooshStore.Domain.Entities.Carts
{
    public class CartItemEntity: BaseEntity
    {
        public int ProductId { get; set; } //fk
        public int Count { get; set; }
        public int Price { get; set; }
        public int CartId { get; set; } //fk

        [ForeignKey("ProductId")]
        public virtual ProductEntity Product { get; set; }
        [ForeignKey("CartId")]
        public virtual CartEntity Cart { get; set; }
    }
}
