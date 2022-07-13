using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Users.Commands.UserRemove
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDatabaseContext _context;
        public RemoveUserService(IDatabaseContext context)
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
            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
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
