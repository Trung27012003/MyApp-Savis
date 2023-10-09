using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class CartService : ICartService
    {
        public MyDbContext _dbContext;

        public CartService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public async Task<Response> AddItem(CartModel item)
        {
            try
            {
                var cart = new CartModel()
                {
                    UserId = item.UserId,
                };
                await _dbContext.Cart.AddAsync(cart);
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
                var item = await _dbContext.Cart.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<CartModel>> GetAllItems()
        {
            return await _dbContext.Cart.ToListAsync();

        } 
         public async Task<CartModel> GetItem(Guid id)
        {
            return await _dbContext.Cart.FindAsync(id);

        }

        public async Task<Response> UpdateItem(CartModel item)
        {
            try
            {
                var cart = await _dbContext.Cart.FirstOrDefaultAsync(c => c.Id == item.Id);

               cart.UserId = item.UserId;
                _dbContext.Cart.Update(cart);
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
