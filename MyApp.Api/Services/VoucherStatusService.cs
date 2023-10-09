using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class VoucherStatusService : IVoucherStatusService
    {
        public MyDbContext _dbContext;

        public VoucherStatusService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public async Task<Response> AddItem(VoucherStatusModel item)
        {

            try
            {
                var voucherStatus = new VoucherStatusModel()
                {
                    Name = item.Name,
                };
                await _dbContext.VoucherStatus.AddAsync(voucherStatus);
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
                var item = await _dbContext.VoucherStatus.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<VoucherStatusModel>> GetAllItems()
        {
            return await _dbContext.VoucherStatus.ToListAsync();

        }

        public async Task<VoucherStatusModel> GetItem(Guid id)
        {
            return await _dbContext.VoucherStatus.FindAsync(id);

        }

        public async Task<Response> UpdateItem(VoucherStatusModel item)
        {
            try
            {
                var voucherStatus = await _dbContext.VoucherStatus.FirstOrDefaultAsync(c => c.Id == item.Id);

                voucherStatus.Name = item.Name;
                _dbContext.VoucherStatus.Update(voucherStatus);
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
