using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Products.Queries.Dto;
using TanpooshStore.Common;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Products.Queries.GetSiteProductService
{
    public class GetSiteProductService : IGetSiteProductService
    {
        private readonly IDatabaseContext _context;
        public GetSiteProductService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<SiteProductPaginationDto> Execute(GetSiteProductRequestDto request)
        {
            int rowCount;
            var productQuery = _context.Tbl_Products
                .Include(p => p.ProductImages)
                .Where(p => p.Displayed != false).AsQueryable();

            if (request.CateId != null)
            {
                productQuery = productQuery.Where(p => p.CategoryId == request.CateId).AsQueryable();
            }

            if (request.SearchKey != null)
            {
                productQuery = productQuery.Where(p => p.Name.Contains(request.SearchKey) || p.Brand.Contains(request.SearchKey)).AsQueryable();
            }

            var product = productQuery.ToPaged(request.Page, request.PageSize, out rowCount)
             .Select(p => new GetSiteProductDto
             {
                 Id = p.Id,
                 Price = p.Price,
                 Title = p.Name,
                 ImageSrc = p.ProductImages.FirstOrDefault().Src
             }).ToList();

            var productResult = new SiteProductPaginationDto
            {
                PageSize = request.PageSize,
                RowCount = rowCount,
                CurrentPage = request.Page,
                Products = product,
            };

            var result = new ResultDto<SiteProductPaginationDto>
            {
                Data = productResult,
                IsSuccess = true,
                Message = ""
            };
            return result;
        }
    }
}
