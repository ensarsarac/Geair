using System.Security.Claims;

namespace Geair.WebUI.Services
{
	public class LoginService : ILoginService
	{
		private readonly IHttpContextAccessor _contextAccessor;

		public LoginService(IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
		}

		public string GetUserToken => _contextAccessor.HttpContext.User.Claims.LastOrDefault().Value;

        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
