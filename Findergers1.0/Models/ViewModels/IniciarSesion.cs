using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Findergers1._0.Models
{
    public class IniciarSesion
    {
        [EmailAddress]
        [Required]
        public string User { get; set; }
        public string password { get; set; }
    }
}
