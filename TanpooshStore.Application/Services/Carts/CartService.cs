using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Carts.Dto;
using TanpooshStore.Common.Dto;
using TanpooshStore.Domain.Entities.Carts;

namespace TanpooshStore.Application.Services.Carts
{
    public class CartService : ICartService
    {
        private readonly IDatabaseContext _context;
        public CartService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto AddToCart(int productId, Guid browserId)
        {
            var cart = _context.Tbl_Cart.Where(p => p.BrowserId == browserId && p.Finished == false).FirstOrDefault();
            if (cart == null)
            {
                CartEntity cartEntity = new CartEntity
                {
                    Finished = false,
                    BrowserId = browserId,
                    InsertTime = DateTime.Now,
                };
                _context.Tbl_Cart.Add(cartEntity);
                _context.SaveChanges();
                cart = cartEntity;
            }

            var product = _context.Tbl_Products.Find(productId);
            var cartItem = _context.Tbl_CartItem.Where(p => p.ProductId == productId && p.CartId == cart.Id).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Count++;
            }
            else
            {
                CartItemEntity cartItemEntity = new CartItemEntity
                {
                    Cart = cart,
                    Price = product.Price,
                    Product = product,
                    Count = 1,
                    InsertTime = DateTime.Now,
                };
                _context.Tbl_CartItem.Add(cartItemEntity);
                _context.SaveChanges();
            }

            var result = new ResultDto
            {
                IsSuccess = true,
                Message = $"محصول {product.Name} با موفقیت به سبد خرید شما اضافه شد ."
            };
            return result;
        }

        public ResultDto DecreaseCount(int cartItemId)
        {
            var cartItem = _context.Tbl_CartItem.Find(cartItemId);
            if (cartItem.Count <= 1)
            {
                var result1 = new ResultDto
                {
                    IsSuccess = false,
                    Message = ""
                };
                return result1;
            }
            cartItem.Count--;
            _context.SaveChanges();
            var result = new ResultDto
            {
                IsSuccess = true,
                Message = ""
            };
            return result;
        }

        public ResultDto<CartDto> GetMyCart(Guid browserId)
        {
            var cart = _context.Tbl_Cart
                .Include(p => p.CartItem).
                ThenInclude(p => p.Product).
                ThenInclude(p => p.ProductImages).
                Where(p => p.BrowserId == browserId && p.Finished == false)
                .FirstOrDefault();

            if (cart == null)
            {
                var result1 = new ResultDto<CartDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ""
                };
                return result1;
            }

            var cartData = new CartDto
            {
                CartItems = cart.CartItem.Select(c => new CartItemDto
                {
                    Id = c.Id,
                    ProductId = c.ProductId,
                    ProductCount = c.Count,
                    ProductName = c.Product.Name,
                    ProductImage = c.Product.ProductImages.FirstOrDefault().Src,
                    ProductPrice = c.Price
                }).ToList()
            };

            var result = new ResultDto<CartDto>
            {
                Data = cartData,
                IsSuccess = true,
                Message = ""
            };
            return result;
        }

        public ResultDto IncreaseCount(int cartItemId)
        {
            var cartItem = _context.Tbl_CartItem.Find(cartItemId);
            cartItem.Count++;
            _context.SaveChanges();
            var result = new ResultDto
            {
                IsSuccess = true,
                Message = ""
            };
            return result;
        }

        public ResultDto RemoveFromCart(int productId, Guid browserId)
        {
            var cartItem = _context.Tbl_CartItem.Where(p => p.Cart.BrowserId == browserId && p.ProductId == productId).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.IsRemoved = true;
                cartItem.RemoveTime = DateTime.Now;
                _context.SaveChanges();
                var result = new ResultDto
                {
                    IsSuccess = true,
                    Message = $"محصول مورد نظر از سبد خرید شما حذف شد !"
                };
                return result;
            }
            else
            {
                var result1 = new ResultDto
                {
                    IsSuccess = false,
                    Message = $"عملیات حذف با خطا مواجه شد !"
                };
                return result1;
            }
        }
    }
}
