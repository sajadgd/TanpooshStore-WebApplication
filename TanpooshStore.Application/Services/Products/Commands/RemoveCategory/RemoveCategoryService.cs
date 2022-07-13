using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Products.Commands.RemoveCategory
{
    public class RemoveCategoryService : IRemoveCategoryService
    {
        private readonly IDatabaseContext _context;
        public RemoveCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int Id)
        {
            var category = _context.Tbl_Category.Find(Id);
            if (category == null)
            {
                var result1 = new ResultDto
                {
                    IsSuccess = false,
                    Message = "دسته بندی مورد نظر یافت نشد !"
                };
                return result1;
            }
            category.RemoveTime = DateTime.Now;
            category.IsRemoved = true;
            _context.SaveChanges();
            var result = new ResultDto
            {
                IsSuccess = true,
                Message = "عملیات حذف با موفقیت انجام شد !"
            };
            return result;
        }
    }
}
