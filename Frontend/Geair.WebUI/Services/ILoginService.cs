namespace Geair.WebUI.Services
{
	public interface ILoginService
	{
		string GetUserToken { get; }
		string GetUserId { get; }
		string GetUserRole { get; }
	}
}
