using Microsoft.Extensions.Hosting;
using System.Xml.Linq;
using System;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Social_Media.Models
{

    public enum LikesType
    {
        Like = 1000,
        Love = 1001,
        Support = 1002,
        Happy = 1003,
        Wow = 1004,
        Sad = 1005,
        Angry = 1006
    }
    public enum InteractionWith
    {
        Post = 1000,
        Comment = 1001,
        Story = 1002
    }
    public class Interaction 
    {
        public int Id { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public LikesType LikeType { get; set; } 
        [ForeignKey("Post")]    
        public int? PostId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public InteractionWith InteractionWith { get; set; }
        [ForeignKey("Comment")]
        public int? CommentId { get; set; }
        public virtual Post? Post { get; set; }

        public virtual ApplicationUser? User { get; set; }          

        public virtual Comment? Comment { get; set; }

    }
}
