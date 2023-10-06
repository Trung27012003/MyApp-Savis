using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IVoucherService
    {
        Task<List<VoucherModel>> GetAllItems();
        Task<VoucherModel> GetItem(Guid id);
        Task<Response> AddItem(VoucherModel item);
        Task<Response> UpdateItem(VoucherModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
