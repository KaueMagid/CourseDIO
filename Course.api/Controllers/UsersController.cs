using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.api.Models.Users;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerResponse(statusCode: 400, description: "Campos Obrigatórios", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 500, description: "Error", Type = typeof(LoginViewModelInput))]
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
            return Ok(loginViewModelInput);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {
            return Created("", registerViewModelInput);
        }
    }
}
