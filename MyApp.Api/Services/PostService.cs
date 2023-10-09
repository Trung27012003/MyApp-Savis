using Microsoft.EntityFrameworkCore;
using MyApp.Api.Data;
using MyApp.Api.IServices;
using MyApp.Shared.Models;
using MyApp.Shared.ViewModel;
using System.Drawing;

namespace MyApp.Api.Services
{
    public class PostService: IPostService
    {
        public MyDbContext _dbContext;

        public PostService(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }

        public async Task<Response> AddItem(PostModel item)
        {
            try
            {
                var post = new PostModel()
                {
                    UserId = item.UserId,
                    Title = item.Title,
                    Content = item.Content,
                    CreatedAt = item.CreatedAt,
                    UpdatedAt = item.UpdatedAt,


                };
                await _dbContext.Posts.AddAsync(post);
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
                var item = await _dbContext.Posts.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<List<PostModel>> GetAllItems()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<PostModel> GetItem(Guid id)
        {
            return await _dbContext.Posts.FindAsync(id);
        }

        public async Task<Response> UpdateItem(PostModel item)
        {
            try
            {
                var post = await _dbContext.Posts.FirstOrDefaultAsync(c => c.Id == item.Id);
                post.UserId = item.UserId;
                post.Title = item.Title;
                post.Content = item.Content;
                post.CreatedAt = item.CreatedAt;
                post.UpdatedAt = item.UpdatedAt;
                _dbContext.Posts.Update(post);
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
