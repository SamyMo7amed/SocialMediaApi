using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_Media.Models
{

    public enum Privacy {
        Public, Friends, Private
    
    
    }


    public class Post
    {
        public Guid Id { get; set; } 
       
        public string Content { get; set; } 

         
             [ForeignKey("UserId")]
        public AppUser User { get; set; }


       
        public Guid UserId { get; set; }
        [DataType(DataType.Date)]

        public byte[]? post { get; set; }
        public DateTime CreatedDate { get; set; }   
        public Privacy Privacy { get; set; }       
    }
}
