using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Products.Queries.Dto
{
    public class GetAdminProductDetailDto
    {
        public int Id { get; set; }

        [DisplayName("نام محصول")]
        public string Name { get; set; }

        [DisplayName("برند محصول")]
        public string Brand { get; set; }

        [DisplayName("توضیحات محصول")]
        public string Description { get; set; }

        [DisplayName("قیمت محصول")]
        public int Price { get; set; }

        [DisplayName("موجودی انبار")]
        public int Invertory { get; set; }
        public bool Displayed { get; set; }
        public string Category { get; set; }

        public List<AdminProductImagesDetailDto> Images { get; set; }
        public List<AdminProductFeaturesDetailDto> Features { get; set; }
    }
}
