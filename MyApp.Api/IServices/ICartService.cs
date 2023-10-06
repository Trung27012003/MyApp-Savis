using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface ICartService
    {
        Task<List<CartModel>> GetAllItems();
        Task<CartModel> GetItem(Guid id);
        Task<Response> AddItem(CartModel item);
        Task<Response> UpdateItem(CartModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
