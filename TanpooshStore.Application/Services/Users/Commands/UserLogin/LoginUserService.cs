using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Users.Commands.UserLogin.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Users.Commands.UserLogin
{
    public class LoginUserService : ILoginUserService
    {
        private readonly IDatabaseContext _context;
        public LoginUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<LoginResultDto> Execute(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                var result1 = new ResultDto<LoginResultDto>()
                {
                    Data = new LoginResultDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "لطفا نام کاربری یا رمز عبور را وارد نمایید !"
                };
                return result1;
            }
            var user = _context.Tbl_Users
                .Include(p => p.UserInRole).ThenInclude(p => p.Role)
                .Where(p => p.Email.Equals(email) && p.IsActive == true).FirstOrDefault();
            if (user == null)
            {
                var result2 = new ResultDto<LoginResultDto>()
                {
                    Data = new LoginResultDto
                    {

                    },
                    IsSuccess = false,
                    Message = "کاربری با این نام کاربری در فروشگاه تنپوش ثبت نام نکرده است !"
                };
                return result2;
            }
            var passwordHasher = new PasswordHasher();
            var verifiedPassword = passwordHasher.VerifyHashedPassword(user.Password, password);
            if (verifiedPassword == 0)
            {
                var result3 = new ResultDto<LoginResultDto>()
                {
                    Data = new LoginResultDto
                    {

                    },
                    IsSuccess = false,
                    Message = "رمز ورود وارد شده اشتباه است ! "
                };
                return result3;
            }
            var roles = "";
            foreach (var item in user.UserInRole)
            {
                roles += $"{item.Role.Name}";
            }
            var result = new ResultDto<LoginResultDto>()
            {
                Data = new LoginResultDto
                {
                    UserId= user.Id,
                    Roles= roles,
                    FullName= user.FullName
                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد ! "
            };
            return result;
        }
    }
}
