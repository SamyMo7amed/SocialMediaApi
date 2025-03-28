

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.ComponentModel.DataAnnotations;

namespace Social_Media.Models
{
    public class AppUser : IdentityUser
    {

        public Guid Guid { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }

        
        public string Password { get; set; }
        [Compare("Password")]   
        public string ConfirmPassword { get; set; }

        public byte[]? ProfilePicture { get; set; }

        [MaxLength(120)]
        public string Bio { get; set; }
        public enum GenderValue
        {
            Male,
            Female


        }


        [MaxLength(10)]
        public GenderValue Gender { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }




        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }




        //CreatedAt(DATETIME)


    }
}

