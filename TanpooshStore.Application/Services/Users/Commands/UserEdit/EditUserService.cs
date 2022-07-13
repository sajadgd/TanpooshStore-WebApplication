using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Users.Commands.UserEdit
{
    public class EditUserService : IEditUserService
    {
        private readonly IDatabaseContext _context;
        public EditUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(EditUserRequestDto request)
        {
            var user = _context.Tbl_Users.Find(request.UserId);
            if (user == null)
            {
                var result1 = new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد !"
                };
                return result1;
            }
            if (string.IsNullOrWhiteSpace(request.FullName))
            {
                var result2 = new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا نام کاربر را وارد کنید"
                };
                return result2;
            }
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                var result3 = new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا ایمیل کاربر را وارد کنید"
                };
                return result3;
            }
            user.FullName = request.FullName;
            user.Email = request.Email;
            user.UpdateTime = DateTime.Now;
            _context.SaveChanges();

            var result = new ResultDto
            {
                IsSuccess = true,
                Message = "تغییرات کاربر با موفقیت ذخیره شد !"
            };
            return result;
        }
    }
}
