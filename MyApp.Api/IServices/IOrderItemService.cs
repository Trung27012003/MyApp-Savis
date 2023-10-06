using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IOrderItemService
    {
        Task<List<OrderItemModel>> GetAllItems();
        Task<OrderItemModel> GetItem(Guid id);
        Task<Response> AddItem(OrderItemModel item);
        Task<Response> UpdateItem(OrderItemModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
