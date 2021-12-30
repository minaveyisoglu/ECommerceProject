using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Core.Entities.Concrete;
using Core.Utilities.Extensions;
using Core.Utilities.Security.Encryption;
using Entity.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }//appsetting.json daki token okumak için kullanılır
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;//Configuration dosyası vasıtasıyla TokenOptions dan gelen bilgileri okucaz.
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            //.Net Core TokenOptions bilgilerini alıp  Get<TokenOptions>  TokenOptions nesnesine bind ediyor
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //Token encrypt ederken kendi bildiğimiz özel bir anahtara ihtiyacımız var
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var securityKey =SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            //Token bilgilerini kullanıcı bilgilerini SigningCredentials bilgilerini,UserOperationClaims kullanarak bir adet Token oluşturucaz
            //Hangi Token bilgileri, hangi kullanıcı için,hangi SigningCredentials ile ve hangi rolleri içeriyorsa bunları parametre olarak verip bir adet Token üreticez.
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            //jwt bize lazım olan kısımları
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                //expires: tokenOptions.AccessTokenExpiration,//tarihe çevrilmeli
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,//Token'ın expiration bilgisi şuandan önceyse geçerli değil(şart)
                                        //claims: operationClaims,//claim türünde olması gerekiyor
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
                );
            return jwt;
        }
        //Claim set edebileceğimiz bir operasyon yazıcaz
        private IEnumerable<Claim>SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            //claims.Add(new Claim("email", user.Email));//extension ile iyileştirilecek.
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName}{user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }
    } 
}
