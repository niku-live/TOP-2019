using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TestApp.Mobile.Views;

namespace TestApp.Mobile.ViewModels
{
    public class StudentsViewModel : BaseViewModel
    {
        public ObservableCollection<TestApp.Models.Student> Students { get; set; }
        public Command LoadStudentsCommand { get; set; }

        public StudentsViewModel()
        {
            Title = "Browse";
            Students = new ObservableCollection<TestApp.Models.Student>();
            LoadStudentsCommand = new Command(async () => await ExecuteLoadStudentsCommand());

            MessagingCenter.Subscribe<NewStudentPage, TestApp.Models.Student>(this, "AddStudent", async (obj, student) =>
            {
                var newStudent = student as TestApp.Models.Student;
                Students.Add(newStudent);
                await DataStore.AddOnUpdateStudentAsync(student);
            });
        }

        async Task ExecuteLoadStudentsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Students.Clear();
                var students = await DataStore.GetAllStudentsAsync();
                foreach (var student in students)
                {
                    Students.Add(student);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}