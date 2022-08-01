using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Common.Queries.GetMenuItem.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Common.Queries.GetMenuItem
{
    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDatabaseContext _context;
        public GetMenuItemService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetMenuItemDto>> Execute()
        {
            var menuItem = _context.Tbl_Category
                .Include(c => c.SubCategory)
                .Where(c => c.ParentCategoryId == null).ToList()
                .Select(c => new GetMenuItemDto
                {
                    CateId = c.Id,
                    Name = c.Name,
                    Child = c.SubCategory.ToList().Select(c => new GetMenuItemDto
                    {
                        CateId = c.Id,
                        Name = c.Name,
                    }).ToList(),
                }).ToList();

            var result = new ResultDto<List<GetMenuItemDto>>
            {
                Data = menuItem,
                IsSuccess = true,
                Message = ""
            };
            return result;
        }
    }
}
