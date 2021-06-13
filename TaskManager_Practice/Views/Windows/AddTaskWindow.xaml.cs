using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TaskManager_Practice.EntityFramework;
using TaskManager_Practice.Infrastructure;
using TaskManager_Practice.Models;

namespace TaskManager_Practice.Views.Windows
{
    public partial class AddTaskWindow : Window
    {
        public AddTaskWindow()
        {
            InitializeComponent();

            using var db = new MyDbContext();

            DataContext = this;

            WorkerBox.ItemsSource = (from worker in db.Workers
                select worker.Surname).ToList();

            ProjectBox.ItemsSource = (from project in db.Projects
                select project.Name ).ToList();
            
        }


        private string SelectedWorker { get; set; }
        private void WorkerBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedWorker = WorkerBox.SelectedItem as string;
        }
        
        private string SelectedProject { get; set; }

        private void ProjectBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedProject = ProjectBox.SelectedItem as string;
        }

        private void AddTaskClick(object sender, RoutedEventArgs e)
        {
            using var db = new MyDbContext();

            if (SelectedWorker == null || SelectedProject == null)
            {
                MessageBox.Show("Please, select worker and project!!");
            }

            var check = db.AddTask( AddTaskName.Text, DatePickerTask.SelectedDate.Value.Date, 
                db.SelectWorkerBySurname(SelectedWorker), 
                db.SelectProjectByName(SelectedProject));
            
            if (check == Result.Ok)
            {
                this.Close();
                
                
                
            }else if (check == Result.Error)
            {
                MessageBox.Show("Invalid Input!");
            }
        }
    }
}