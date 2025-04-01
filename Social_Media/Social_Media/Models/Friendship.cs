using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_Media.Models
{

    public enum Status { Pending, Accepted, Rejected }
    public class Friendship
    {

  

        public Guid Id { get; set; } 

        public Guid UserId1 { get; set; }
        [ForeignKey ("UserId1")]
        public AppUser User1 { get; set; }

        public Guid UserId2 { get; set; }
        [ForeignKey("UserId2")]
        public AppUser User2 { get; set; }



         public Status status { get; set; } 


        public DateTime CreatedAT { get; set; }

       
    }
}
