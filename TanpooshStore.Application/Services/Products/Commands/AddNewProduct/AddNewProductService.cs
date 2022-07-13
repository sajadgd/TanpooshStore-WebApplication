using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Products.Commands.AddNewProduct.Dto;
using TanpooshStore.Application.Services.Products.UploadFiles;
using TanpooshStore.Application.Validators;
using TanpooshStore.Common.Dto;
using TanpooshStore.Domain.Entities.Product;

namespace TanpooshStore.Application.Services.Products.Commands.AddNewProduct
{
    public class AddNewProductService : IAddNewProductService
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddNewProductService(IDatabaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDto Execute(AddNewProductRequestDto request)
        {
            try
            {
                AddNewProductRequestValidator validations = new AddNewProductRequestValidator();
                if (validations.Validate(request).IsValid)
                {
                    var category = _context.Tbl_Category.Find(request.CategoryId);
                    var product = new ProductEntity
                    {
                        Brand = request.Brand,
                        Description = request.Description,
                        Category = category,
                        Displayed = request.Displayed,
                        Price = request.Price,
                        Name = request.Name,
                        InsertTime = DateTime.Now,
                        CategoryId = request.CategoryId,
                        Invertory = request.Invertory,
                    };
                    _context.Tbl_Products.Add(product);

                    List<ProductImageEntity> productImages = new List<ProductImageEntity>();
                    foreach (var item in request.Images)
                    {
                        var uploadedResult = UploadFile(item);
                        productImages.Add(new ProductImageEntity
                        {
                            Product = product,
                            ProductId = product.Id,
                            Src = uploadedResult.FileNameAddress,
                            InsertTime = DateTime.Now,
                        });
                    }
                    _context.Tbl_ProductImages.AddRange(productImages);

                    List<ProductFeaturesEntity> productFeatures = new List<ProductFeaturesEntity>();
                    foreach (var item in request.Features)
                    {
                        productFeatures.Add(new ProductFeaturesEntity
                        {
                            DisplayName = item.DisplayName,
                            Product = product,
                            ProductId = product.Id,
                            Value = item.Value,
                            InsertTime = DateTime.Now
                        });
                    }
                    _context.Tbl_ProductFeatures.AddRange(productFeatures);

                    _context.SaveChanges();

                    var result = new ResultDto
                    {
                        IsSuccess = true,
                        Message = "محصول جدید با موفقیت به فروشگاه اضافه شد !"
                    };
                    return result;
                }
                else
                {
                    var result1 = new ResultDto
                    {
                        IsSuccess = false,
                        Message = "خطا! محصول مورد نظر به فروشگاه اضافه نشد !"
                    };
                    return result1;
                }
            }
            catch (Exception)
            {
                var result1 = new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا! محصول مورد نظر به فروشگاه اضافه نشد !"
                };
                return result1;
            }
            
        }

        private UploadFileDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath , FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                var result = new UploadFileDto
                {
                    Status = true,
                    FileNameAddress = folder + fileName
                };
                return result;
            }
            else
            {
                var result1 = new UploadFileDto
                {
                    Status = false,
                    FileNameAddress = ""
                };
                return result1;
            }
        }
    }
}

