using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.api.Models.Users

namespace Course.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
            return Created("", loginViewModelInput);
        }
    }
}
