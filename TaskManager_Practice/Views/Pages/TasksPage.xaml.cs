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


        private void EditTaskClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void RemoveTaskClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void RemoveAllClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}