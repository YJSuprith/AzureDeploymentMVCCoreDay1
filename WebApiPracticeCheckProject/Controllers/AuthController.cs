using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPracticeCheckProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("{id}")]
        public string Post(int id)
        {
            var tokenUser =CreateToken(id);
            return tokenUser;
        }
        
            readonly SymmetricSecurityKey _key;
            public AuthController(IConfiguration configuration)
            {
                _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
            }

            public string CreateToken(int id)
            {
                var claims = new List<Claim>();
                if (id==-1)
                {
                    claims = new List<Claim>();
                }
                else if(id==1)
                {
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role,"Admin")
                    };
                }
                else if(id!=1 && id!=-1)
                {
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role,"User")
                    };
                }
                var credential = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(3),
                    SigningCredentials = credential
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescription);
                return tokenHandler.WriteToken(token);
            }
        
    }
}
