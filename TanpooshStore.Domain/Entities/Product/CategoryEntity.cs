using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Domain.Entities.Commons;

namespace TanpooshStore.Domain.Entities.Product
{
    public class CategoryEntity: BaseEntity
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; } //fk

        [ForeignKey("ParentCategoryId")]
        public virtual CategoryEntity ParentCategory { get; set; }
        ///////////////////////////////////////////
        ///
        public virtual ICollection<CategoryEntity> SubCategory { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }

    }
}
