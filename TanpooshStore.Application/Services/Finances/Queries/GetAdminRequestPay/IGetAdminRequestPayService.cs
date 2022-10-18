using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Finances.Queries.GetAdminRequestPay.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Finances.Queries.GetAdminRequestPay
{
    public interface IGetAdminRequestPayService
    {
        ResultDto<AdminRequestPayPaginationDto> Execute(int page, int pageSize);
    }
}
