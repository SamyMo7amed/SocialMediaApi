using Microsoft.Extensions.Hosting;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Social_Media.Models
{
    public class Comment
    {

        public int Id { get; set; }
        [MaxLength(200)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("User")]
        public string  UserId { get; set; }
        [ForeignKey("Post")]         
        public int PostId { get; set; }
        // Properties  that help in RelationShips
        public virtual Post? Post { get; set; }  
        public virtual ApplicationUser? User { get; set; }
        public virtual List<Interaction>? likes { get; set; }

    }
}
