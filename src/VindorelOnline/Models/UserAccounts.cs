using System;
using System.Collections.Generic;

namespace VindorelOnline.Models
{
    public partial class UserAccounts
    {
        public UserAccounts()
        {
            Towns = new HashSet<Towns>();
        }

        public int UserID { get; set; }
        public string AccountName { get; set; }
        public bool isAdmin { get; set; }
        public bool isConfirmed { get; set; }
        public string LoginMail { get; set; }
        public string LoginPassword { get; set; }
        public DateTime RegisterDate { get; set; }
        public double SpeedBuildMultiplier { get; set; }
        public double SpeedTradeMultiplier { get; set; }
        public double SpeedTrainMultiplier { get; set; }
        public string UserJob { get; set; }
        public string UserRace { get; set; }

        public virtual ICollection<Towns> Towns { get; set; }
    }
}
