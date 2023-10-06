using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IPostService
    {
        Task<List<PostModel>> GetAllItems();
        Task<PostModel> GetItem(Guid id);
        Task<Response> AddItem(PostModel item);
        Task<Response> UpdateItem(PostModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
