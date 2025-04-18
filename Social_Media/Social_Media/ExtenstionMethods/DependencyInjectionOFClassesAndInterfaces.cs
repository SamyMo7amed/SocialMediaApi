using Social_Media.Repository;
using Social_Media.Services;

namespace Social_Media.ExtenstionMethods
{
    public static class DependencyInjectionOFClassesAndInterfaces
    {
        public static void DependencyInjection(this IServiceCollection Services)
        {
            Services.AddScoped<IMessageRepository, MessageService>();
            Services.AddScoped<IPostRepository, PostService>();
            Services.AddScoped<IInteractionRepository, InteractionService>();
            Services.AddScoped<INotificationRepository, NotificationService>();
            Services.AddScoped<IFriendRepository, FriendService>();
            Services.AddScoped<ICommentRepository,CommentService>();
            Services.AddScoped<IUnitOFWork, UnitOFWork>();
        }
    }
}
