using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NFTure.Core.Entities.Auth;
using NFTure.Web.Controllers.Base;
using NFTure.Web.DTOs.User;

namespace NFTure.Web.Controllers
{
    public class AuthController : ApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public AuthController(UserManager<User> userManager,
            IMapper mapper,
            RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserSignUpRequest signUpRequest)
        {
            var user = _mapper.Map<UserSignUpRequest, User>(signUpRequest);

            var createdUserResult = await _userManager
                .CreateAsync(user, signUpRequest.Password);

            if (createdUserResult.Succeeded)
            {
                return NoContent();
            }

            return Problem(createdUserResult.Errors.First().Description, null, 500);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(UserSignInRequest signInRequest)
        {
            var user = _userManager.Users
                .SingleOrDefault(u => u.Email.Equals(signInRequest.Email));

            if (user is null)
            {
                return NotFound("User not found");
            }

            var userSignInResult = await _userManager.CheckPasswordAsync(user, signInRequest.Password);

            if (userSignInResult)
            {
                return Ok();
            }

            return BadRequest("Email or password incorrect");
        }

        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Role name should be provided.");
            }

            var newRole = new Role
            {
                Name = roleName
            };

            var createRoleResult = await _roleManager.CreateAsync(newRole);

            if (createRoleResult.Succeeded)
            {
                return NoContent();
            }

            return Problem(createRoleResult.Errors.First().Description, null, 500);
        }

        [HttpPost("Role/{userName}")]
        public async Task<IActionResult> AddRoleToUser(string userName, [FromBody] string roleName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName.Equals(userName));

            var role = _roleManager.Roles.SingleOrDefault(r => r.Name.Equals(roleName));

            if (role is null)
            {
                return BadRequest("Weird role name.");
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return Problem(result.Errors.First().Description, null, 500);
        }
    }
}
