using System.ComponentModel.DataAnnotations;

namespace Findergers1._0.Models
{
    public class Register
    {
        public int Id { get; set; }
        [Required]
        public string FristName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

    }
}
