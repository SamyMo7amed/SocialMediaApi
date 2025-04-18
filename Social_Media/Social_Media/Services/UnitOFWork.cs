using Microsoft.AspNetCore.Identity;
using Social_Media.Models;
using Social_Media.Repository;

namespace Social_Media.Services
{
    public class UnitOFWork : IUnitOFWork
    {
        public UnitOFWork(IPostRepository Post,IMessageRepository Message,INotificationRepository Notification
            , IInteractionRepository Interaction, ICommentRepository Comment, IFriendRepository Friend,
            UserManager<ApplicationUser> UserManager, RoleManager<IdentityRole> RoleManager, SignInManager<ApplicationUser> SignInManager)
        {
            this.Post = Post;
            this.Message = Message;
            this.Notification = Notification;
            this.Interaction = Interaction;
            this.Comment = Comment;
            this.Friend = Friend;
            this.UserManager = UserManager;
            this.RoleManager = RoleManager;
            this.SignInManager = SignInManager;

        }
        public IPostRepository Post { get; }

        public IMessageRepository Message { get; }

        public INotificationRepository Notification { get; }

        public IInteractionRepository Interaction { get; }

        public ICommentRepository Comment { get; }

        public IFriendRepository Friend { get; }

        public UserManager<ApplicationUser> UserManager { get; }

        public RoleManager<IdentityRole> RoleManager { get; }

        public SignInManager<ApplicationUser> SignInManager { get; }

    }
}
