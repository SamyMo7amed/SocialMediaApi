using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Social_Media.Models;

namespace Social_Media.Data
{
    public class ContextData : IdentityDbContext<ApplicationUser>
    {
        public ContextData(DbContextOptions<ContextData> Options) : base(Options) {      
        
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Post>().HasOne(U=>U.User).WithMany(P=>P.Posts).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>().HasOne(C=>C.User).WithMany(U=>U.Comments).HasForeignKey(C=>C.UserId);  
            builder.Entity<Comment>().HasOne(C=>C.Post).WithMany(P=>P.Comments).HasForeignKey(C=>C.PostId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Interaction>().HasOne(I => I.User).WithMany(U => U.Interactions).HasForeignKey(I => I.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Interaction>().HasOne(p=>p.Comment).WithMany(x=>x.likes).HasForeignKey(x=>x.CommentId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Notification>().HasOne(N => N.User).WithMany(U => U.Notifications).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Message>().HasOne(M=>M.SenderUser).WithMany(U=>U.SentMessages).HasForeignKey(x=>x.SenderId).OnDelete(DeleteBehavior.Restrict);       
            builder.Entity<Message>().HasOne(M=>M.ReceiverUser).WithMany(U=>U.ReceiveMessages).HasForeignKey(x=>x.ReceiverId).OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Friend>()
            .HasOne(F => F.MainUser)
            .WithMany(U => U.FriendshipsInitiated)
            .HasForeignKey(F => F.UserId)
            .OnDelete(DeleteBehavior.Restrict);

             builder.Entity<Friend>()
            .HasOne(F => F.FriendUser)
            .WithMany(u => u.FriendshipsReceived)
            .HasForeignKey(f => f.FriendUserId)
            .OnDelete(DeleteBehavior.Restrict);

        }


        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }  
        public virtual DbSet<Interaction> Interactions { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

    }
}
