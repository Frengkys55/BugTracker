using System.ComponentModel.DataAnnotations;

namespace Models.Authentications{
    public partial class UserRegisterModel{
        public Guid Guid {get; set;} = Guid.NewGuid();

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}