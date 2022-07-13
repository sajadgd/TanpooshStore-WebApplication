using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Users.Qureies.Dto;
using TanpooshStore.Common;

namespace TanpooshStore.Application.Services.Users.Qureies.GetUser
{
    public class GetUserService : IGetUserService
    {
        private readonly IDatabaseContext _context;
        public GetUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public GetUserResultDto Execute(GetUserRequestDto request)
        {
            var users = _context.Tbl_Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) || p.Email.Contains(request.SearchKey));
            }
            int rowCount = 0;
            var result = users.ToPaged(request.Page, 20, out rowCount).Select(s => new GetUserDto
            {
                Id = s.Id,
                FullName = s.FullName,
                Email = s.Email,
                IsActive= s.IsActive
            }).ToList();
            return new GetUserResultDto
            {
                Users = result,
                Rows = rowCount
            };
        }
    }
}
