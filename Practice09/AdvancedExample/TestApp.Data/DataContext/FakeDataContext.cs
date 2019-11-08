using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.DataContext
{
    public class FakeDataContext : IDataContext
    {
        private List<Student> _students = new List<Student>()
            {
                new Student() { Id = 1, Name = "Jonas", CourseNo = 1},
                new Student() { Id = 2, Name = "Petras", CourseNo = 1}
            };

        int _lastId = 2;

        private Student GetStudentById(int id) => _students.FirstOrDefault(s => s.Id == id);

        private Student UpdateStudent(Student existing, Student template)
        {
            existing.CourseNo = template.CourseNo;
            existing.Name = template.Name;
            return existing;
        }

        private void AssignNewId(Student student)
        {
            _lastId++;
            student.Id = _lastId;
        }

        private Student AddStudent(Student student)
        {
            _students.Add(student);
            if (student.Id == null)
            {
                AssignNewId(student);
            }
            return student;
        }

        private Student AddOnUpdateStudent(Student student)
        {
            var existing = student.Id == null? null : GetStudentById(student.Id.Value);
            existing = existing == null ? AddStudent(student) : UpdateStudent(existing, student);
            return existing;
        }

        private IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await Task.Run(() => GetAllStudents());
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await Task.Run(() => GetStudentById(id));
        }

        public async Task<Student> AddOnUpdateStudentAsync(Student student)
        {
            return await Task.Run(() => AddOnUpdateStudent(student));
        }
    }
}
