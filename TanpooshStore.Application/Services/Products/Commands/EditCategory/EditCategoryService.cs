using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Products.Commands.EditCategory
{
    public class EditCategoryService : IEditCategoryService
    {
        private readonly IDatabaseContext _context;
        public EditCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(EditCategoryRequestDto request)
        {
            var category = _context.Tbl_Category.Find(request.Id);
            if (category == null)
            {
                var result1 = new ResultDto
                {
                    IsSuccess = false,
                    Message = "دسته بندی مورد نظر یافت نشد !"
                };
                return result1;
            }
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                var result2 = new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام دسته بندی را وارد کنید !"
                };
                return result2;
            }
            category.Name = request.Name;
            category.UpdateTime = DateTime.Now;
            _context.SaveChanges();
            var result = new ResultDto
            {
                IsSuccess = true,
                Message = "ویرایش کاربر با موفقیت انجام شد !"
            };
            return result;
        }
    }
}
