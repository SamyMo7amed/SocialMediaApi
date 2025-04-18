using Microsoft.EntityFrameworkCore;
using Social_Media.Data;
using Social_Media.Models;
using Social_Media.Repository;

namespace Social_Media.Services
{
    public class FriendService : IFriendRepository
    {
        ContextData Data;
        public FriendService(ContextData Data)
        {
            this.Data = Data;
        }
        public async Task AddAsync(Friend entity)
        {
            try
            {
                await Data.Friends.AddAsync(entity);
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
                Data.Friends.Remove(await GetByIdAsync(id));
            }
            catch
            {
                throw new Exception("Error deleting comment from the database");
            }
        }

        public async Task<IEnumerable<Friend>> GetAllAsync()
        {
            try
            {
                return await Data.Friends.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Friend> GetByIdAsync(int id)
        {
            try
            {
                return await Data.Friends.FindAsync(id);
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

        public async Task UpdateAsync(Friend entity)
        {
            try
            {
                Data.Friends.Update(entity);
            }
            catch
            {
                throw new Exception("Error updating comment in the database");
            }
        }
    }
}
