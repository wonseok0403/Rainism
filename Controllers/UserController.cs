using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using SessionApi.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using Rainism;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

// https://auth0.com/blog/securing-asp-dot-net-core-2-applications-with-jwts/
namespace MyWebApi.Controllers
{

    public class UserController : Controller
    {
        private readonly MyWebApiContext _context;
        private IConfiguration _configuration;
        private static string getHash(string text)
        {
            // SHA512 is disposable by inheritance.  
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
        public UserController(MyWebApiContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            if (_context.Users.Count() == 0)
            {
                string pwTmp = getHash("1234");
                _context.Users.Add(new User { Id = 1234, PrimaryKey = "wonseok", Name = "wonseok", NickName = "Noru", PhoneNum = "62531685", LstSession = "1234", Password = pwTmp });
                Console.WriteLine("Hash : " + pwTmp);

                _context.SaveChanges();
            }
        }


        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        private String BuildToken(SimpleUser user){

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("Login")]
        public IActionResult Login(SimpleUser user)
        {
            //https://docs.microsoft.com/ko-kr/aspnet/core/fundamentals/app-state?view=aspnetcore-2.
            var IdItem = _context.Users.Find(user.Id);
            var InputPassword = getHash(user.Password);
            if( InputPassword == IdItem.Password ){
                // login success
                var tokenString = BuildToken(user);
                HttpContext.Session.SetString("Login", tokenString);
            }
            else{
                Console.WriteLine("로그인 실패");
            }
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpGet]
        [Route("Signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [Route("Signup")]
        public IActionResult Signup(SimpleUser user)
        {
            if (ModelState.IsValid)
            {
                User tmpUser = new User(user);
                tmpUser.LstSession = "";
                var IdItem = _context.Users.Find(user.Id);
                if (IdItem == null)
                {
                    tmpUser.Password = getHash(user.Password);
                    _context.Users.Add(tmpUser);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(user);  
            }

        }
    }
}
