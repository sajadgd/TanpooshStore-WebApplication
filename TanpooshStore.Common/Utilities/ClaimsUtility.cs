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

        public static string GetUserName(ClaimsPrincipal user)
        {
            try
            {
                var claimsIdentity = user.Identity as ClaimsIdentity;
                string userName = claimsIdentity.FindFirst(ClaimTypes.Name).Value;
                return userName;
            }
            catch
            {
                return null;
            }
        }

        public static List<string> GetUserRoles(ClaimsPrincipal user)
        {
            try
            {
                var claimsIdentity = user.Identity as ClaimsIdentity;
                List<string> userRoles = new List<string>();
                foreach (var item in claimsIdentity.Claims.Where(p => p.Type.EndsWith("role")))
                {
                    userRoles.Add(item.Value);
                }
                return userRoles;
            }
            catch
            {
                return null;
            }
        }
    }
}
