using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.HomePages.GetSlider.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.HomePages.GetSlider
{
    public interface IGetSliderService
    {
        ResultDto<List<GetSliderDto>> Execute();
    }
}
