using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface ICartItemService
    {
        Task<List<CartItemModel>> GetAllItems();
        Task<CartItemModel> GetItem(Guid id);
        Task<Response> AddItem(CartItemModel item);
        Task<Response> UpdateItem(CartItemModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
