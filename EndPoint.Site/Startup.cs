using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TanpooshStore.Presistence.Context;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Users.Qureies.GetUser;
using TanpooshStore.Application.Services.Users.Qureies.GetRoles;
using TanpooshStore.Application.Services.Users.Commands.UserRegister;
using TanpooshStore.Application.Services.Users.Commands.UserRemove;
using TanpooshStore.Application.Services.Users.Commands.UserChangeStatus;
using TanpooshStore.Application.Services.Users.Commands.UserEdit;
using FluentValidation.AspNetCore;
using FluentValidation;
using TanpooshStore.Application.Services.Users.Commands.UserRegister.Dto;
using TanpooshStore.Application;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using TanpooshStore.Application.Services.Users.Commands.UserLogin;
using TanpooshStore.Application.Interfaces.FacadPatterns;
using TanpooshStore.Application.Services.Products.FacadPattern;
using TanpooshStore.Application.Validators;
using TanpooshStore.Application.Services.Products.Commands.AddNewProduct.Dto;
using TanpooshStore.Application.Services.Products.Commands.EditProduct;
using TanpooshStore.Application.Services.Common.Queries.GetMenuItem;

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
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(0.5);
            });
            services.AddScoped<IDatabaseContext, DatabaseContext>();
            services.AddScoped<IGetUserService, GetUserService>();
            services.AddScoped<IGetRoleService, GetRoleService>();
            services.AddScoped<IRegisterUserService, RegisterUserService>();
            services.AddScoped<ILoginUserService, LoginUserService>();
            services.AddScoped<IRemoveUserService, RemoveUserService>();
            services.AddScoped<IChangeStatusUserService, ChangeStatusUserService>();
            services.AddScoped<IEditUserService, EditUserService>();

            // FacadInjects
            services.AddScoped<IProductFacad, ProductFacad>();

            // Common Inject
            services.AddScoped<IGetMenuItemService, GetMenuItemService>();

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

            app.UseAuthorization();
            app.UseAuthentication();

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
