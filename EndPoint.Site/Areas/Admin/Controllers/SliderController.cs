using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.HomePages.AddNewSlider;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IHomePageFacad _homePageFacad;
        public SliderController(IHomePageFacad homePageFacad)
        {
            _homePageFacad = homePageFacad;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNewSlider()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewSlider(IFormFile file, string link)
        {
            var result = _homePageFacad.addNewSliderService.Execute(file, link);
            return View(result);
        }
    }
}
