using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Excercise.Utilities
{
    public class JWTHandler
    {
        public static string GenerateToken(string user)
        {
            try
            {
                var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes("bqTg9m8QbckG5zUQVGPHAVKw52VJlKoHN0FhNNE9"));//quipserve@gbamnigeria
                var creds = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);
                Claim[] claims = new Claim[]
                 {
                     new Claim(ClaimTypes.Name , user)
                 };
                var logged_token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    audience: "yourdomain.com",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                var token = new JwtSecurityTokenHandler().WriteToken(logged_token);

                return token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GenerateRefreshToken()
        {
            try
            {
                var randomNumber = new byte[32];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomNumber);
                    return Convert.ToBase64String(randomNumber);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
