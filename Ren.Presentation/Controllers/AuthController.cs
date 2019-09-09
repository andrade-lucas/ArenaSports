using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Ren.Domain.Commands.Inputs.Users;
using Ren.Domain.Handlers;
using Ren.Domain.Repositories;
using Ren.Presentation.Configurations;

namespace Ren.Presentation.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserHandler _handler;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;

        public AuthController(IUserRepository repository, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            _repository = repository;
            _handler = new UserHandler(_repository);
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }

        [HttpPost]
        [Route("v1/account/login")]
        public object Login([FromBody] AuthCommand command)
        {
            dynamic user = _handler.Handle(command);
            if (user.Status)
            {
                string id = user.Data.Id.ToString();
                string name = (string)user.Data.Name;
                string email = (string)user.Data.Email;
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(name, "Name"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.NameId, id),
                        new Claim(JwtRegisteredClaimNames.UniqueName, name),
                        new Claim(JwtRegisteredClaimNames.Email, email)
                    }
                );
                DateTime createDate = DateTime.Now;
                DateTime expireDate = createDate + TimeSpan.FromHours(1);
                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    SigningCredentials = _signingConfigurations.Credentials,
                    Subject = identity,
                    NotBefore = createDate,
                    Expires = expireDate
                });
                var token = handler.WriteToken(securityToken);
                return new
                {
                    status = true,
                    created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = expireDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "Seja Bem-Vindo",
                    user = user
                };
            }
            else
            {
                return new
                {
                    status = false,
                    message = "Usuário não encontrado, por favor verifique se os dados estão corretos"
                };
            }
        }
    }
}