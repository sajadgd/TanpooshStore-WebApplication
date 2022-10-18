using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Finances.Queries.GetAdminRequestPay.Dto;
using TanpooshStore.Common;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Finances.Queries.GetAdminRequestPay
{
    public class GetAdminRequestPayService : IGetAdminRequestPayService
    {
        private readonly IDatabaseContext _context;
        public GetAdminRequestPayService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<AdminRequestPayPaginationDto> Execute(int page, int pageSize)
        {
            var requestPay = _context.Tbl_RequestPay
                .Include(r => r.User).OrderByDescending(r => r.Id).AsQueryable();

            int rowCount;
            var requestPayResult = requestPay.ToPaged(page, pageSize, out rowCount)
                .Select(p => new AdminRequestPayDto
                {
                    Id = p.Id,
                    Amount = p.Amount,
                    Authority = p.Authority,
                    GUId = p.GUId,
                    IsPaid = p.IsPaid,
                    PayDate = p.PayDate,
                    RefId = p.RefId,
                    UserId = p.UserId,
                    UserName = p.User.FullName
                }).ToList();

            var result = new ResultDto<AdminRequestPayPaginationDto>
            {
                Data = new AdminRequestPayPaginationDto
                {
                    Page = page,
                    PageSize = pageSize,
                    RequestPay = requestPayResult
                },
                IsSuccess = true
            };
            return result;
        }
    }
}
