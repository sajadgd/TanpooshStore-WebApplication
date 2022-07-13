using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Products.Queries.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Products.Queries
{
    public class GetCategoryService : IGetCategoryService
    {
        private readonly IDatabaseContext _context;
        public GetCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<CategoriesDto>> Execute(int? parentId)
        {
            var categories = _context.Tbl_Category.Include(c => c.ParentCategory)
                .Include(c => c.SubCategory).Where(c => c.ParentCategoryId == parentId).ToList()
                .Select(p => new CategoriesDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    HasChild = p.SubCategory.Count() > 0 ? true : false,
                    Parent = p.ParentCategory != null ? new ParentCategoriesDto
                    {
                        Id = p.ParentCategory.Id,
                        Name = p.ParentCategory.Name
                    } : null,
                }).ToList();

            var result = new ResultDto<List<CategoriesDto>>()
            {
                Data = categories,
                IsSuccess = true,
                Message = "لیست با موفقیت برگشت داده شد !"
            };
            return result;
        }
    }
}
