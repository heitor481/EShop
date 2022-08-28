using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EShop.Infra.Authentication
{
    public class AuthenticationHandler : IAuthenticationHandler
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityToken = new JwtSecurityTokenHandler();
        private readonly JwtOptions _jwtOptions;
        private readonly SecurityKey _issuerSecurityKey;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtHeader _jwtHeader;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly IConfiguration _configuration;

        public AuthenticationHandler(IConfiguration configuration)
        {
            _jwtOptions = new JwtOptions();
            configuration.GetSection("JWT").Bind(_jwtOptions);
            _issuerSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
            _signingCredentials = new SigningCredentials(_issuerSecurityKey, SecurityAlgorithms.HmacSha256);
            _jwtHeader = new JwtHeader(_signingCredentials);
            _tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidIssuer = _jwtOptions.Issuer,
                IssuerSigningKey = _issuerSecurityKey
            };
        }

        public JwtAuthToken Create(string userId)
        {
            var nowUtc = DateTime.UtcNow;
            var expires = nowUtc.AddMinutes(_jwtOptions.ExpireMinutes);
            var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
            var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
            var now = (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);
            var payload = new JwtPayload
            {
                { "sub", userId},
                { "iss", _jwtOptions.Issuer},
                { "iat", now},
                { "unique_name", userId},
                { "exp", exp },
            };

            var jwt = new JwtSecurityToken(_jwtHeader, payload);
            var token = _jwtSecurityToken.WriteToken(jwt);
            var jsonToken = new JwtAuthToken() { Token = token, ExpiredDate = exp};
            return jsonToken;
        }
    }
}
