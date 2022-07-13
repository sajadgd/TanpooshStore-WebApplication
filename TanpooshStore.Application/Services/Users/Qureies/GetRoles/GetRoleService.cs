using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Users.Qureies.Dto;
using TanpooshStore.Common.Dto;

namespace TanpooshStore.Application.Services.Users.Qureies.GetRoles
{
    public class GetRoleService : IGetRoleService
    {
        private readonly IDatabaseContext _context;
        public GetRoleService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetRoleDto>> Execute()
        {
            var roles = _context.Tbl_Role.Select(s => new GetRoleDto
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
            var result = new ResultDto<List<GetRoleDto>>
            {
                Data = roles,
                IsSuccess = true,
                Message = ""
            };
            return result;
        }
    }
}
