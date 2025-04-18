using Microsoft.EntityFrameworkCore;
using Social_Media.Data;
using Social_Media.Models;
using Social_Media.Repository;

namespace Social_Media.Services
{
    public class MessageService : IMessageRepository
    {
        ContextData Data;
        public MessageService(ContextData Data)
        {
            this.Data = Data;
        }
        public async Task AddAsync(Message entity)
        {
            try
            {
                await Data.Messages.AddAsync(entity);
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
                Data.Messages.Remove(await GetByIdAsync(id));
            }
            catch
            {
                throw new Exception("Error deleting comment from the database");
            }
        }

        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            try
            {
                return await Data.Messages.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            try
            {
                return await Data.Messages.FindAsync(id);
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

        public async Task UpdateAsync(Message entity)
        {
            try
            {
                Data.Messages.Update(entity);
            }
            catch
            {
                throw new Exception("Error updating comment in the database");
            }
        }
    }
}
