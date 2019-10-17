using System.Collections.Generic;
using TestApp.Models;

namespace TestApp.DataContext
{
    public interface IDataContext
    {
        IEnumerable<Student> GetAllStudents();
    }
}