using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model
{
    public enum Status
    {
        Send = 1,
        Delivered = 2,
        Read = 3,
        Error = 4
    }
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Status Status { get; set; }
        
        [Required]
        public string MessageContent { get; set; }
        
        [Required]
        public string MessageTitle { get; set; }
        
        public DateTime MessageDate { get; set; }

        
        public UserAccount MessageFrom { get; set; }

        public UserAccount MessageTo { get; set; }
    }
}
