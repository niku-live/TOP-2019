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
            this.mainDataGrid.DataSource = _context.GetAllStudents();
        }
    }
}
