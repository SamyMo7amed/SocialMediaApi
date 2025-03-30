using static System.Net.Mime.MediaTypeNames;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_Media.Models
{
    public class Message
    {





        public int Id { get; set; } public string Title { get; set; }
        public Guid SenderId { get; set; }
        [ForeignKey(nameof(SenderId))]
        public AppUser SenderUser { get; set; }



        public  Guid ReceiverId { get; set; }   
        [ForeignKey(nameof(ReceiverId))]
        public AppUser ReceiverUser { get; set; }
         
        public Byte[] Data { get; set; }
         public DateTime CreatedAt { get; set; }

        public bool IsRead {  get; set; }   = false;    

    }
}
