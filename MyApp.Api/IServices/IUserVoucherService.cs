using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IUserVoucherService
    {
        Task<List<UserVoucherModel>> GetAllItems();
        Task<UserVoucherModel> GetItem(Guid id);
        Task<Response> AddItem(UserVoucherModel item);
        Task<Response> UpdateItem(UserVoucherModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
