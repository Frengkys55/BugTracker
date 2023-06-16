using System.ComponentModel.DataAnnotations;

namespace Models.Authentications{
    public partial class UserLoginModel{

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? password { get; set; }
    }
}