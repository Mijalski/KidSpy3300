using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;

namespace KidSpy3300.Models
{
    public class ShowMessageModel
    {
        public Message Message { get; set; }
        public string RespondToId { get; set; }
        public bool YourMessage { get;set; }
    }
}
