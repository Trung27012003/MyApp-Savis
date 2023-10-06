using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.IServices
{
    public interface IColorService
    {
        Task<List<ColorModel>> GetAllItems();
        Task<ColorModel> GetItem(Guid id);
        Task<Response> AddItem(ColorModel item);
        Task<Response> UpdateItem(ColorModel item);
        Task<Response> DeleteItem(Guid id);
    }
}
