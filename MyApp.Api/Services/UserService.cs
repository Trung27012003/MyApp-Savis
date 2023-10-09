using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class UserService: IUserService
    {
        public MyDbContext _dbContext;

        public UserService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }

        public async Task<Response> AddItem(UserModel item)
        {
            try
            {
                var user = new UserModel()
                {
                    FullName = item.FullName,
                    Address = item.Address,
                    ProfilePictureUrl = item.ProfilePictureUrl,
                    Points = item.Points,

                    DateOfBirth = item.DateOfBirth,
                };
                await _dbContext.Users.AddAsync(user);
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
                var item = await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<UserModel>> GetAllItems()
        {
            return await _dbContext.Users.ToListAsync();

        }

        public async Task<UserModel> GetItem(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);

        }

        public async Task<Response> UpdateItem(UserModel item)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == item.Id);
                user.Address = item.Address;
                user.FullName = item.FullName;
                user.ProfilePictureUrl = item.ProfilePictureUrl;
                user.Points = item.Points;
                user.DateOfBirth = item.DateOfBirth;

                _dbContext.Users.Update(user);
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
