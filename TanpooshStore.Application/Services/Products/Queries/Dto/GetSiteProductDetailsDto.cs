using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Products.Queries.Dto
{
    public class GetSiteProductDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int Stars { get; set; }

        public List<SiteProductImagesDetailDto> Images { get; set; }
        public List<SiteProductFeaturesDetailDto> Features { get; set; }
    }
}
