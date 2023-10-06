using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IVoucherTypeService
    {
        Task<List<VoucherTypeModel>> GetAllItems();
        Task<VoucherTypeModel> GetItem(Guid id);
        Task<Response> AddItem(VoucherTypeModel item);
        Task<Response> UpdateItem(VoucherTypeModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
