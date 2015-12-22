using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVindorel.ViewModels.Account
{
    public class FirstStart
    {
        [Required]
        public string Job { get; set; }

        [Required]
        public string Race { get; set; }

    }
}
