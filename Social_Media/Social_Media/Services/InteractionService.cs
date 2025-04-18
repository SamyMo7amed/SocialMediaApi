using Microsoft.EntityFrameworkCore;
using Social_Media.Data;
using Social_Media.Models;
using Social_Media.Repository;

namespace Social_Media.Services
{
    public class InteractionService : IInteractionRepository
    {
        ContextData Data;
        public InteractionService(ContextData Data)
        {
            this.Data = Data;
        }
        public async Task AddAsync(Interaction entity)
        {
            try
            {
                await Data.Interactions.AddAsync(entity);
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
                Data.Interactions.Remove(await GetByIdAsync(id));
            }
            catch
            {
                throw new Exception("Error deleting comment from the database");
            }
        }

        public async Task<IEnumerable<Interaction>> GetAllAsync()
        {
            try
            {
                return await Data.Interactions.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Interaction> GetByIdAsync(int id)
        {
            try
            {
                return await Data.Interactions.FindAsync(id);
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

        public async Task UpdateAsync(Interaction entity)
        {
            try
            {
                Data.Interactions.Update(entity);
            }
            catch
            {
                throw new Exception("Error updating comment in the database");
            }
        }
    }
}
