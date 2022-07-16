using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Products.Queries.Dto;
using TanpooshStore.Application.Validators;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Products.Commands.EditProduct
{
    public class EditProductService : IEditProductService
    {
        private readonly IDatabaseContext _context;
        public EditProductService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(EditProductRequestDto request)
        {
            EditProductRequestValidator validations = new EditProductRequestValidator();
            if (validations.Validate(request).IsValid)
            {
                var product = _context.Tbl_Products.Find(request.Id);
                if (product == null)
                {
                    var result1 = new ResultDto
                    {
                        IsSuccess = false,
                        Message = "محصول مورد نظر یافت نشد !"
                    };
                    return result1;
                }
                product.Name = request.Name;
                product.Brand = request.Brand;
                product.Invertory = request.Invertory;
                product.CategoryId = request.CategoryId;
                product.Price = request.Price;
                product.Displayed = request.Displayed;
                product.UpdateTime = DateTime.Now;
                _context.SaveChanges();
                var result = new ResultDto
                {
                    IsSuccess = true,
                    Message = "ویرایش محصول با موفقیت انجام شد !"
                };
                return result;
            }
            else
            {
                var result2 = new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا اطلاعات را به درستی وارد کنید ."
                };
                return result2;
            }


        }
    }
}
