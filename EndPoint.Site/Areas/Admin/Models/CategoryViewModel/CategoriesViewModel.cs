using System.Collections.Generic;
using TanpooshStore.Application.Services.Products.Queries.Dto;

namespace EndPoint.Site.Areas.Admin.Models
{
    public class CategoriesViewModel
    {
        public List<CategoriesDto> ListCategories { get; set; }
    }
}
