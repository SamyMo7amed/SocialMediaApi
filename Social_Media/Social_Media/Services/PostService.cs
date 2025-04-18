using Microsoft.EntityFrameworkCore;
using Social_Media.Data;
using Social_Media.Models;
using Social_Media.Repository;

namespace Social_Media.Services
{
    public class PostService : IPostRepository
    {
        ContextData Data;
        public PostService(ContextData Data)
        {
            this.Data = Data;
        }
        public async Task AddAsync(Post entity)
        {
            try
            {
                await Data.Posts.AddAsync(entity);
            }
            catch
            {
                throw new Exception("Error adding comment to the database");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                Data.Posts.Remove(await GetByIdAsync(id));
            }
            catch
            {
                throw new Exception("Error deleting comment from the database");
            }
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            try
            {
                return await Data.Posts.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            try
            {
                return await Data.Posts.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await Data.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving changes to the database", ex);
            }
        }

        public async Task UpdateAsync(Post entity)
        {
            try
            {
                Data.Posts.Update(entity);
            }
            catch
            {
                throw new Exception("Error updating comment in the database");
            }
        }
    }
}
