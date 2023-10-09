using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class VoucherProductService : IVoucherProductService
    {
        public MyDbContext _dbContext;

        public VoucherProductService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public async Task<Response> AddItem(VoucherProductModel item)
        {
            try
            {
                var voucherProduct = new VoucherProductModel()
                {
                    VoucherId = item.VoucherId,
                    ProductId = item.ProductId,
                };
                await _dbContext.VoucherProduct.AddAsync(voucherProduct);
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
                var item = await _dbContext.VoucherProduct.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<VoucherProductModel>> GetAllItems()
        {
            return await _dbContext.VoucherProduct.ToListAsync();

        }

        public async Task<VoucherProductModel> GetItem(Guid id)
        {
            return await _dbContext.VoucherProduct.FindAsync(id);

        }

        public async Task<Response> UpdateItem(VoucherProductModel item)
        {
            try
            {
                var v = await _dbContext.VoucherProduct.FirstOrDefaultAsync(c => c.Id == item.Id);
                v.VoucherId = item.VoucherId;
                v.ProductId = item.ProductId;
                _dbContext.VoucherProduct.Update(v);
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
