using System;
using System.Windows.Forms;
using TestApp.DataContext;

namespace TestApp.Views
{
    public partial class MainForm : Form
    {
        private IDataContext _context;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(IDataContext context) : this()
        {
            _context = context;
        }

        private void LoadDataButtonClick(object sender, EventArgs e)
        {
            SetDataGridSource();
        }

        private async void AddButtonClick(object sender, EventArgs e)
        {
            await _context.AddOnUpdateStudentAsync(new Models.Student() { Name = nameTextBox.Text, CourseNo = 1 });
            SetDataGridSource();
            nameTextBox.Text = "";
        }

        async void SetDataGridSource()
        {
            this.mainDataGrid.DataSource = await _context.GetAllStudentsAsync();
        }
    }
}
