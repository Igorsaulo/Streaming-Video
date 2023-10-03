using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using DotNetEnv;
using System.Security.Claims;
using System.Text;


namespace Video_Streaming.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Authenticate(string email, string password)
        {
            var user = await _userRepository.ValidateUser(password, email);
            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Env.GetString("SECRET"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                    }
                ),
                Expires = System.DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<UserAuthDTO> ValidateUser(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Env.GetString("SECRET"));
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuer = false,
            };

            var claims = tokenHandler.ValidateToken(
                token,
                validationParameters,
                out var validatedToken
            );
            var user = _userRepository.FindById(
                System.Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier).Value)
            );

            return new UserAuthDTO
            {
                UserId = new Guid(claims.FindFirst(ClaimTypes.NameIdentifier).Value),
                Email = claims.FindFirst(ClaimTypes.Email).Value,
            };
        }
    }
}
