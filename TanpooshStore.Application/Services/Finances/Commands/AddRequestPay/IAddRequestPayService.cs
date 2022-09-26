using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Finances.Commands.AddRequestPay.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Finances.Commands.AddRequestPay
{
    public interface IAddRequestPayService
    {
        ResultDto<ResultRequestPayDto> Execute(int amount, int userId);
    }
}
