using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IOrderService
    {
        Task<List<OrderModel>> GetAllItems();
        Task<OrderModel> GetItem(Guid id);
        Task<Response> AddItem(OrderModel item);
        Task<Response> UpdateItem(OrderModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
