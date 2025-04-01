using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Social_Media.Models;

namespace Social_Media.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) {
        
        
        
        
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<Post>().HasOne(p=>p.User).WithMany(p=>p.Posts).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Restrict);

           builder.Entity<Comment>().HasOne(p=>p.User).WithMany(x=>x.Comments).HasForeignKey(x=>x.UserId);  
           builder.Entity<Comment>().HasOne(x=>x.Post).WithMany(x=>x.Comments).HasForeignKey(x=>x.PostId).OnDelete(DeleteBehavior.Restrict);
           builder.Entity<Like>().HasOne(p => p.User).WithMany(x => x.Likes).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
          builder.Entity<Like>().HasOne(p=>p.Comment).WithMany(x=>x.likes).HasForeignKey(x=>x.CommentId).OnDelete(DeleteBehavior.Restrict); 

           
        }


        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Friendship> friendships { get; set; }  
        public DbSet<Like> likes { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Post> posts { get; set; }

    }
}
