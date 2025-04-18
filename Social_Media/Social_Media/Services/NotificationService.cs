using Microsoft.EntityFrameworkCore;
using Social_Media.Data;
using Social_Media.Models;
using Social_Media.Repository;

namespace Social_Media.Services
{
    public class NotificationService : INotificationRepository
    {
        ContextData Data;
        public NotificationService(ContextData Data)
        {
            this.Data = Data;
        }
        public async Task AddAsync(Notification entity)
        {
            try
            {
                await Data.Notifications.AddAsync(entity);
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
                Data.Notifications.Remove(await GetByIdAsync(id));
            }
            catch
            {
                throw new Exception("Error deleting comment from the database");
            }
        }

        public async Task<IEnumerable<Notification>> GetAllAsync()
        {
            try
            {
                return await Data.Notifications.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Notification> GetByIdAsync(int id)
        {
            try
            {
                return await Data.Notifications.FindAsync(id);
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

        public async Task UpdateAsync(Notification entity)
        {
            try
            {
                Data.Notifications.Update(entity);
            }
            catch
            {
                throw new Exception("Error updating comment in the database");
            }
        }
    }
}
