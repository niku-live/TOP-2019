using System.Collections.Generic;
using TestApp.Models;

namespace TestApp.DataContext
{
    public class FakeDataContext : IDataContext
    {
        public IEnumerable<Student> GetAllStudents()
        {
            return new List<Student>()
            {
                new Student() { Id = 1, Name = "Jonas", CourseNo = 1},
                new Student() { Id = 2, Name = "Petras", CourseNo = 1}
            };

        }
    }
}
