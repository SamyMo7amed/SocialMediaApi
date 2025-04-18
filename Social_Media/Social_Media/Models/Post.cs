using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_Media.Models
{

    public enum Privacy {
        Public, Friends, Private
    
    
    }
    public enum PostType
    {
        Video = 1000,
        Audio = 1001,
        Image = 1002,
        Text = 1003,
        Link = 1004,
    }


    public class Post
    {
        public int Id { get; set; } 
        public string? Caption { get; set; }

        public string Content { get; set; }
        [NotMapped]
        public IFormFile? ContentData { get; set; }

        public PostType Type { get; set; } 
        public ApplicationUser User { get; set; }
        
        [ForeignKey("User")]
        public string UserId { get; set; }
        [DataType(DataType.Date)]

        public DateTime CreatedDate { get; set; }   
        public Privacy Privacy { get; set; }

        // Properties  that help in RelationShips
        public List<Comment>? Comments { get; set; } 
    }
}
