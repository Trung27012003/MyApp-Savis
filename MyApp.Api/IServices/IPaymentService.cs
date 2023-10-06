using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IPaymentService
    {
        Task<List<PaymentModel>> GetAllItems();
        Task<PaymentModel> GetItem(Guid id);
        Task<Response> AddItem(PaymentModel item);
        Task<Response> UpdateItem(PaymentModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
