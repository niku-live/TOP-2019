using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class StudentsController : ApiController
    {
        static System.Lazy<DataContext.IDataContext> _dataContext = new System.Lazy<DataContext.IDataContext>(() => new DataContext.FakeDataContext());
        static DataContext.IDataContext DataContext
        {
            get => _dataContext.Value;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await DataContext.GetAllStudentsAsync();
        }

        public async Task<IHttpActionResult> GetStudentAsync(int id)
        {
            var student = await DataContext.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        public async Task<IHttpActionResult> Post(Student student)
        {
            return Ok(await DataContext.AddOnUpdateStudentAsync(student));
        }
    }
}
