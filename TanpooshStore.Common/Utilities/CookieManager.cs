using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanpooshStore.Common.Utilities
{
    public class CookieManager
    {
        private CookieOptions getCookieOptions(HttpContext context)
        {
            var options = new CookieOptions
            {
                HttpOnly = true,
                Secure = context.Request.IsHttps,
                Path = context.Request.PathBase.HasValue ? context.Request.PathBase.ToString() : "/",
                Expires = DateTime.Now.AddDays(5)
            };
            return options;
        }

        public void Add(HttpContext context, string token, string value)
        {
            context.Response.Cookies.Append(token, value, getCookieOptions(context));
        }

        public bool Contains(HttpContext context, string token)
        {
            var result = context.Request.Cookies.ContainsKey(token);
            return result;
        }

        public string GetValue(HttpContext context, string token)
        {
            string cookieValue;
            if (!context.Request.Cookies.TryGetValue(token, out cookieValue))
            {
                return null;
            }
            return cookieValue;
        }

        public Guid GetBrowserId(HttpContext context)
        {
            string browserId = GetValue(context, "BrowserId");
            if (browserId == null)
            {
                string value = Guid.NewGuid().ToString();
                Add(context, "BrowserId", value);
                browserId = value;
            }
            Guid guidBrowser;
            Guid.TryParse(browserId, out guidBrowser);
            return guidBrowser;
        }

        public void Remove(HttpContext context, string token)
        {
            if (context.Request.Cookies.ContainsKey(token))
            {
                context.Response.Cookies.Delete(token);
            }
        }
    }
}
