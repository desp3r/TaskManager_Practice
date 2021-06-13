using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TaskManager_Practice.EntityFramework;
using TaskManager_Practice.Models;
using TaskManager_Practice.Views.Windows;

namespace TaskManager_Practice.Views.Pages
{
    public partial class TasksPage : Page
    {
        public TasksPage()
        {
            InitializeComponent();
            
            using var db = new MyDbContext();
            
            DataContext = this;

            TasksGrid.ItemsSource = (from task in db.Tasks select task).ToList();
        }

        private Task SelectedTask { get; set; }
        private void TasksGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedTask = TasksGrid.SelectedItem as Task;
        }

        private void AddTaskClick(object sender, RoutedEventArgs e)
        {
            
            new AddTaskWindow().ShowDialog();

            using var db = new MyDbContext();
            
            TasksGrid.ItemsSource = (from task in db.Tasks select task).ToList();
        }

        private void RemoveTaskClick(object sender, RoutedEventArgs e)
        {
            using var db = new MyDbContext();

            if (SelectedTask != null)
            {
                db.RemoveTask(SelectedTask);
            }
            
            TasksGrid.ItemsSource = (from task in db.Tasks select task).ToList();

        }

        private void RemoveAllClick(object sender, RoutedEventArgs e)
        {
            using var db = new MyDbContext();
            
            db.RemoveTasks();
            
            TasksGrid.ItemsSource = (from task in db.Tasks select task).ToList();
        }

        private void FindById(object sender, RoutedEventArgs e)
        {
            if (FindTaskById.Text.Length > 0)
            {
                using var db = new MyDbContext();
                Task result =db.SelectTaskById(FindTaskById.Text);
                if (result != null)
                {
                    MessageBox.Show("Id: " + result.Id + " Name: " + result.Name + " Deadline: " + result.EndTime.ToString());
                }
                else
                {
                    MessageBox.Show("No matches!");
                }
            }
            else
            {
                MessageBox.Show("Enter name to find");
            }
        }
    }
}