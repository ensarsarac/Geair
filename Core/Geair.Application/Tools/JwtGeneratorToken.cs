using Geair.Application.Mediator.Results.UserResults;
using Geair.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Geair.Application.Tools
{
    public class JwtGeneratorToken
    {
        public static JwtResponseModel GenerateToken(UserLoginQueryResult model)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenModel.Key));
            var dateTimeNow = DateTime.UtcNow.AddHours(JwtTokenModel.Expire);
            List<Claim> claims = new List<Claim>()
            {
                new Claim("fullname", model.NameSurname),
                    new Claim(ClaimTypes.Email, model.Email),                    
                    new Claim(ClaimTypes.NameIdentifier,model.Id.ToString()),
                    new Claim(ClaimTypes.Role,model.Role),
            };
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                    issuer: JwtTokenModel.ValidIssuer,
                    audience: JwtTokenModel.ValidAudience,
                    claims: claims,
                    notBefore: dateTimeNow,
                    expires: dateTimeNow.Add(TimeSpan.FromMinutes(500)),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtResponseModel responseModel = new JwtResponseModel();
            responseModel.Token = handler.WriteToken(jwtSecurityToken);
            responseModel.ExpireDate = dateTimeNow.Add(TimeSpan.FromMinutes(500));
            return responseModel;
        }

    }
}
