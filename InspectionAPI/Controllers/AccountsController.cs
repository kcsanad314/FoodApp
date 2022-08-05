using InspectionAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InspectionAPI.JwtFeatures;
using System.IdentityModel.Tokens.Jwt;
using InspectionAPI.Data;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Owin.Security;

namespace InspectionAPI.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;
        private readonly DataContext _db;

        public AccountsController(UserManager<User> userManager, IMapper mapper, JwtHandler jwtHandler, DataContext db, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
            _db = db;
            _signInManager = signInManager;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistration)
        {
            if (userRegistration == null || !ModelState.IsValid)
                return BadRequest();

            //var duser = JsonConvert.DeserializeObject<UserRegistrationDto>(userRegistration);
            var user = _mapper.Map<User>(userRegistration);

            var result = await _userManager.CreateAsync(user, userRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }
            //var userRole = JsonConvert.DeserializeObject(userRegistration.UserRole);
            await _userManager.AddToRoleAsync(user, user.UserRole.ToString());
            //_userManager.

            return StatusCode(201);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            claims.Add(new Claim(ClaimTypes.Name, userForAuthentication.Email));
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            //await _userManager.CreateAsync(user, token);
            await _signInManager.SignInWithClaimsAsync(user,true, claims);
            var calimidentity = new ClaimsIdentity(claims);
            //_authenticationManager.SignIn(calimidentity);
            
            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }
        //Accounts/GetUser
        [HttpGet]
        public  IActionResult GetUser()
        {

            var user1 = this.User.Identity.Name;

            var result = user1;


            return Ok(result);
        }
    }
}
