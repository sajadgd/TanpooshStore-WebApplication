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

namespace TanpooshStore.Application.Services.Products.Queries.GetAdminProductService
{
    public class GetAdminProductService : IGetAdminProductService
    {
        private readonly IDatabaseContext _context;
        public GetAdminProductService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<AdminProductPaginationDto> Execute(int page, int pageSize, string searchKey)
        {
            try
            {
                int rowCount;
                var product = _context.Tbl_Products
                    .Include(p => p.Category)
                    .ToPaged(page, pageSize, out rowCount)
                    .Select(p => new GetAdminProductsDto
                    {
                        Id = p.Id,
                        Brand = p.Brand,
                        Category = p.Category.Name,
                        Displayed = p.Displayed,
                        Name = p.Name,
                        Invertory = p.Invertory,
                        Price = p.Price,
                    }).ToList();

                if (!string.IsNullOrWhiteSpace(searchKey))
                {
                    product = product.Where(p => p.Name.Contains(searchKey) || p.Brand.Contains(searchKey) || p.Category.Contains(searchKey)).ToList();
                }

                var result = new ResultDto<AdminProductPaginationDto>
                {
                    Data = new AdminProductPaginationDto
                    {
                        Products = product,
                        CurrentPage = page,
                        PageSize = pageSize,
                        RowCount = rowCount
                    },
                    IsSuccess = true,
                    Message = ""
                };
                return result;
            }
            catch (Exception)
            {
                var result1 = new ResultDto<AdminProductPaginationDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "لیست مورد نظر یافت نشد !"
                };
                return result1;
            }

                
        }
    }
}
