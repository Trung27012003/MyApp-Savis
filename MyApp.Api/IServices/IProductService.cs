using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAllItems();
        Task<ProductModel> GetItem(Guid id);
        Task<Response> AddItem(ProductModel item);
        Task<Response> UpdateItem(ProductModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
