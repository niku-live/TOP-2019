using System;

using TestApp.Models;

namespace TestApp.Mobile.ViewModels
{
    public class StudentDetailViewModel : BaseViewModel
    {
        public Student Student { get; set; }
        public StudentDetailViewModel(Student student = null)
        {
            Title = student?.Name;
            Student = student;
        }
    }
}
