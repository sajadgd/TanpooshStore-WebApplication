using FluentValidation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Users.Commands.UserRegister.Dto;
using TanpooshStore.Common.Dto;
using TanpooshStore.Common.Utilities;
using TanpooshStore.Domain.Entities.Users;

namespace TanpooshStore.Application.Services.Users.Commands.UserRegister
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDatabaseContext _context;
        public RegisterUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<RegisterResultDto> Execute(RegisterRequestDto request)
        {
            try
            {
                RegisterRequestValidator validations = new RegisterRequestValidator();
                if (validations.Validate(request).IsValid)
                {

                    if (request.RePassword != request.Password)
                    {
                        var result1 = new ResultDto<RegisterResultDto>()
                        {
                            Data = new RegisterResultDto()
                            {
                                UserId = 0
                            },
                            IsSuccess = false,
                            Message = "ثبت نام کاربر با خطا مواجه شد!"
                        };
                        return result1;
                    }

                    PasswordHasher passwordHasher = new PasswordHasher();
                    var hashedPassword = passwordHasher.HashPassword(request.Password);

                    UserEntity user = new UserEntity()
                    {
                        FullName = request.FullName,
                        Email = request.Email,
                        Mobile = request.Mobile,
                        Password = hashedPassword,
                        IsActive = true
                    };
                    List<UserInRoleEntity> userInRoles = new List<UserInRoleEntity>();
                    foreach (var item in request.Roles)
                    {
                        var roles = _context.Tbl_Role.Find(item.Id);
                        userInRoles.Add(new UserInRoleEntity
                        {
                            Role = roles,
                            RoleId = roles.Id,
                            User = user,
                            UserId = user.Id
                        });
                    }
                    user.UserInRole = userInRoles;
                    user.InsertTime = DateTime.Now;
                    _context.Tbl_Users.Add(user);
                    _context.SaveChanges();
                    var result = new ResultDto<RegisterResultDto>()
                    {
                        Data = new RegisterResultDto
                        {
                            UserId = user.Id
                        },
                        IsSuccess = true,
                        Message = "ثبت نام کاربر جدید با موفقیت انجام شد!"
                    };

                    return result;
                }
                else
                {
                    var result2 = new ResultDto<RegisterResultDto>()
                    {
                        Data = new RegisterResultDto
                        {
                            UserId = 0
                        },
                        IsSuccess = false,
                        Message = "ثبت نام کاربر با خطا مواجه شد!"
                    };
                    return result2;
                }

            }
            catch (Exception)
            {
                var result = new ResultDto<RegisterResultDto>()
                {
                    Data = new RegisterResultDto
                    {
                        UserId = 0
                    },
                    IsSuccess = false,
                    Message = "ثبت نام کاربر با خطا مواجه شد!"
                };
                return result;
            }
           
        }
    }
}
