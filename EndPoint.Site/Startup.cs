using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TanpooshStore.Application;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Carts;
using TanpooshStore.Application.Services.Common.Queries.GetMenuItem;
using TanpooshStore.Application.Services.Finances.FacadPattern;
using TanpooshStore.Application.Services.HomePages.FacadPattern;
using TanpooshStore.Application.Services.Order.FacadPattern;
using TanpooshStore.Application.Services.Products.Commands.AddNewProduct.Dto;
using TanpooshStore.Application.Services.Products.Commands.EditProduct;
using TanpooshStore.Application.Services.Products.FacadPattern;
using TanpooshStore.Application.Services.Users.Commands.UserRegister.Dto;
using TanpooshStore.Application.Services.Users.FacadPattern;
using TanpooshStore.Application.Validators;
using TanpooshStore.Common.Roles;
using TanpooshStore.Presistence.Context;

namespace EndPoint.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
                options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
                options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/LoginRegister");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(0.5);
            });
            services.AddScoped<IDatabaseContext, DatabaseContext>();

            // UserFacadInject
            services.AddScoped<IUserFacad, UserFacad>();

            // ProductFacadInject
            services.AddScoped<IProductFacad, ProductFacad>();

            // Common Inject
            services.AddScoped<IGetMenuItemService, GetMenuItemService>();

            // HomePage Inject
            services.AddScoped<IHomePageFacad, HomePageFacad>();

            // Cart Inject
            services.AddScoped<ICartService, CartService>();

            // Finances Inject
            services.AddScoped<IFinancesFacad, FinancesFacad>();

            // Order Inject
            services.AddScoped<IOrderFacad, OrderFacad>();

            services.AddEntityFrameworkSqlServer().AddDbContext<DatabaseContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("TanpooshStoreConnection")));
            services.AddControllersWithViews().AddFluentValidation();
            services.AddTransient<IValidator<RegisterRequestDto>, RegisterRequestValidator>();
            services.AddTransient<IValidator<AddNewProductRequestDto>, AddNewProductRequestValidator>();
            services.AddTransient<IValidator<EditProductRequestDto>, EditProductRequestValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
