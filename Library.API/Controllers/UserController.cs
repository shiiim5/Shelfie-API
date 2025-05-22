using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.API.Helper;
using Library.Core.Entities.Users;
using Library.Core.Interfaces;
using Library.Core.Models.Authentication.Login;
using Library.Core.Models.Authentication.Register;
using Library.User.Management.Models;
using Library.User.Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Library.API.Controllers
{
  
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        private readonly IEmailService emailService;
        public UserController(IUnitOfWork unit, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IEmailService emailService, IConfiguration configuration) : base(unit, mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;

            this.emailService = emailService;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterUser registerUser, string role)
        {
           var existedUser = await userManager.FindByEmailAsync(registerUser.Email);
            if (existedUser != null) {
                return StatusCode(StatusCodes.Status403Forbidden, new ResponseAPI(403, "User Already Exists!"));
            }

            var user = new ApplicationUser()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.UserName,
            };
            if (await roleManager.RoleExistsAsync(role))
            {
                var result = await userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseAPI(500, "User Failed To Be Created!"));

                }

                await userManager.AddToRoleAsync(user,role);

                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail),"User",new {token, email = user.Email},Request.Scheme);
                var message = new Message(new string[] { user.Email! },"Confirmation email link",confirmationLink);
                emailService.sendEmail(message);


                return Ok(new ResponseAPI(200,$"User Created and Email sent to {user.Email} successfully"));

            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseAPI(500, "This Role Does not exist"));

            }

        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token,string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null) {
                var result = await userManager.ConfirmEmailAsync(user,token);
                if (result.Succeeded)
                {
                    return Ok(new ResponseAPI(200,"Email Verified Sucessfully"));
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseAPI(500, "This User does not exist!"));

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            var user = await userManager.FindByEmailAsync(loginUser.Email);

            if (user != null && await userManager.CheckPasswordAsync(user, loginUser.Password)) {
                var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

                var userRoles = await userManager.GetRolesAsync(user);

                foreach (var role in userRoles) { 
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                }

                var jwtToken = await GetToken(authClaims);
                return Ok(new { 

                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo
                    
                    } );
            
            }
            return Unauthorized();

        }

        private async Task<JwtSecurityToken> GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer : configuration["JWT:ValidIssuer"],
                audience : configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims : authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
    }
}
