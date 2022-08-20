using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Products.Queries.Dto;
using TanpooshStore.Application.Services.Products.Queries.GetSiteProductService;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomePageFacad _homePageFacad;
        private readonly IProductFacad _productFacad;

        public HomeController(ILogger<HomeController> logger, IHomePageFacad homePageFacad, IProductFacad productFacad)
        {
            _logger = logger;
            _homePageFacad = homePageFacad;
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            HomePageViewModel model = new HomePageViewModel();
            model.Sliders = _homePageFacad.getSliderService.Execute().Data;
            model.NewAllProducts = _productFacad.getSiteProductService.Execute(new GetSiteProductRequestDto
            {
                ParentCateId = null,
                Ordering = GetSiteProductOrdering.MostNew,
                Page = 1,
                PageSize = 8,
                SearchKey = ""
            }).Data;
            model.NewWinterProducts = _productFacad.getSiteProductService.Execute(new GetSiteProductRequestDto
            {
                ParentCateId = 5,
                Ordering = GetSiteProductOrdering.MostNew,
                Page = 1,
                PageSize = 8,
                SearchKey = ""
            }).Data;
            model.NewSummerProducts = _productFacad.getSiteProductService.Execute(new GetSiteProductRequestDto
            {
                ParentCateId = 1,
                Ordering = GetSiteProductOrdering.MostNew,
                Page = 1,
                PageSize = 8,
                SearchKey = ""
            }).Data;
            model.NewKidsProducts = _productFacad.getSiteProductService.Execute(new GetSiteProductRequestDto
            {
                ParentCateId = 9,
                Ordering = GetSiteProductOrdering.MostNew,
                Page = 1,
                PageSize = 8,
                SearchKey = ""
            }).Data;
            model.NewAccessoriesProducts = _productFacad.getSiteProductService.Execute(new GetSiteProductRequestDto
            {
                ParentCateId = 10,
                Ordering = GetSiteProductOrdering.MostNew,
                Page = 1,
                PageSize = 8,
                SearchKey = ""
            }).Data;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
