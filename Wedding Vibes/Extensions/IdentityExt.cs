using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wedding_Vibes.Services
{
    public static class IdentityExt
    {
        public static Task<T> GetCurrentUser<T>(this UserManager<T> manager, HttpContext httpContext) where T : class
        {
            return manager.GetUserAsync(httpContext.User);
        }
    }
}
