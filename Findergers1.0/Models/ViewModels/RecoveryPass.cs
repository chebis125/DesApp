using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Findergers1._0.Models
{
    public class RecoveryPass
    {
        public string token { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "La contraseña no coincide")]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
