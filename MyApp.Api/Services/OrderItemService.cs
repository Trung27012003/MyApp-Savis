using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class OrderItemService: IOrderItemService
    {
        public MyDbContext _dbContext;

        public OrderItemService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }

        public async Task<Response> AddItem(OrderItemModel item)
        {
            try
            {
                var orderitem = new OrderItemModel()
                {
                    OrderId = item.OrderId,
                    ProductDetailId = item.ProductDetailId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                };
                await _dbContext.OrderItem.AddAsync(orderitem);
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
                var item = await _dbContext.OrderItem.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<OrderItemModel>> GetAllItems()
        {
            return await _dbContext.OrderItem.ToListAsync();
        }

        public async Task<OrderItemModel> GetItem(Guid id)
        {
            return await _dbContext.OrderItem.FindAsync(id);
        }

        public async Task<Response> UpdateItem(OrderItemModel item)
        {
            try
            {
                var orderitem = await _dbContext.OrderItem.FirstOrDefaultAsync(c => c.Id == item.Id);

               orderitem.OrderId = item.OrderId;
                orderitem.ProductDetailId = item.ProductDetailId;
                orderitem.Quantity = item.Quantity;
                orderitem.Price = item.Price;
                _dbContext.OrderItem.Update(orderitem);
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
