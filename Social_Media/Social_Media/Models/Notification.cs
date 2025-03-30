using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_Media.Models
{


    public enum TypeNotification { Like, Comment, FriendRequest, Message }
    public class Notification
    {




//IsRead(BOOLEAN, DEFAULT FALSE)
//CreatedAt(DATETIME)


        public Guid Id { get; set; } 
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]  
        public AppUser AppUser { get; set; }    

        public Guid ReferenceId { get; set; }   // if it PostID or message or Comment

        public bool IsRead { get; set; } = false;

        public      DateTime Created { get; set; }    


    }
}
