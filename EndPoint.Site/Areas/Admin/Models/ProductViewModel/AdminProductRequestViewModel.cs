using System.Collections.Generic;
using TanpooshStore.Application.Services.Products.Queries.Dto;

namespace EndPoint.Site.Areas.Admin.Models.ProductViewModel
{
    public class AdminProductRequestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int Invertory { get; set; }
        public bool Displayed { get; set; }
        public string Category { get; set; }
        public List<AllCategoriesDto> Categories { get; set; }
    }
}
