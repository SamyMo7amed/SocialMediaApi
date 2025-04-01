using Microsoft.Extensions.Hosting;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Social_Media.Models
{
    public class Comment
    {

        public Guid Id { get; set; }

        public Guid  UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }
        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }  
         
        public int PostId { get; set; }

        [MaxLength(200)]
        public string Content { get; set; }



        public DateTime CreatedAt { get; set; }

        // Properties  that help in RelationShips
        public List<Like>? likes { get; set; }

    }
}
