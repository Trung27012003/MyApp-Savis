using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IVoucherStatusService
    {
        Task<List<VoucherStatusModel>> GetAllItems();
        Task<VoucherStatusModel> GetItem(Guid id);
        Task<Response> AddItem(VoucherStatusModel item);
        Task<Response> UpdateItem(VoucherStatusModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
