using System.Collections.Generic;
using System.Linq;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.HomePages.GetSlider.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.HomePages.GetSlider
{
    public class GetSliderService : IGetSliderService
    {
        private readonly IDatabaseContext _context;
        public GetSliderService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetSliderDto>> Execute()
        {
            var slider = _context.Tbl_Slider.Select(x => new GetSliderDto
            {
                Id = x.Id,
                Link = x.Link,
                Src = x.Src,
            }).ToList();

            var result = new ResultDto<List<GetSliderDto>>
            {
                Data = slider,
                IsSuccess = true,
                Message = ""
            };
            return result;
        }
    }
}
