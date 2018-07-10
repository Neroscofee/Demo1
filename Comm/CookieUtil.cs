using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Comm
{
    public static class CookieUtil
    {
        public static void SetCookie(string name,string value,DateTime time,string domain)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (!string.IsNullOrEmpty(domain))
            {
                response.Cookies[name].Domain = domain;
            }
            response.Cookies[name].Value = value;
            response.Cookies[name].Expires = time;
        }

        public static void RemoveCookie(string name,string domain)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Value = null;
            cookie.Domain = domain;
            cookie.Expires = DateTime.Now.AddDays(-30);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static string GetCookieValue(string cookieName)
        {
            string value = string.Empty;
            HttpCookieCollection cookies = HttpContext.Current.Request.Cookies;
            if (cookies !=null && cookies.AllKeys.Contains(cookieName))
            {
                value = cookies.Get(cookieName).Value;
            }
            return value;
        }


    }
}
