using Indra.Application.Services.Interfaces;
using Indra.Domain.Entities;
using Indra.Web.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Indra.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _IStudentService;

        public StudentController(IStudentService IStudentService)
        {
            _IStudentService = IStudentService;
        }
        // GET: api/<StudentController>
        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IEnumerable<StudentDto>> Get()
        {
            IEnumerable <StudentEntity> studentsGet = await _IStudentService.GetAllStudents();

            return StudentDto.MaptoStudentDtoList(studentsGet);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<StudentDto> Get(int id)
        {
            StudentDto studentDto = StudentDto.MaptoStudentDto(await _IStudentService.GetStudentById(id));
            return studentDto;
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentDto studentDto)
        {
            StudentEntity studentAdded = await _IStudentService.AddStudent(StudentDto.MaptoStudentEntity(studentDto));

            return Ok(StudentDto.MaptoStudentDto(studentAdded));
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudentDto studentDto)
        {
            StudentEntity studentUpdate = await _IStudentService.UpdateStudent(id, StudentDto.MaptoStudentEntity(studentDto));

            return Ok(StudentDto.MaptoStudentDto(studentUpdate));
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            _IStudentService.DeleteStudent(id);
        }
    }
}
