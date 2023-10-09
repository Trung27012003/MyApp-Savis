using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class RoleService : IRoleService
    {
        public MyDbContext _dbContext;

        public RoleService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        public  async   Task<Response> AddItem(RoleModel item)
        {
            try
            {
                var role = new RoleModel()
                {
                    Name = item.Name,
                    NormalizedName = item.NormalizedName,
                };
                await _dbContext.Roles.AddAsync(role);
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
                var item = await _dbContext.Roles.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<RoleModel>> GetAllItems()
        {
            return await _dbContext.Roles.ToListAsync();

        }

        public async Task<RoleModel> GetItem(Guid id)
        {
            return await _dbContext.Roles.FindAsync(id);

        }

        public async Task<Response> UpdateItem(RoleModel item)
        {
            try
            {
                var role = await _dbContext.Roles.FirstOrDefaultAsync(c => c.Id == item.Id);
                role.Name = item.Name;
                role.NormalizedName = item.NormalizedName;
                _dbContext.Roles.Update(role);
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
