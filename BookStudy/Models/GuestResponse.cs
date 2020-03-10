using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStudy.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please, enter you name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Please, enter you email")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please, enter a valid e mail address")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please, enter you phone")]
        public int phone { get; set; }
        [Required(ErrorMessage = "Please, specify whether you'll attend")]
        public bool? willAttend { get; set; }
    }
}
