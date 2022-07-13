using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Commons;

namespace TanpooshStore.Domain.Entities.Product
{
    public class ProductImageEntity: BaseEntity
    {
        public int ProductId { get; set; } //fk
        public string Src { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductEntity Product { get; set; }
    }
}
