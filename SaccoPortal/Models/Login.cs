using System.ComponentModel.DataAnnotations;

namespace SaccoPortal.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "MemberId is required.")]
        public required int MemberId { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public required string Username { get; set; }
    }

}
