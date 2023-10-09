using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class VoucherService : IVoucherService
    {

        public MyDbContext _dbContext;

        public VoucherService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public async Task<Response> AddItem(VoucherModel item)
        {
            try
            {
                var voucher = new VoucherModel()
                {
                    VoucherStatusId = item.VoucherStatusId,
                    VoucherTypeId = item.VoucherTypeId,
                    Code = item.Code,
                    Quantity = item.Quantity,
                    Value = item.Value,
                    Create_Date = item.Create_Date,
                    End_Date = item.End_Date,
                    Start_Date = item.Start_Date,
                    Minimum_order_value = item.Minimum_order_value,
                };
                await _dbContext.VoucherModel.AddAsync(voucher);
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
                var item = await _dbContext.VoucherModel.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<VoucherModel>> GetAllItems()
        {
            return await _dbContext.VoucherModel.ToListAsync();

        }

        public async Task<VoucherModel> GetItem(Guid id)
        {
            return await _dbContext.VoucherModel.FindAsync(id);

        }

        public async  Task<Response> UpdateItem(VoucherModel item)
        {
            try
            {
                var voucher = await _dbContext.VoucherModel.FirstOrDefaultAsync(c => c.Id == item.Id);
                voucher.VoucherStatusId = item.VoucherStatusId;
                voucher.VoucherTypeId = item.VoucherTypeId;
                voucher.Code = item.Code;
                voucher.Quantity = item.Quantity;
                voucher.Value = item.Value;
                voucher.Create_Date = item.Create_Date;
                voucher.End_Date = item.End_Date;
                voucher.Start_Date = item.Start_Date;
                voucher.Minimum_order_value = item.Minimum_order_value;
                _dbContext.VoucherModel.Update(voucher);
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
