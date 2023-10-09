using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class VoucherTypeService : IVoucherTypeService
    {
        public MyDbContext _dbContext;

        public VoucherTypeService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public async Task<Response> AddItem(VoucherTypeModel item)
        {
            try
            {
                var voucherType = new VoucherTypeModel()
                {
                    Name = item.Name,
                };
                await _dbContext.VoucherType.AddAsync(voucherType);
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
                var item = await _dbContext.VoucherType.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<VoucherTypeModel>> GetAllItems()
        {
            return await _dbContext.VoucherType.ToListAsync();

        }

        public async Task<VoucherTypeModel> GetItem(Guid id)
        {
            return await _dbContext.VoucherType.FindAsync(id);

        }

        public async Task<Response> UpdateItem(VoucherTypeModel item)
        {
            try
            {
                var voucherType = await _dbContext.VoucherType.FirstOrDefaultAsync(c => c.Id == item.Id);

                voucherType.Name = item.Name;
                _dbContext.VoucherType.Update(voucherType);
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
