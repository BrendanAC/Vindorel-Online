using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vindorel_Online_Game.Models
{
    public class UserAccount
    {
        public int UserId { get; set; }


        public string LoginMail { get; set; }

        public string LoginName { get; set; }

        public string LoginPassword { get; set; }

        public bool isConfirmed { get; set; }

        public string UserRace { get; set; }

        public string UserJob { get; set; }

        public bool isAdmin { get; set; }

        public float SpeedBuild { get; set; }

        public float SpeedTrain { get; set; }

        public float SpeedDiplomacy { get; set; }

    }
}
