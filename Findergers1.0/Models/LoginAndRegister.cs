using System;
using System.Collections.Generic;

namespace Findergers1._0.Models
{
    public partial class LoginAndRegister
    {
        public int Id { get; set; }
        public string? FristName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Token { get; set; }
    }
}
