using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Products.Queries.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Products.Queries.GetSiteProductDetailService
{
    public class GetSiteProductDetailService : IGetSiteProductDetailService
    {
        private readonly IDatabaseContext _context;
        public GetSiteProductDetailService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<GetSiteProductDetailsDto> Execute(int productId)
        {
            var product = _context.Tbl_Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductFeatures)
                .Include(p => p.Category).ThenInclude(c => c.ParentCategory)
                .Where(p => p.Id == productId).FirstOrDefault();

            if (product == null)
            {
                return new ResultDto<GetSiteProductDetailsDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "محصول مورد نظر یافت نشد !"
                };
            }

            Random rand = new Random();
            var prodDetail = new GetSiteProductDetailsDto
            {
                Id = productId,
                Name = product.Name,
                Brand = product.Brand,
                Description = product.Description,
                Price = product.Price,
                Stars = rand.Next(1, 5),
                Category = $"{product.Category.Name} , {product.Category.ParentCategory.Name}",
                Features = product.ProductFeatures.Select(f => new SiteProductFeaturesDetailDto
                {
                    DisplayName = f.DisplayName,
                    Id = f.Id,
                    Value = f.Value,
                }).ToList(),
                Images = product.ProductImages.Select(i => new SiteProductImagesDetailDto
                {
                    Id = i.Id,
                    Src = i.Src,
                }).ToList()
            };

            var result = new ResultDto<GetSiteProductDetailsDto>
            {
                Data = prodDetail,
                IsSuccess = true,
                Message = ""
            };
            return result;
        }
    }
}
