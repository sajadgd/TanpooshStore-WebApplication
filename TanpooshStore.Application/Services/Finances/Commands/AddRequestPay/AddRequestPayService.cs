using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Finances.Commands.AddRequestPay.Dto;
using TanpooshStore.Common.Dto;
using TanpooshStore.Domain.Entities.RequestPay;

namespace TanpooshStore.Application.Services.Finances.Commands.AddRequestPay
{
    public class AddRequestPayService : IAddRequestPayService
    {
        private readonly IDatabaseContext _context;
        public AddRequestPayService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRequestPayDto> Execute(int amount, int userId)
        {
            var user = _context.Tbl_Users.Find(userId);
            RequestPayEntity requestPay = new RequestPayEntity
            {
                Amount = amount,
                UserId = userId,
                GUId = Guid.NewGuid(),
                IsPaid = false,
                InsertTime = DateTime.Now,
                User = user
            };
            _context.Tbl_RequestPay.Add(requestPay);
            _context.SaveChanges();

            var result = new ResultDto<ResultRequestPayDto>
            {
                Data = new ResultRequestPayDto
                {
                    GUId = requestPay.GUId,
                    Amount = requestPay.Amount,
                    RequestPayId = requestPay.Id,
                    UserEmail = requestPay.User.Email,
                    UserMobile = requestPay.User.Mobile,
                },
                IsSuccess = true
            };
            return result;
        }
    }
}
