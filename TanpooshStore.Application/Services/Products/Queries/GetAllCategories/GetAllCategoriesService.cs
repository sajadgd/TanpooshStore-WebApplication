using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Products.Queries.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Products.Queries.GetAllCategories
{
    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly IDatabaseContext _context;
        public GetAllCategoriesService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<AllCategoriesDto>> Execute()
        {
            var allCategories = _context.Tbl_Category.Include(i => i.ParentCategory).Where(w => w.ParentCategoryId != null)
                .Select(s => new AllCategoriesDto
                {
                    Id = s.Id,
                    Name = $"{s.Name} - {s.ParentCategory.Name}",
                }).ToList();

            var result = new ResultDto<List<AllCategoriesDto>>
            {
                Data = allCategories,
                IsSuccess = true,
                Message = ""
            };
            return result;
        }
    }
}
