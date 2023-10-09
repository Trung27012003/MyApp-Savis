using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class PaymentService: IPaymentService
    {
        public MyDbContext _dbContext;

        public PaymentService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }

        public async Task<Response> AddItem(PaymentModel item)
        {
            try
            {
                var payment = new PaymentModel()
                {
                    PaymentName = item.PaymentName,
                };
                await _dbContext.Payments.AddAsync(payment);
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
                var item = await _dbContext.Payments.FirstOrDefaultAsync(c => c.Id == id);
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

            public async Task<List<PaymentModel>> GetAllItems()
        {
                return await _dbContext.Payments.ToListAsync();

            }

            public async Task<PaymentModel> GetItem(Guid id)
        {
            return await _dbContext.Payments.FindAsync(id);
        }

        public async Task<Response> UpdateItem(PaymentModel item)
        {
            try
            {
                var payment = await _dbContext.Payments.FirstOrDefaultAsync(c => c.Id == item.Id);

                payment.PaymentName = item.PaymentName;
                _dbContext.Payments.Update(payment);
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
