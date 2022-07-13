using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Commons;

namespace TanpooshStore.Domain.Entities.Product
{
    public class ProductEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Invertory { get; set; }
        public bool Displayed { get; set; }
        public int CategoryId { get; set; } //fk

        [ForeignKey("CategoryId")]
        public virtual CategoryEntity Category { get; set; }

        public ICollection<ProductImageEntity> ProductImages { get; set; }
        public ICollection<ProductFeaturesEntity> ProductFeatures { get; set; }
    }
}
