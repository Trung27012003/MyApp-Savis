using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllItems();
        Task<UserModel> GetItem(Guid id);
        Task<Response> AddItem(UserModel item);
        Task<Response> UpdateItem(UserModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
