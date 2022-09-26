using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Services.Carts.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Carts
{
    public interface ICartService
    {
        ResultDto AddToCart(int productId, Guid browserId);
        ResultDto RemoveFromCart(int productId, Guid browserId);
        ResultDto<CartDto> GetMyCart(Guid browserId, int? userId);
        ResultDto IncreaseCount(int cartItemId);
        ResultDto DecreaseCount(int cartItemId);
    }
}
