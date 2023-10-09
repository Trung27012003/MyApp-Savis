using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class ProductImageService: IProductImageService
    {
        public MyDbContext _dbContext;

        public ProductImageService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }

        public async Task<Response> AddItem(ProductImageModel item)
        {
            try
            {
                var productimage = new ProductImageModel()
                {
                    ImageUrl = item.ImageUrl,
                    ProductDetailId = item.ProductDetailId,
                };
                await _dbContext.ProductImages.AddAsync(productimage);
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
                var item = await _dbContext.ProductImages.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<ProductImageModel>> GetAllItems()
        {
            return await _dbContext.ProductImages.ToListAsync();
        }

        public async Task<ProductImageModel> GetItem(Guid id)
        {
            return await _dbContext.ProductImages.FindAsync(id);
        }

        public async Task<Response> UpdateItem(ProductImageModel item)
        {
            try
            {
                var productImage = await _dbContext.ProductImages.FirstOrDefaultAsync(c => c.Id == item.Id);

                productImage.ImageUrl = item.ImageUrl;
                productImage.ProductDetailId = item.ProductDetailId;
                _dbContext.ProductImages.Update(productImage);
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
