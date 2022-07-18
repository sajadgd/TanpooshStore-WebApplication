using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Products.Queries.Dto
{
    public class GetSiteProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string ImageSrc { get; set; }
    }
}
