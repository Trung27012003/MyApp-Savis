using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IOrderStatusService
    {
        Task<List<OrderStatusModel>> GetAllItems();
        Task<OrderStatusModel> GetItem(Guid id);
        Task<Response> AddItem(OrderStatusModel item);
        Task<Response> UpdateItem(OrderStatusModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
