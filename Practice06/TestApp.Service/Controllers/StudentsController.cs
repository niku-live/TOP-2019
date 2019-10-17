using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class StudentsController : ApiController
    {
        public IEnumerable<Student> LoadStudents()
        {
            return new List<Student>()
            {
                new Student() { Id = 1, Name = "Jonas", CourseNo = 1},
                new Student() { Id = 2, Name = "Petras", CourseNo = 1}
            };

        }

        public IEnumerable<Student> GetAllStudents()
        {
            return LoadStudents();
        }

        public IHttpActionResult GetStudent(int id)
        {
            var student = LoadStudents().FirstOrDefault((p) => p.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}
