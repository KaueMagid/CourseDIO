using Course.api.Models.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Course.api.Controllers
{
    [Route("api/v1/course")]
    [ApiController]
    [Authorize]
    public class CoursesController : ControllerBase
    {
        /// <summary>
        /// Este serviço permite cadastrar, curso para o usuário autenticado
        /// </summary>
        /// <param name="courseViewModelInput"></param>
        /// <returns>Retorna status 201 e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucess")]
        [SwaggerResponse(statusCode: 401, description: "Not authorized")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CourseViewModelInput courseViewModelInput)
        {
            //var codeUser = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", courseViewModelInput);
        }

        /// <summary>
        /// Este serviço permite obter todos os cursos ativos do usuário
        /// </summary>
        /// <returns>retorna status ok e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucess")]
        [SwaggerResponse(statusCode: 401, description: "Not authorized")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var courses = new List<CourseViewModelOutput>();
            //var codeUser = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            courses.Add(new CourseViewModelOutput()
            {
                Name = "Course 1",
                Description = "Description 1",
                Login =""// codeUser.ToString()
            }); 
            courses.Add(new CourseViewModelOutput()
            {
                Name = "Course 2",
                Description = "Description 2",
                Login =""// codeUser.ToString()
            }); 
            courses.Add(new CourseViewModelOutput()
            {
                Name = "Course 3",
                Description = "Description 3",
                Login = ""//codeUser.ToString()
            });

            return Ok(courses);
        }
    }
}
