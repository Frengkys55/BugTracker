using System.ComponentModel.DataAnnotations;

namespace Models{
    public partial class UserRegisterModel{
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}