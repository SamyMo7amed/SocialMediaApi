using Microsoft.EntityFrameworkCore;
using Social_Media.Data;
using Social_Media.Models;
using Social_Media.Repository;

namespace Social_Media.Services
{
    public class CommentService : ICommentRepository
    {
        ContextData Data;
        public CommentService(ContextData Data)
        {
            this.Data = Data;
        }
        public async Task AddAsync(Comment entity)
        {
            try
            {
                await Data.Comments.AddAsync(entity);
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
                 Data.Comments.Remove(await GetByIdAsync(id));
            }
            catch
            {
                throw new Exception("Error deleting comment from the database");
            }
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            try
            {
               return await Data.Comments.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            try {
                return await Data.Comments.FindAsync(id);
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

        public async Task UpdateAsync(Comment entity)
        {
            try
            {
                 Data.Comments.Update(entity);
            }
            catch
            {
                throw new Exception("Error updating comment in the database");
            }
        }
    }
}
