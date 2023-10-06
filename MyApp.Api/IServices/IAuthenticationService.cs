using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IAuthenticationService
    {
        public Task<Response> Login(LoginViewModel model);
        public Task<Response> Register(RegisterViewModel model);
        public Task Logout();
    }
}
