using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetAllItems();
        Task<CategoryModel> GetItem(Guid id);
        Task<Response> AddItem(CategoryModel item);
        Task<Response> UpdateItem(CategoryModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
