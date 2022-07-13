using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Products.Commands.RemoveProduct
{
    public class RemoveProductService : IRemoveProductService
    {
        private readonly IDatabaseContext _context;
        public RemoveProductService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(int Id)
        {
            try
            {
                var product = _context.Tbl_Products.Find(Id);
                if (product == null)
                {
                    var result1 = new ResultDto
                    {
                        IsSuccess = false,
                        Message = "متاسفانه محصول مورد نظر یافت نشد !"
                    };
                    return result1;
                }
                product.IsRemoved = true;
                product.RemoveTime = DateTime.Now;
                _context.SaveChanges();

                var result = new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول مورد نظر با موفقیت حذف شد !"
                };
                return result;
            }
            catch
            {
                var result2 = new ResultDto
                {
                    IsSuccess = false,
                    Message = "متاسفانه محصول مورد نظر یافت نشد !"
                };
                return result2;
            }

        }
    }
}
