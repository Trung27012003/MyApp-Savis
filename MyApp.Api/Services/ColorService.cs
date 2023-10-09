using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class ColorService: IColorService
    {

        public MyDbContext _dbContext;

        public ColorService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }

        public async     Task<Response> AddItem(ColorModel item)
        {
            try
            {
                var color = new ColorModel()
                {
                    ColorName = item.ColorName,
                    ColorCode = item.ColorCode,
                };
                await _dbContext.Colors.AddAsync(color);
                await _dbContext.SaveChangesAsync();
                return new Response { IsSuccess = true, Messages = "Item Added Successfully" };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Response { IsSuccess = false, Messages = " Don't Successfully" };

            }
        }

        public async Task<Response> DeleteItem(Guid id)
        {
            try
            {
                var item = await _dbContext.Colors.FirstOrDefaultAsync(c => c.ColorId == id);
                _dbContext.Remove(item);
                await _dbContext.SaveChangesAsync();
                return new Response { IsSuccess = true, Messages = "Item DELETE Successfully" };


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return new Response { IsSuccess = false, Messages = " Don't Successfully" };

            }
        }

        public async Task<List<ColorModel>> GetAllItems()
        {
            return await _dbContext.Colors.ToListAsync();
        }

        public async Task<ColorModel> GetItem(Guid id)
        {
            return await _dbContext.Colors.FindAsync(id);
        }

        public async Task<Response> UpdateItem(ColorModel item)
        {
            try
            {
                var color = await _dbContext.Colors.FirstOrDefaultAsync(c => c.ColorId == item.ColorId);

                color.ColorName = item.ColorName;
                color.ColorCode = item.ColorCode;
                _dbContext.Colors.Update(color);
                await _dbContext.SaveChangesAsync();
                return new Response { IsSuccess = true, Messages = " UPDATE Successfully" };

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return new Response { IsSuccess = false, Messages = " Don't Successfully" };

            }
        }
    }
}
