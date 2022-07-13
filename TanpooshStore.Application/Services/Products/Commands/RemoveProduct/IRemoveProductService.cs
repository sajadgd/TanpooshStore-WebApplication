using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Products.Commands.RemoveProduct
{
    public interface IRemoveProductService
    {
        ResultDto Execute(int Id);
    }
}
