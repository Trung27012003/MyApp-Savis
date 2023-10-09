using MyApp.Api.IServices;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class AuthencationService : IAuthenticationService
    {
        public Task<Response> Login(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task<Response> Register(RegisterViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
