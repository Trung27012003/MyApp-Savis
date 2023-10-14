using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllItems();
        Task<UserModel> GetItem(Guid id);
        Task<Response> AddItem(UserViewModel item);
        Task<Response> UpdateItem(Guid userId, UserModel item);
        Task<Response> DeleteItem(Guid id);
        Task<Response> ChangePassword(Guid id, string password);
    }
}
