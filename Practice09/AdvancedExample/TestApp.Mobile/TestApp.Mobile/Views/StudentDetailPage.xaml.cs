using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TestApp.Models;
using TestApp.Mobile.ViewModels;

namespace TestApp.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class StudentDetailPage : ContentPage
    {
        StudentDetailViewModel viewModel;

        public StudentDetailPage(StudentDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public StudentDetailPage()
        {
            InitializeComponent();

            var student = new Student
            {
                Name = "Item 1",
                CourseNo = 1
            };

            viewModel = new StudentDetailViewModel(student);
            BindingContext = viewModel;
        }
    }
}