using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_Media.Models
{


    public enum TypeNotification { Interaction, Comment, FriendRequest, Message }
    public class Notification
    {
        public int Id { get; set; } 
        [ForeignKey("User")]  
        public string UserId { get; set; }
        public bool IsRead { get; set; } = false;

        public DateTime Created { get; set; } =  DateTime.Now;

        public virtual ApplicationUser? User { get; set; }    

    }
}
