using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Common.Utilities
{
    public static class ClaimsUtility
    {
        public static int? GetUserId(ClaimsPrincipal user)
        {
            try
            {
                var claimsIdentity = user.Identity as ClaimsIdentity;
                int userId = int.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                return userId;
            }
            catch
            {
                return null;
            }
        }
    }
}
