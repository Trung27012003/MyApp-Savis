using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;

namespace MyApp.Api.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<UserModel> _userManager;
        public UserService(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response> AddItem(UserViewModel item)
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
                    UserName = item.UserName,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email
                };
                var result = await _userManager.CreateAsync(user, item.Password); // add account
                if (!result.Succeeded)
                {
                    return new Response
                    {
                        IsSuccess = result.Succeeded,
                        Messages  = " Don't Successfully"
                    };
                }
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
                var item = await _userManager.FindByIdAsync(id.ToString());
                if (item != null)
                {
                    await _userManager.DeleteAsync(item);
                    return new Response { IsSuccess = true, Messages = "Item DELETE Successfully" };
                }
                return new Response { IsSuccess = false, Messages = " Don't Successfully" };
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return new Response { IsSuccess = false, Messages = " Don't Successfully" };

            }
        }

        public async Task<List<UserModel>> GetAllItems()
        {
            return await _userManager.Users.ToListAsync();

        }

        public async Task<UserModel> GetItem(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());

        }
        public async Task<Response> ChangePassword(Guid id, string password)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user!=null)
            {
                var result = await _userManager.RemovePasswordAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddPasswordAsync(user, password);
                    if (result.Succeeded)
                    {
                        return new Response { IsSuccess = true, Messages = " UPDATE Successfully" };
                    }
                }
            }
            return new Response { IsSuccess = false, Messages = " Don't Successfully" };
        }
        public async Task<Response> UpdateItem(Guid userId,UserModel item)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                if (user!=null)
                {
                    user.Address = item.Address;
                    user.FullName = item.FullName;
                    user.ProfilePictureUrl = item.ProfilePictureUrl;
                    user.Points = item.Points;
                    user.DateOfBirth = item.DateOfBirth;
                    user.PhoneNumber = item.PhoneNumber;
                    user.Email = item.Email;
                    //   chủ không được động vào password của user
                    await _userManager.UpdateAsync(user);
                    return new Response { IsSuccess = true, Messages = " UPDATE Successfully" };

                }
                return new Response { IsSuccess = false, Messages = " Don't Successfully" };

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Response { IsSuccess = false, Messages = " Don't Successfully" };

            }
        }
    }
}
