﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TanpooshStore.Domain.Entities.Carts;
using TanpooshStore.Domain.Entities.HomePages;
using TanpooshStore.Domain.Entities.Order;
using TanpooshStore.Domain.Entities.Product;
using TanpooshStore.Domain.Entities.RequestPay;
using TanpooshStore.Domain.Entities.Users;

namespace TanpooshStore.Application.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<UserEntity> Tbl_Users { get; set; }
        DbSet<RoleEntity> Tbl_Role { get; set; }
        DbSet<UserInRoleEntity> Tbl_UserInRole { get; set; }
        DbSet<CategoryEntity> Tbl_Category { get; set; }
        DbSet<ProductEntity> Tbl_Products { get; set; }
        DbSet<ProductImageEntity> Tbl_ProductImages { get; set; }
        DbSet<ProductFeaturesEntity> Tbl_ProductFeatures { get; set; }
        DbSet<SliderEntity> Tbl_Slider { get; set; }
        DbSet<CartEntity> Tbl_Cart { get; set; }
        DbSet<CartItemEntity> Tbl_CartItem { get; set; }
        DbSet<RequestPayEntity> Tbl_RequestPay { get; set; }
        DbSet<OrderEntity> Tbl_Order { get; set; }
        DbSet<OrderDetailEntity> Tbl_OrderDetail { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
