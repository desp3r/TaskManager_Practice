using System.Windows;
using TaskManager_Practice.EntityFramework;
using TaskManager_Practice.Models;

namespace TaskManager_Practice.Views.Windows
{
    public partial class EditProjectWindow : Window
    {
        private Project _project { get; set; }
        
        public EditProjectWindow(Project project)
        {
            _project = project;
            InitializeComponent();
            EditProjectName.Text = _project.Name;
            DataContext = this;
        }

        private void SaveChangesClick(object sender, RoutedEventArgs e)
        {
            var db = new MyDbContext();
            _project.Name = EditProjectName.Text;
            db.EditProject(_project);
            Close();
        }
    }
}