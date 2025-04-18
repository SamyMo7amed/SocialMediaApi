using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_Media.Models
{

    public enum Status { Pending, Accepted, Rejected }
    public class Friend
    {
        public int Id { get; set; } 
        [ForeignKey ("MainUser")]
        public string UserId { get; set; }

        [ForeignKey("FriendUser")]
        public string FriendUserId { get; set; }
        public Status status { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual ApplicationUser? FriendUser { get; set; }
        public virtual ApplicationUser? MainUser { get; set; }
       
    }
}
