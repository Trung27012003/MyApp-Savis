using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IProductImageService
    {
        Task<List<ProductImageModel>> GetAllItems();
        Task<ProductImageModel> GetItem(Guid id);
        Task<Response> AddItem(ProductImageModel item);
        Task<Response> UpdateItem(ProductImageModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
