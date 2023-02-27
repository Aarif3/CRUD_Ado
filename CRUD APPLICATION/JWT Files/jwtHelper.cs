using DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Claim = System.Security.Claims.Claim;

namespace CRUD_APPLICATION.JWT_Files
{
    public class jwtHelper
    {
        public static string SignInKey = "z%C*F-J@NcRfUjXn";

        public static string JwtTokenCreate(Logins lo)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SignInKey));
            var creadentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var issuer = "https://localhost:44311/";
            var audience = "https://localhost:44311/";

            var claims = new List<Claim>
            {
                new Claim(System.IdentityModel.Claims.ClaimTypes.NameIdentifier,lo.UserName,null)
            };

            var token = new JwtSecurityToken(issuer, audience,
                (IEnumerable<System.Security.Claims.Claim>)claims, expires: DateTime.Now.AddDays(1), signingCredentials: creadentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static ClaimsPrincipal Validate(string token)
        {
            var handle = new JwtSecurityTokenHandler();
            handle.ValidateToken(token, new TokenValidationParameters()
            {
                ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 },
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SignInKey)),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true
            }, out SecurityToken ValidatedToken);
            JwtSecurityToken jwttoken = (JwtSecurityToken)ValidatedToken;
            var identity = new ClaimsIdentity(jwttoken.Claims, "Bearer");
            return new ClaimsPrincipal(identity);
        }

    }
}