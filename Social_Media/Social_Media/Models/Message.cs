﻿using static System.Net.Mime.MediaTypeNames;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_Media.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        [ForeignKey("SenderUser")]
        public string SenderId { get; set; }
        [ForeignKey("ReceiverUser")]
        public  string ReceiverId { get; set; }   
        public bool IsRead {  get; set; }   = false;    
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual ApplicationUser? SenderUser { get; set; }
        public virtual ApplicationUser? ReceiverUser { get; set; }         


    }
}
