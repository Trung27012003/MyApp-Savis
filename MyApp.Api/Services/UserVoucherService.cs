using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class UserVoucherService : IUserVoucherService
    {
        public MyDbContext _dbContext;

        public UserVoucherService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public async Task<Response> AddItem(UserVoucherModel item)
        {
            try
            {
                var uservoucher = new UserVoucherModel()
                {
                    UserId = item.UserId,
                    VoucherId = item.VoucherId,
                    Status = item.Status,
                };
                await _dbContext.UserVouche.AddAsync(uservoucher);
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
                var item = await _dbContext.UserVouche.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<UserVoucherModel>> GetAllItems()
        {
            return await _dbContext.UserVouche.ToListAsync();

        }

        public async Task<UserVoucherModel> GetItem(Guid id)
        {
            return await _dbContext.UserVouche.FindAsync(id);

        }

        public async Task<Response> UpdateItem(UserVoucherModel item)
        {
            try
            {
                var userVoucher = await _dbContext.UserVouche.FirstOrDefaultAsync(c => c.Id == item.Id);
                userVoucher.UserId = item.UserId;
                userVoucher.VoucherId = item.VoucherId;
                userVoucher.Status = item.Status;

                _dbContext.UserVouche.Update(userVoucher);
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
