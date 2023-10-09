using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class CartItemService : ICartItemService
    {
        public MyDbContext _dbContext;
        public CartItemService(MyDbContext myDbContext) {
            _dbContext = myDbContext;
        }

        public async Task<Response> AddItem(CartItemModel item)
        {
            try
            {
                var cartItemModel = new CartItemModel()
                {
                    CartId = item.CartId,
                    ProductDetail_ID = item.ProductDetail_ID,
                    Quantity = item.Quantity,
                    Price = item.Price,
                };
                await _dbContext.CartItems.AddAsync(cartItemModel);
                await _dbContext.SaveChangesAsync();
                return new Response { IsSuccess = true, Messages = "Item Added Successfully" };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Response { IsSuccess = false, Messages = "Item Don't Successfully" };

            }
        }

        public async Task<Response> DeleteItem(Guid id)
        {
            try
            {
                var item = await _dbContext.CartItems.FirstOrDefaultAsync(c => c.Id == id);
                _dbContext.Remove(item);
                await _dbContext.SaveChangesAsync();
                return new Response { IsSuccess = true, Messages = "Item Added Successfully" };


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return new Response { IsSuccess = false, Messages = "Item Don't Successfully" };

            }
        }

        public async Task<List<CartItemModel>> GetAllItems()
        {
            return await _dbContext.CartItems.ToListAsync();
        }

        public async Task<CartItemModel> GetItem(Guid id)
        {
            return await _dbContext.CartItems.FindAsync(id);

        } 
            public async Task<Response> UpdateItem(CartItemModel item)
        {
            try
            {
                var cart = await _dbContext.CartItems.FirstOrDefaultAsync(c => c.Id == item.Id);
                      cart.CartId = item.CartId;
                      cart.ProductDetail_ID = item.ProductDetail_ID;
                      cart.Quantity = item.Quantity;
                      cart.Price = item.Price;
                _dbContext.CartItems.Update(cart);
                await _dbContext.SaveChangesAsync();
                return new Response { IsSuccess = true, Messages = "Item Added Successfully" };

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return new Response { IsSuccess = false, Messages = "Item Don't Successfully" };

            }
        }
    }
}
