using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IVoucherProductService
    {
        Task<List<VoucherProductModel>> GetAllItems();
        Task<VoucherProductModel> GetItem(Guid id);
        Task<Response> AddItem(VoucherProductModel item);
        Task<Response> UpdateItem(VoucherProductModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
