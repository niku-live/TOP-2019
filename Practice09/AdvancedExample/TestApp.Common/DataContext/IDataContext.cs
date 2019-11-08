using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.DataContext
{
    public interface IDataContext
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> AddOnUpdateStudentAsync(Student student);
    }
}