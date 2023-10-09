using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class ProductService : IProductService
    {
        public MyDbContext _dbContext;

        public ProductService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public async Task<Response> AddItem(ProductModel item)
        {
            try
            {
                var product = new ProductModel()
                {
                    CategoryId = item.CategoryId,
                    ProductName = item.ProductName,
                    AvailableQuantity = item.AvailableQuantity,
                    Create_At = item.Create_At,
                    Update_At = item.Update_At,
                    Status = item.Status,
                    Long_Description = item.Long_Description,
                    Description = item.Description,
                };
                await _dbContext.Products.AddAsync(product);
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
                var item = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<ProductModel>> GetAllItems()
        {
            return await _dbContext.Products.ToListAsync();

        }

        public async Task<ProductModel> GetItem(Guid id)
        {
            return await _dbContext.Products.FindAsync(id);

        }

        public async Task<Response> UpdateItem(ProductModel item)
        {
            try
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == item.Id);

                product.CategoryId = item.CategoryId;
                product.ProductName = item.ProductName;
                product.AvailableQuantity = item.AvailableQuantity;
                product.Create_At = item.Create_At;
                product.Update_At = item.Update_At;
                product.Status = item.Status;
                product.Long_Description = item.Long_Description;
                product.Description = item.Description;

                _dbContext.Products.Update(product);
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
