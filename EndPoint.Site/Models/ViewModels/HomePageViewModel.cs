using System.Collections.Generic;
using TanpooshStore.Application.Services.HomePages.GetSlider.Dto;
using TanpooshStore.Application.Services.Products.Queries.Dto;

namespace EndPoint.Site.Models.ViewModels
{
    public class HomePageViewModel
    {
        public List<GetSliderDto> Sliders { get; set; }
        public SiteProductPaginationDto NewAllProducts { get; set; }
        public SiteProductPaginationDto NewSummerProducts { get; set; }
        public SiteProductPaginationDto NewWinterProducts { get; set; }
        public SiteProductPaginationDto NewKidsProducts { get; set; }
        public SiteProductPaginationDto NewAccessoriesProducts { get; set; }
    }
}
