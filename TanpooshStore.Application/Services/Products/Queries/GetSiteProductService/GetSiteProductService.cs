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

            if (request.ParentCateId != null)
            {
                productQuery = productQuery.Where(p => p.Category.ParentCategoryId == request.ParentCateId).AsQueryable();
            }

            if (request.CateId != null)
            {
                productQuery = productQuery.Where(p => p.CategoryId == request.CateId).AsQueryable();
            }

            if (request.SearchKey != null)
            {
                productQuery = productQuery.Where(p => p.Name.Contains(request.SearchKey) || p.Brand.Contains(request.SearchKey)).AsQueryable();
            }

            switch (request.Ordering)
            {
                case GetSiteProductOrdering.NotOrdered:
                    productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case GetSiteProductOrdering.MostVisited:
                    productQuery = productQuery.OrderByDescending(p => p.ViewCount).AsQueryable();
                    break;
                case GetSiteProductOrdering.MostPaid:
                    break;
                case GetSiteProductOrdering.MostWished:
                    break;
                case GetSiteProductOrdering.MostNew:
                    productQuery = productQuery.OrderByDescending(p => p.InsertTime).AsQueryable();
                    break;
                case GetSiteProductOrdering.MostExpensive:
                    productQuery= productQuery.OrderByDescending(p => p.Price).AsQueryable();
                    break;
                case GetSiteProductOrdering.MostCheap:
                    productQuery = productQuery.OrderBy(p => p.Price).AsQueryable();
                    break;
                default:
                    productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
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
