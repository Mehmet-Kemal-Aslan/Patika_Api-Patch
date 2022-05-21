using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;

namespace StudentWebApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // Üzerinde çalışmak için veri seti
        private static List<Student> StudentList = new List<Student>()
        {
            new Student
            {
                Id = 1,
                Name = "Mehmet Kemal",
                Surname = "Aslan",
                Grade = 6
            },
            new Student
            {
                Id = 2,
                Name = "Arif Cemal",
                Surname = "Özcan",
                Grade = 9
            },
            new Student
            {
                Id = 3,
                Name = "Sefa",
                Surname = "Çaksu",
                Grade = 10
            }
        };

        // Gets all records
        [HttpGet]
        public List<Student> GetStundentList()
        {
            var studentList = StudentList.OrderBy(x => x.Id).ToList<Student>();
            return studentList;
        }

        // Gets one record by id
        [HttpGet("{id}")]
        public Student GetStundentbyId(int id)
        {
            var student = StudentList.Where(student => student.Id == id).SingleOrDefault();
            return student;
        }

        // posts a new record -- [FromBody]
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student newStudent)
        {
            var student = StudentList.SingleOrDefault(student => student.Id == newStudent.Id);
            if (student != null)
                return BadRequest();
            StudentList.Add(newStudent);
            return Ok();
        }

        // updates a record by id -- [FromBody]
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = StudentList.SingleOrDefault(student => student.Id == id);
            if (student == null)
                return BadRequest();
            student.Name = updatedStudent.Name != default ? updatedStudent.Name : student.Name;
            student.Surname = updatedStudent.Surname != default ? updatedStudent.Surname : student.Surname;
            student.Grade = Convert.ToInt32(updatedStudent.Grade);
            student.Note = updatedStudent.Note != default ? updatedStudent.Note : student.Note;
            return Ok();
        }

        // Deletes a record by id -- [FromQuery]
        [HttpDelete]
        public IActionResult DeleteStudent([FromQuery] int id)
        {
            var student = StudentList.SingleOrDefault(student => student.Id == id);
            if (student == null)
                return BadRequest();
            StudentList.Remove(student);
            return Ok();
        }

        // Updates name of a record by id -- [FromBody]
        [HttpPatch("{id}")]
        public IActionResult UpdateStudentName(int id, [FromBody] string name)
        {
            var student = StudentList.SingleOrDefault(student => student.Id == id);
            if (student is null)
                return BadRequest();
            student.Name = name != default ? name : student.Name;
            return Ok();
        }

        // Filters records by name
        [HttpGet("list")]
        public ActionResult<List<Student>> GetByName([FromQuery] string Name)
        {
            var filteredStudents = StudentList.FindAll(student => student.Name.Contains(Name));
            return Ok(filteredStudents);
        }
    }
}
