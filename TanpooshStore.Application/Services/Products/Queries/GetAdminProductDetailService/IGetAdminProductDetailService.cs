using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Products.Queries.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Products.Queries.GetAdminProductDetailService
{
    public interface IGetAdminProductDetailService
    {
        ResultDto<GetAdminProductDetailDto> Execute(int Id);
    }
}
