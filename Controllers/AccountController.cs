using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.Models;
using StoreManagement.ViewModels;
using StoreManagement.Service;
using System.Linq;

namespace StoreManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly JwtConfig _jwtConfig;
        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            JwtConfig jwtConfig
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtConfig = jwtConfig;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel logiUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            IActionResult ret = null;
            UserAuth auth = new UserAuth();
            SecurityManager mgr = new SecurityManager(_userManager, _signInManager, _jwtConfig);
            User user = new User
            {
                UserName = logiUser.UserName,
                Password = logiUser.Password
            };
            auth = await mgr.AuthenticateUser(user);
            if (auth.IsAuthenticated)
            {
                ret = StatusCode(StatusCodes.Status200OK, auth);
            }
            else
            {
                ret = StatusCode(StatusCodes.Status404NotFound, "Invalid User Name/Password.");
            }
            return ret;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            IdentityUser user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            IdentityUser user =await _userManager.GetUserAsync(User);            
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            return Ok(result);
        }

    }
}