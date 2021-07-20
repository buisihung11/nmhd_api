using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NMHD_DataAccess.Models;
using NMHD_DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuocMamHongDuc_Web_App.Controllers
{
    


    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly String SALT = "unideliverytnahbstncnvt1999";
        private readonly IConfiguration _config;
        private readonly NMHDDbContext _context;
        private readonly ITokenService _tokenService;

        public UserController(IConfiguration config, NMHDDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
            _config = config;
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login(User userModel)
        {
            if (string.IsNullOrEmpty(userModel.Username) || string.IsNullOrEmpty(userModel.Password))
            {
                return BadRequest();
            }
            IActionResult response = Unauthorized();

            var validUser = _context.StoreConfigs.FirstOrDefault((u) => u.Username == userModel.Username);
            
            String generatedToken;
            if (validUser != null)
            {
                var hashedPass = Utils.Utils.GetHash(userModel.Password, SALT);
                var checkPassword = validUser.Password == Utils.Utils.GetHash(userModel.Password,SALT);
                if(!checkPassword)
                {
                    return BadRequest();
                }
                generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), new User(validUser.Username, validUser.Password));
                if (generatedToken != null)
                {
                    return CreatedAtAction("Login", null, new
                    {
                        access_token = generatedToken,
                        storeConfig = validUser 
                    });
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // [Authorize]
        [HttpPut]
        public ActionResult UpdatePassword(String username, String oldPassword, String newPassword)
        {
            var hasedOldPasword = Utils.Utils.GetHash(oldPassword, SALT);
            var user = _context.StoreConfigs.FirstOrDefault((s) => s.Username == username && s.Password == hasedOldPasword);
            if(user == null)
            {
                return BadRequest();
            }

            user.Password = Utils.Utils.GetHash(newPassword, SALT);
            _context.SaveChanges();
            return Ok(user);
            
        }

    }
}
