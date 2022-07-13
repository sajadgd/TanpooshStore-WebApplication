using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Application.Services.Products.Commands.AddNewProduct.Dto
{
    public class AddNewProductRequestDto
    {
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
        public int CategoryId { get; set; }

        public List<IFormFile> Images { get; set; }
        public List<ProductFeaturesRequestDto> Features { get; set; }
    }
}
