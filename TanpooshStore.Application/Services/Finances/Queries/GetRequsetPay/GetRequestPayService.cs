using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Finances.Queries.GetRequsetPay.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Finances.Queries.GetRequsetPay
{
    public class GetRequestPayService : IGetRequestPayService
    {
        private readonly IDatabaseContext _context;
        public GetRequestPayService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<GetRequestPayDto> Execute(Guid guid)
        {
            var requestPay = _context.Tbl_RequestPay.Where(r => r.GUId == guid).FirstOrDefault();
            if (requestPay != null)
            {
                var result = new ResultDto<GetRequestPayDto>
                {
                    Data = new GetRequestPayDto
                    {
                        Amount = requestPay.Amount,
                        Id = requestPay.Id,
                    },
                    IsSuccess = true,
                    Message = "",
                };
                return result;
            }
            else
            {
                throw new Exception("request pay not found !");
            }
        }
    }
}
