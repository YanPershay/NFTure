using System.ComponentModel.DataAnnotations;

namespace NFTure.Web.DTOs.User
{
    public class UserSignUpRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
