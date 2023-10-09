using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class ProductDetailService: IProductDetailService
    {
        public MyDbContext _dbContext;

        public ProductDetailService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }

        public async Task<Response> AddItem(ProductDetailModel item)
        {
            try
            {
                var productDetailModel = new ProductDetailModel()
                {
                    ProductId = item.ProductId,
                    ColorId = item.ColorId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    PriceSale = item.PriceSale,
                    Create_At = item.Create_At,
                    Update_At = item.Update_At,
                    Description = item.Description,
                    Status = item.Status,

                };
                await _dbContext.ProductDetails.AddAsync(productDetailModel);
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
                var item = await _dbContext.ProductDetails.FirstOrDefaultAsync(c => c.Id == id);
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
            public async Task<List<ProductDetailModel>> GetAllItems()
        {
            return await _dbContext.ProductDetails.ToListAsync();
        }

        public async Task<ProductDetailModel> GetItem(Guid id)
        {
            return await _dbContext.ProductDetails.FindAsync(id);
        }

        public async Task<Response> UpdateItem(ProductDetailModel item)
        {
            try
            {
                var productDetail = await _dbContext.ProductDetails.FirstOrDefaultAsync(c => c.Id == item.Id);

                productDetail.ColorId = item.ColorId;
                productDetail.ProductId = item.ProductId;
                    productDetail.Quantity = item.Quantity;
                productDetail.Price = item.Price;
                productDetail.PriceSale = item.PriceSale;
                productDetail.Create_At = item.Create_At;
                productDetail.Update_At = item.Update_At;
                productDetail.Description = item.Description;
                productDetail.Status = item.Status;
                _dbContext.ProductDetails.Update(productDetail);
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
