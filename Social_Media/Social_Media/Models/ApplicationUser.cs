

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_Media.Models
{


    public enum GenderValue
    {
        Male,
        Female
    }
    public class ApplicationUser : IdentityUser
    {           

        public string FirstName { get; set; } 
        public string? LastName { get; set; }

        [MaxLength(120)]
        public string? DescriptionOFProfile { get; set; }
        public string ? PicturePath { get; set; }
        [NotMapped]
        public IFormFile? PictureData { get; set; } 
        [MaxLength(10)]
        public GenderValue Gender { get; set; }
       
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
     
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }



        // Properties  that help in RelationShips

        public virtual ICollection<Post>? Posts { get; set; }  
        
        public virtual ICollection<Comment>? Comments { get; set; } 
        public virtual ICollection<Interaction>? Interactions { get; set; }
        public virtual ICollection<Message>? SentMessages { get; set; }    
        public virtual ICollection<Message>? ReceiveMessages {  get; set; }    
        public virtual ICollection<Notification>? Notifications { get; set; }
        public virtual ICollection<Friend>? FriendshipsInitiated { get; set; } 
        public virtual ICollection<Friend>? FriendshipsReceived { get; set; }

    }
}

