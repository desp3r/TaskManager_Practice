using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TaskManager_Practice.EntityFramework;
using TaskManager_Practice.Models;
using TaskManager_Practice.Views.Windows;

namespace TaskManager_Practice.Views.Pages
{
    public partial class WorkersPage
    {
        public WorkersPage()
        {
            InitializeComponent();
            
            using var db = new MyDbContext();

            DataContext = this;

            WorkersGrid.ItemsSource = (from worker in db.Workers
                select worker).ToList();
            
        }

        private Worker SelectedWorker { get; set; }
        private void WorkersGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedWorker = WorkersGrid.SelectedItem as Worker;
        }

        private void AddWorkerClick(object sender, RoutedEventArgs e)
        {
            using var db = new MyDbContext();
            new AddWorkerWindow().ShowDialog();
            
            WorkersGrid.ItemsSource = (from worker in db.Workers
                select worker).ToList();
        }

        private void RemoveAllClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void RemoveProjectClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void EditProjectClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }


        private void RemoveWorkerClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void EditWorkerClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
