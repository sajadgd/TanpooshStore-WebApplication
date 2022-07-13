using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Users.Commands.UserChangeStatus
{
    public class ChangeStatusUserService : IChangeStatusUserService
    {
        private readonly IDatabaseContext _context;

        public ChangeStatusUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(int Id)
        {
            var user = _context.Tbl_Users.Find(Id);
            if (user == null)
            {
                var result1 = new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد !"
                };
                return result1;
            }
            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            string userStatus = user.IsActive == true ? "فعال" : "غیر فعال";
            var result = new ResultDto
            {
                IsSuccess = true,
                Message = $"کاربر با موفقیت {userStatus} شد !"
            };
            return result;
        }
    }
}
