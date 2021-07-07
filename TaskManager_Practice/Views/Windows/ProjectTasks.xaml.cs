using System.Linq;
using System.Windows;
using TaskManager_Practice.EntityFramework;
using TaskManager_Practice.Models;

namespace TaskManager_Practice.Views.Windows
{
    public partial class ProjectTasks : Window
    {
        public ProjectTasks(Project _project)
        {
            InitializeComponent();

            using var db = new MyDbContext();
            
            ProjectTasksGrid.ItemsSource = (from task in db.Tasks
                where _project.Id == task.PtojectId select task ).ToList();
        }
    }
}