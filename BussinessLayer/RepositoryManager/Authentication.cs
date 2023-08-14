using BussinessLayer.Repository;
using Data.Model.Authentication;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Core;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace BussinessLayer.RepositoryManager
{
    public class Authentication : IAuthentication
    {
        private readonly IAuthenticationData _authenticationData;
        private readonly JWTSetting _jwtSetting;
        public Authentication(IAuthenticationData authenticationData,IOptions<JWTSetting> options)
        {
            _authenticationData = authenticationData;
            _jwtSetting = options.Value;


        }

        public string Authenticater(string name, string email)
        {
            
                var user = _authenticationData.Authenticater(name, email);
                    
                var result = "Unauthorized loginn";
                if (user == null)
                    return result;
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.UTF8.GetBytes(_jwtSetting.SecurityKey);
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role,"Admin")
                    }),
                    Expires = DateTime.Now.AddMinutes(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey),SecurityAlgorithms.HmacSha256)
                };
                var token = tokenhandler.CreateToken(tokenDescription);
                string finaltoken = tokenhandler.WriteToken(token);

            return finaltoken;

        }
    }
}
