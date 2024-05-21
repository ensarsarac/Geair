using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.ViewModels
{
    public class GetUserService : IGetUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public GetUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public int GetUserId()
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = Convert.ToInt32(userId);
            return result;
        }
    }
}
