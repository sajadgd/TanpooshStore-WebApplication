using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Products.Queries.Dto
{
    public class CategoriesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoriesDto Parent { get; set; }
    }
}
