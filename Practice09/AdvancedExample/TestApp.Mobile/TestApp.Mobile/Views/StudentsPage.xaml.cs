using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TestApp.Models;
using TestApp.Mobile.Views;
using TestApp.Mobile.ViewModels;

namespace TestApp.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class StudentsPage : ContentPage
    {
        StudentsViewModel viewModel;

        public StudentsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new StudentsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var student = args.SelectedItem as Student;
            if (student == null)
                return;

            await Navigation.PushAsync(new StudentDetailPage(new StudentDetailViewModel(student)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewStudentPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Students.Count == 0)
                viewModel.LoadStudentsCommand.Execute(null);
        }
    }
}