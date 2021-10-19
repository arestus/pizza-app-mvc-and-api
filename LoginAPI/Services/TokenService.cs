using LoginAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoginAPI.Services
{
    public class TokenService : ITokenService
    {
        private  readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));

        }
        public string CreateToken(UserDTO userDTO)
        {
            //Calim
            var claims = new List<Claim>
           {
             new Claim(JwtRegisteredClaimNames.NameId,userDTO.id)
           };
            //Credential
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);
            //Token Description
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred
            };
            //Generate Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesc);
            return tokenHandler.WriteToken(token);
        }
    }
}
