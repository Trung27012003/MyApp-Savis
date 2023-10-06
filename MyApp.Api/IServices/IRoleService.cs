using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IRoleService
    {
        Task<List<RoleModel>> GetAllItems();
        Task<RoleModel> GetItem(Guid id);
        Task<Response> AddItem(RoleModel item);
        Task<Response> UpdateItem(RoleModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
