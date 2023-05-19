using System.ComponentModel.DataAnnotations;

namespace Models{
    public partial class UserLoginModel{

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? password { get; set; }
    }
}