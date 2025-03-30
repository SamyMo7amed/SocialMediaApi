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
        Like, Love ,Angry, Happy
    }
    public class Like 
    {


        public int Id { get; set; } 

        public int PostId { get; set; }
        [ForeignKey(nameof(PostId))]    

        public Post Post { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }  
         
        public Guid UserId { get; set; }

        public LikesType LikeType { get; set; } 
        public DateTime CreatedAt { get; set; }

    }
}
