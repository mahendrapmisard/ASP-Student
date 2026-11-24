
//using Microsoft.AspNetCore.Mvc;
//using StudentManagementApi.Models;
//using StudentManagementApi.Services;

//namespace StudentManagementApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentController : ControllerBase
//    {
//        private readonly IStudentService _studentService;

//        public StudentController(IStudentService studentService)
//        {
//            _studentService = studentService;
//        }

//        [HttpGet]
//        [Route("GetAllStudents")]
//        public IActionResult GetAllStudents()
//        {
//            var students = _studentService.GetAllStudents();

//            return Ok(students);
//        }

//        [HttpGet]
//        [Route("GetStudentbyID/{id}")]
//        public IActionResult GetStudentById(int id)
//        {
//            var student = _studentService.GetStudentById(id);

//            if (student == null)
//            {
//                return NotFound("Student not found");
//            }

//            return Ok(student);
//        }

//        [HttpPost]
//        public IActionResult AddStudent(Student student)
//        {
//            _studentService.AddStudent(student);

//            return Ok("Student added successfully");
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdateStudent(int id, Student student)
//        {
//            if (id != student.Id)
//            {
//                return BadRequest("Student ID mismatch");
//            }

//            var existingStudent = _studentService.GetStudentById(id);

//            if (existingStudent == null)
//            {
//                return NotFound("Student not found");
//            }

//            _studentService.UpdateStudent(student);

//            return Ok("Student updated successfully");
//        }

//        [HttpDelete("{id}")]
//        public IActionResult DeleteStudent(int id)
//        {
//            var student = _studentService.GetStudentById(id);

//            if (student == null)

//            {
//                return NotFound("Student not found");
//            }

//            _studentService.DeleteStudent(id);

//            return Ok("Student deleted successfully");
//        }
//    }
//}



using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.Models;
using StudentManagementApi.Services;

namespace StudentManagementApi.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET

        [HttpGet]
        [Route("GetAllStudents")]
        //https://localhost:7083/api/students/GetAllStudents
        public IActionResult GetAllStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet]
        [Route("GetStudentsById/{id:int}")]
        //https://localhost:7083/api/students/GetStudentsById/2
        public IActionResult GetStudentsById([FromRoute] int id)
        {
            var student = _studentService.GetStudentById(id);

            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }


        [HttpGet]
        [Route("SearchStudents")]
        //https://localhost:7083/api/students/SearchStudents?name=Mahendra&age=24
        public IActionResult SearchStudents(
            [FromQuery] string name,
            [FromQuery] int age)
        {
            return Ok(new { Name = name, Age = age });
        }

        [HttpGet]
        [Route("GetStudentFromHeader")]
        public IActionResult GetStudentFromHeader(
            [FromHeader(Name = "Name")] string name,
            [FromHeader(Name = "Course")] string course)
        {
            return Ok(new { Name = name, Course = course });
        }


        // POST - Different ways of receiving data

        [HttpPost]
        [Route("AddStudentFromBody")]
        public IActionResult AddStudentFromBody([FromBody] Student student)
        {
            _studentService.AddStudent(student);

            return Ok("Student added using FromBody");
        }

        [HttpPost]
        [Route("AddStudentFromRoute/{id:int}")]
        public IActionResult AddStudentFromRoute(
            [FromRoute] int id,
            [FromBody] Student student)
        {
            student.Id = id;

            _studentService.AddStudent(student);

            return Ok("Student added using Route and Body");
        }

        [HttpPost]
        [Route("AddStudentFromQuery")]
        public IActionResult AddStudentFromQuery(
            [FromQuery] int id,
            [FromQuery] string name,
            [FromQuery] int age,
            [FromQuery] string course)
        {
            Student student = new Student
            {
                Id = id,
                Name = name,
                Age = age,
                Course = course
            };

            _studentService.AddStudent(student);

            return Ok("Student added using Query");
        }

        [HttpPost]
        [Route("AddStudentFromHeader")]
        public IActionResult AddStudentFromHeader(
            [FromHeader(Name = "X-Student-Id")] int id,
            [FromHeader(Name = "X-User-Name")] string name,
            [FromHeader(Name = "X-User-Course")] string course,
            [FromQuery] int age)
        {
            Student student = new Student
            {
                Id = id,
                Name = name,
                Age = age,
                Course = course
            };

            _studentService.AddStudent(student);

            return Ok("Student added using Header and Query");
        }


        // PUT - Different ways of receiving data

        [HttpPut]
        [Route("UpdateStudentFromBody")]
        public IActionResult UpdateStudentFromBody([FromBody] Student student)
        {
            var existingStudent = _studentService.GetStudentById(student.Id);

            if (existingStudent == null)
                return NotFound("Student not found");

            _studentService.UpdateStudent(student);

            return Ok("Student updated using Body");
        }

        [HttpPut]
        [Route("UpdateStudentFromRouteAndBody/{id:int}")]
        public IActionResult UpdateStudentFromRouteAndBody(
            [FromRoute] int id,
            [FromBody] Student student)
        {
            if (id != student.Id)
                return BadRequest("Student ID mismatch");

            var existingStudent = _studentService.GetStudentById(id);

            if (existingStudent == null)
                return NotFound("Student not found");

            _studentService.UpdateStudent(student);

            return Ok("Student updated using Route and Body");
        }

        [HttpPut]
        [Route("UpdateStudentFromQuery")]
        public IActionResult UpdateStudentFromQuery(
            [FromQuery] int id,
            [FromQuery] string name,
            [FromQuery] int age,
            [FromQuery] string course)
        {
            var existingStudent = _studentService.GetStudentById(id);

            if (existingStudent == null)
                return NotFound("Student not found");

            Student student = new Student
            {
                Id = id,
                Name = name,
                Age = age,
                Course = course
            };

            _studentService.UpdateStudent(student);

            return Ok("Student updated using Query");
        }

        [HttpPut]
        [Route("UpdateStudentFromHeader/{id:int}")]
        public IActionResult UpdateStudentFromHeader(
            [FromRoute] int id,
            [FromHeader(Name = "X-User-Name")] string name,
            [FromHeader(Name = "X-User-Course")] string course,
            [FromQuery] int age)
        {
            var existingStudent = _studentService.GetStudentById(id);

            if (existingStudent == null)
                return NotFound("Student not found");

            Student student = new Student
            {
                Id = id,
                Name = name,
                Age = age,
                Course = course
            };

            _studentService.UpdateStudent(student);

            return Ok("Student updated using Route, Header and Query");
        }


        // DELETE

        [HttpDelete]
        [Route("DeleteStudentById/{id:int}")]
        public IActionResult DeleteStudentById([FromRoute] int id)
        {
            var student = _studentService.GetStudentById(id);

            if (student == null)
                return NotFound("Student not found");

            _studentService.DeleteStudent(id);

            return Ok("Student deleted successfully");
        }
    }
}
