using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DadBodToGreekGod.Models.User
{
    public class UserUpdate
    {
        [Required]
        public bool HasMadeCalendar { get; set; }
    }
}