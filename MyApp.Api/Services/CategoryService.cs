using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class CategoryService : ICategoryService
    {
        public MyDbContext _dbContext;

        public CategoryService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public async Task<Response> AddItem(CategoryModel item)
        {
            try
            {
                var category = new CategoryModel()
                {
                    CategoryName = item.CategoryName,
                };
                await _dbContext.Category.AddAsync(category);
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
                var item = await _dbContext.Category.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<CategoryModel>> GetAllItems()
        {
            return await _dbContext.Category.ToListAsync();

        }

        public async Task<CategoryModel> GetItem(Guid id)
        {
            return await _dbContext.Category.FindAsync(id);

        }

        public async Task<Response> UpdateItem(CategoryModel item)
        {
            try
            {
                var category = await _dbContext.Category.FirstOrDefaultAsync(c => c.Id == item.Id);

                category.CategoryName = item.CategoryName;
                _dbContext.Category.Update(category);
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
