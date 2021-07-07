using System.Linq;
using System.Windows;
using TaskManager_Practice.EntityFramework;
using TaskManager_Practice.Models;

namespace TaskManager_Practice.Views.Windows
{
    public partial class WorkerTasks : Window
    {
        public WorkerTasks(Worker _worker)
        {
            InitializeComponent();
            
            using var db = new MyDbContext();
            
            WorkerTasksGrid.ItemsSource = (from task in db.Tasks
                where _worker.Id == task.WorkerId select task ).ToList();
        }
    }
}