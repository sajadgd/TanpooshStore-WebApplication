using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Finances.Queries.GetRequsetPay.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Finances.Queries.GetRequsetPay
{
    public interface IGetRequestPayService
    {
        ResultDto<GetRequestPayDto> Execute(Guid guid);
    }
}
