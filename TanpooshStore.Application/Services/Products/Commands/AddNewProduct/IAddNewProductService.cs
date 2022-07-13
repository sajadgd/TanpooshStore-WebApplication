using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Products.Commands.AddNewProduct.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Products.Commands.AddNewProduct
{
    public interface IAddNewProductService
    {
        ResultDto Execute(AddNewProductRequestDto request);
    }
}
