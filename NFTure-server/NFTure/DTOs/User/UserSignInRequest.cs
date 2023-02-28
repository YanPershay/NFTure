using System.ComponentModel.DataAnnotations;

namespace NFTure.Web.DTOs.User
{
    public class UserSignInRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
