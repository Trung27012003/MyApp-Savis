using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class OrderService : IOrderService
    {
        public MyDbContext _dbContext;

        public OrderService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }

        public async Task<Response> AddItem(OrderModel item)
        {
            try
            {
                var order = new OrderModel()
                {
                    UserId = item.UserId,
                    PaymentId = item.PaymentId,
                    OrderStatusId = item.OrderStatusId,
                    VoucherId = item.VoucherId,
                    OrderCode = item.OrderCode,
                    RecipientAddress = item.RecipientAddress,
                    RecipientName = item.RecipientName,
                    RecipientPhone = item.RecipientPhone,
                    TotalAmout = item.TotalAmout,
                    VoucherValue = item.VoucherValue,
                    Payment_Date = item.Payment_Date,
                    Delivery_Date = item.Delivery_Date,
                    Create_Date = item.Create_Date,
                    ShippingFee = item.ShippingFee,
                    Ship_Date = item.Ship_Date,
                    Description = item.Description,
                    TotalAmoutAfterApplyingVoucher = item.TotalAmoutAfterApplyingVoucher,


                };
                await _dbContext.Order.AddAsync(order);
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
                var item = await _dbContext.Order.FirstOrDefaultAsync(c => c.Id == id);
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

            public async Task<List<OrderModel>> GetAllItems()
        {
            return await _dbContext.Order.ToListAsync();
        }

        public async Task<OrderModel> GetItem(Guid id)
        {
            return await _dbContext.Order.FindAsync(id);
        }

        public async Task<Response> UpdateItem(OrderModel item)
        {
            try
            {
                var order = await _dbContext.Order.FirstOrDefaultAsync(c => c.Id == item.Id);

                order.UserId = item.UserId;
                      order.PaymentId = item.PaymentId;
                      order.OrderStatusId = item.OrderStatusId;
                      order.VoucherId = item.VoucherId;
                      order.OrderCode = item.OrderCode;
                     order.RecipientAddress = item.RecipientAddress;
                      order.RecipientName = item.RecipientName;
                      order.RecipientPhone = item.RecipientPhone;
                      order.TotalAmout = item.TotalAmout;
                      order.VoucherValue = item.VoucherValue;
                      order.Payment_Date = item.Payment_Date;
                     order.Delivery_Date = item.Delivery_Date;
                    order.Create_Date = item.Create_Date;
                    order.ShippingFee = item.ShippingFee;
                    order.Ship_Date = item.Ship_Date;
                     order.Description = item.Description;
                     order.TotalAmoutAfterApplyingVoucher = item.TotalAmoutAfterApplyingVoucher;

                _dbContext.Order.Update(order);
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
