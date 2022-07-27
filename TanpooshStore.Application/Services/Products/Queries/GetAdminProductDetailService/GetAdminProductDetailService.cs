using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Products.Queries.Dto;
using TanpooshStore.Common.Dto;
using TanpooshStore.Common.Utilities;
using TanpooshStore.Domain.Entities.Product;

namespace TanpooshStore.Application.Services.Products.Queries.GetAdminProductDetailService
{
    public class GetAdminProductDetailService : IGetAdminProductDetailService
    {
        private readonly IDatabaseContext _context;
        public GetAdminProductDetailService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<GetAdminProductDetailDto> Execute(int Id)
        {
            var product = _context.Tbl_Products
                .Include(p => p.Category).ThenInclude(c => c.ParentCategory)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .Where(p => p.Id == Id).FirstOrDefault();

            if (product == null)
            {
                return new ResultDto<GetAdminProductDetailDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "محصول مورد نظر یافت نشد !"
                };
            }

            var productDetail = new GetAdminProductDetailDto
            {
                Id = product.Id,
                Name = product.Name,
                Brand = product.Brand,
                Description = product.Description,
                Displayed = product.Displayed,
                Invertory = product.Invertory,
                Price = product.Price,
                Category = CategoryString(product.Category),
                Features = product.ProductFeatures.ToList().Select(p => new AdminProductFeaturesDetailDto
                {
                    DisplayName = p.DisplayName,
                    Value = p.Value,
                    Id = p.Id
                }).ToList(),
                Images = product.ProductImages.ToList().Select(p => new AdminProductImagesDetailDto
                {
                    Id = p.Id,
                    Src = p.Src,
                }).ToList(),
            };

            var result = new ResultDto<GetAdminProductDetailDto>
            {
                Data = productDetail,
                IsSuccess = true,
                Message = ""
            };
            return result;
        }

        private string CategoryString(CategoryEntity category)
        {
            string result = category.ParentCategory != null ? category.ParentCategory.Name + " - " + category.Name : category.Name;
            return result;
        }
    }
}
