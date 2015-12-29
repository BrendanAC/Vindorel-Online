using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineVindorel.ViewModels.Account
{
    public class NameViewModel
    { 
        [Required(ErrorMessage ="Give a new Name!!")]
        public string Name { get; set; }
    }
}
