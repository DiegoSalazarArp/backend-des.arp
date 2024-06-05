using API_DES_BOOK.Models;
using API_DES_BOOK.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace API_DES_BOOK.Controllers
{
    /// <summary>
    /// API controller for handling user authentication.
    /// </summary>
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        /// <summary>
        /// Authenticates a user and generates a JWT token if valid.
        /// </summary>
        /// <param name="login">The user login details.</param>
        /// <returns>An <see cref="IHttpActionResult"/> containing the JWT token if authentication is successful.</returns>
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] UserLogin login)
        {
            if (login == null || !IsValidUser(login))
            {
                return Unauthorized();
            }

            var token = GenerateToken(login.Username);
            return Ok(new { token });
        }

        /// <summary>
        /// Validates the user's login details.
        /// </summary>
        /// <param name="login">The user login details.</param>
        /// <returns>True if the user is valid; otherwise, false.</returns>
        private bool IsValidUser(UserLogin login)
        {
            // Implement the logic to validate the user's credentials.
            return true;
        }

        /// <summary>
        /// Generates a JWT token for the authenticated user.
        /// </summary>
        /// <param name="username">The username of the authenticated user.</param>
        /// <returns>A JWT token.</returns>
        private string GenerateToken(string username)
        {
            var issuer = ConfigurationManager.AppSettings["jwt:issuer"];
            var audience = ConfigurationManager.AppSettings["jwt:audience"];
            var key = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["jwt:secret"]);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = credentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
