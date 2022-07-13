﻿using EndPoint.Site.Areas.Admin.Models.ProductViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Products.Commands.AddNewProduct.Dto;
using TanpooshStore.Application.Services.Products.Queries.Dto;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(int page = 1, int pageSize = 20)
        {
            AdminProductRequestViewModel viewModel = new AdminProductRequestViewModel();
            var model = _productFacad.getAdminProductService.Execute(page, pageSize).Data = new AdminProductPaginationDto
            {
                Products = new List<GetAdminProductsDto>
                {
                }
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.Categories = new SelectList(_productFacad.getAllCategoriesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(AddNewProductRequestDto request, List<ProductFeaturesRequestDto> features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var files = Request.Form.Files[i];
                images.Add(files);
            }
            request.Images = images;
            request.Features = features;
            var result = _productFacad.addNewProductService.Execute(request);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            var result = _productFacad.removeProductService.Execute(productId);
            return Json(result);
        }

        [HttpPost]
        public IActionResult Edit(AdminProductRequestViewModel request)
        {
            var result = _productFacad.editProductService.Execute(new GetAdminProductsDto
            {
                Brand = request.Brand,
                Category = request.Category,
                Id = request.Id,
                Name = request.Name,
                Invertory = request.Invertory,
                Price = request.Price,
                Displayed = request.Displayed,
            });
            return Json(result);
        }
    }
}