using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IProductDetailService
    {
        Task<List<ProductDetailModel>> GetAllItems();
        Task<ProductDetailModel> GetItem(Guid id);
        Task<Response> AddItem(ProductDetailModel item);
        Task<Response> UpdateItem(ProductDetailModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
