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
            InfoName.Text = _project.Name;
            DataContext = this;
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            var db = new MyDbContext();
            _project.Name = InfoName.Text;
            db.EditProject(_project);
            Close();
        }
    }
}