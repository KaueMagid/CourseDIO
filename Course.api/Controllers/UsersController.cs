using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.api.Models;
using Course.api.Filters;
using Course.api.Models.Users;
using Swashbuckle.AspNetCore.Annotations;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Course.api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Esse serviço permite autenticar um usuário cadastrado e ativo.
        /// </summary>
        /// <param name="loginViewModelInput"></param>
        /// <returns>Retorna o status OK, dados do usuario e o token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 200,description:"Sucess", Type =typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Required fields", Type = typeof(ValidateFieldsViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Error", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("login")]
        [CustomModelStateValidation]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
            var userViewModelOutput = new UserViewModelOutput() 
            { 
                Code = 1,
                Login = "Kaue Magid",
                Email = "magidsalem@hotmail.com"

            };

            var secret = Encoding.ASCII.GetBytes("Q@_TR5sZ}'XO%qg#fD1-%PF\\V+T'@uNGSF*|~1|&n>9Z'%4,]v3OAOw$1Q^9?6");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userViewModelOutput.Code.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, userViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, userViewModelOutput.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokendescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return Ok(new
            {
                Token = token,
                User = userViewModelOutput
            });
        }

        [HttpPost]
        [Route("register")]
        [CustomModelStateValidation]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {
            return Created("", registerViewModelInput);
        }
    }
}
