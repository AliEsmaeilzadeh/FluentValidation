using Microsoft.Extensions.Options;
using Paraph_Food.Application.Common;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Domain.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Paraph_Food.Application.Services.Users.Common
{
    public class GenerateTokenService : IGenerateTokenService
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly AppSettings _appSettings;
        public GenerateTokenService(JwtIssuerOptions jwtOptions, AppSettings appSettings)
        {
            _jwtOptions = jwtOptions;
            _appSettings = appSettings;
        }
        public string Execute(long id, string[] roles)
        {
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Iat, _jwtOptions.IssuedAt.ToString(), ClaimValueTypes.Integer64),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");

            claimsIdentity.AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));


            var jwt = new JwtSecurityToken(
              issuer: "Paraph",
              audience: _appSettings.Urls.ServerUrl,
              claims: claimsIdentity.Claims,
              notBefore: _jwtOptions.NotBefore,
              //expires : DateTime.Now.AddMinutes(30),
              signingCredentials: _jwtOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
