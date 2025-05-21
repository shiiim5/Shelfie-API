using AutoMapper;
using Library.API.Helper;
using Library.Core.Entities.Users;
using Library.Core.Interfaces;
using Library.Core.Models.Authentication.Register;
using Library.User.Management.Models;
using Library.User.Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
  
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
       
        private readonly IEmailService emailService;
        public UserController(IUnitOfWork unit, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IEmailService emailService) : base(unit, mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
           
            this.emailService = emailService;
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
                return Ok();

            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseAPI(500, "This Role Does not exist"));

            }

        }

        [HttpGet]
        public IActionResult TestEmail()
        {
            var message = new Message(new string[] { "alishimaa310@gmail.com" }, "test", "testing");
           
            emailService.sendEmail(message);
            return Ok();
        }
    }
}
