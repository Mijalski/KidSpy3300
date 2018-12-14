using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;

namespace KidSpy3300.Models
{
    public class SendMessageModel
    {
        [Required]
        public string ToUserId { get; set; }
        
        [Required]
        [MinLength(5)]
        public string MessageTitle { get; set; }

        [Required]
        [MinLength(10)]
        public string MessageContent { get; set; }

        public List<UserAccount> UserAccounts { get; set; }

        public string PreSelectedId { get; set; }
    }
}
