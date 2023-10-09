using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class OrderStatusService: IOrderStatusService
    {
        public MyDbContext _dbContext;

        public OrderStatusService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }

        public async Task<Response> AddItem(OrderStatusModel item)
        {
            try
            {
                var orderStatus = new OrderStatusModel()
                {
                    OrderStatusName = item.OrderStatusName,

                };
                await _dbContext.OrderStatus.AddAsync(orderStatus);
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
                var item = await _dbContext.OrderStatus.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<OrderStatusModel>> GetAllItems()
        {
            return await _dbContext.OrderStatus.ToListAsync();
        }

        public async Task<OrderStatusModel> GetItem(Guid id)
        {
            return await _dbContext.OrderStatus.FindAsync(id);
        }

        public async Task<Response> UpdateItem(OrderStatusModel item)
        {
            try
            {
                var orderStatus = await _dbContext.OrderStatus.FirstOrDefaultAsync(c => c.Id == item.Id);

                orderStatus.OrderStatusName = item.OrderStatusName;
                _dbContext.OrderStatus.Update(orderStatus);
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
