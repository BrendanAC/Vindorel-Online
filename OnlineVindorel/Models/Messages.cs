using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVindorel.Models
{
    public class Messages
    {
        [Key]
        public int MessageID { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        [MaxLength(100)]
        public string Message { get; set; }

        public DateTime SendTime { get; set;}

        public string UserID { get; set; }
        public Account User { get; set; }
    }
}
