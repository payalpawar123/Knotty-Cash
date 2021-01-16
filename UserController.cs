using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions;
using StocksApp.Services;
using StocksApp.Model.UserModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StocksApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/auth")]
    public class UserController : Controller
    {
        private IUserService _service;

        public UserController(IUserService userService)
        {
            _service = userService;
        }

        // GET: get current user
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var accessToken = Request.Headers["Authorization"];

            var user = await _service.GetCurrentUserAsync(accessToken);

            return Ok(user);

        }

        // Post: update current user
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody]UserRequest req)
        {
            var accessToken = Request.Headers["Authorization"];

            var user = await _service.GetCurrentUserAsync(accessToken);

            if (user == null)
            {
                return BadRequest("No user found!");
            }

            user.FirstName = req.FirstName;
            user.LastName = req.LastName;
            user.Email = req.Email;

            if (req.Cash > 0)
            {
                user.InvestmentPortfolio.cashAvailable += req.Cash;
            }

            await _service.UpdateUser(user);

            return Ok(user);

        }

        [AllowAnonymous]
        [HttpGet("test")]
        public ContentResult test()
        {
            return Content("test route");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody]CredentialModel model)
        {
            var user = await _service.Authenticate(model.Email, model.Password);

            if (user == null)
            {
                return Ok(new { message = "Credentials are invalid!" });
            }

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            var user = await _service.Register(model);

            if (user == null)
                return Ok(new { message = "A user with given email already exists!" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("get-question")]
        public async Task<IActionResult> GetQuestion([FromBody]ForgotPassword model)
        {
            var question = await _service.GetQuestion(model.Email);

            if (question == null)
                return Ok(new { message = "No user found with related email." });

            return Ok(new { question = question });
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody]ForgotPassword model)
        {
            var success = await _service.ResetPassword(model);

            return Ok(new { success = success });
        }

        [AllowAnonymous]
        [HttpPost("question")]
        public async Task<IActionResult> PostQuestion([FromBody]ForgotPassword model)
        {
            var success = await _service.PostQuestion(model);

            return Ok(new { success = success });
        }
    }
}
