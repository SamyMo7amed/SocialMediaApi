using Microsoft.AspNetCore.Identity;
using Social_Media.Models;

namespace Social_Media.Repository
{
    public interface IUnitOFWork
    {
        IPostRepository Post { get; }
        IMessageRepository Message { get; }
        INotificationRepository Notification { get; }
        IInteractionRepository Interaction { get; }
        ICommentRepository Comment { get; }
        IFriendRepository Friend { get; }
        UserManager<ApplicationUser> UserManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }
        SignInManager<ApplicationUser> SignInManager { get; }   
    }
}
