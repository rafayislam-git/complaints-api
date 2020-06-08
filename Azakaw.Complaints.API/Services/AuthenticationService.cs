using Azakaw.Complaints.API.DataProviders;
using Azakaw.Complaints.API.HelperModels;
using Azakaw.Complaints.API.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Azakaw.Complaints.API.Services
{
    public interface IAuthenticationService
    {
        TokenModel Authenticate(string username, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppSettings _appSettings;
        private IUserDataAdapter _userDataAdapter;

        public AuthenticationService(IOptions<AppSettings> appSettings, IUserDataAdapter userDataAdapter)
        {
            _appSettings = appSettings.Value;
            _userDataAdapter = userDataAdapter;
        }
        public TokenModel Authenticate(string username, string password)
        {
            try
            {
                TokenModel tokenModel = new TokenModel();
                tokenModel.Expiration = DateTime.UtcNow.AddDays(7);
                var user = _userDataAdapter.GetUserByUserNameAndPassword(username, password);
                if (user == null)
                    return null;

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.AppSecret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())

                    }),
                    Expires = tokenModel.Expiration,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                tokenModel.Token = tokenHandler.WriteToken(token);
                tokenModel.UserId = user.Id;
                return tokenModel;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
