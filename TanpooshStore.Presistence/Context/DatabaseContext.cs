using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Common.Roles;
using TanpooshStore.Domain.Entities.Carts;
using TanpooshStore.Domain.Entities.HomePages;
using TanpooshStore.Domain.Entities.Order;
using TanpooshStore.Domain.Entities.Product;
using TanpooshStore.Domain.Entities.RequestPay;
using TanpooshStore.Domain.Entities.Users;

namespace TanpooshStore.Presistence.Context
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserEntity> Tbl_Users { get; set; }
        public DbSet<RoleEntity> Tbl_Role { get; set; }
        public DbSet<UserInRoleEntity> Tbl_UserInRole { get; set; }
        public DbSet<CategoryEntity> Tbl_Category { get; set; }
        public DbSet<ProductEntity> Tbl_Products { get; set; }
        public DbSet<ProductImageEntity> Tbl_ProductImages { get; set; }
        public DbSet<ProductFeaturesEntity> Tbl_ProductFeatures { get; set; }
        public DbSet<SliderEntity> Tbl_Slider { get; set; }
        public DbSet<CartEntity> Tbl_Cart { get; set; }
        public DbSet<CartItemEntity> Tbl_CartItem { get; set; }
        public DbSet<RequestPayEntity> Tbl_RequestPay { get; set; }
        public DbSet<OrderEntity> Tbl_Order { get; set; }
        public DbSet<OrderDetailEntity> Tbl_OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>()
                .HasOne(p => p.User)
                .WithMany(u => u.Order)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrderEntity>()
                .HasOne(p => p.RequestPay)
                .WithMany(u => u.Order)
                .OnDelete(DeleteBehavior.NoAction);

            SeedData(modelBuilder);

            //////////////

            modelBuilder.Entity<UserEntity>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<UserEntity>().HasIndex(u => u.Mobile).IsUnique();

            //////////////
            ///
            ApplyQueryFilter(modelBuilder);
        }

        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<RoleEntity>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRoleEntity>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<CategoryEntity>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductEntity>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<SliderEntity>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<CartEntity>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<CartItemEntity>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<RequestPayEntity>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<OrderEntity>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<OrderDetailEntity>().HasQueryFilter(p => !p.IsRemoved);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleEntity>().HasData(new RoleEntity { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<RoleEntity>().HasData(new RoleEntity { Id = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<RoleEntity>().HasData(new RoleEntity { Id = 3, Name = nameof(UserRoles.Customer) });
        }
    }
}
