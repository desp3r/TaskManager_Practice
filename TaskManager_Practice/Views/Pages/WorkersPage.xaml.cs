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
        
        private void EditWorkerClick(object sender, RoutedEventArgs e)
        {
            if (SelectedWorker != null)
            {
                new EditWorkerWindow(SelectedWorker).ShowDialog();
            }
            
            using var db = new MyDbContext();
            
            WorkersGrid.ItemsSource = (from worker in db.Workers
                select worker).ToList();
        }
        
        private void RemoveAllClick(object sender, RoutedEventArgs e)
        {
            using var db = new MyDbContext();
            
            db.RemoveWorkers();
            
            WorkersGrid.ItemsSource = (from worker in db.Workers
                select worker).ToList();
        }
        
        private void RemoveWorkerClick(object sender, RoutedEventArgs e)
        {
            using var db = new MyDbContext();

            if (SelectedWorker != null)
            {
                db.RemoveWorker(SelectedWorker);
            }
            
            WorkersGrid.ItemsSource = (from worker in db.Workers
                select worker).ToList();
        }

        private void FindBySurname(object sender, RoutedEventArgs e)
        {
            if (FindBySurnameWorker.Text.Length > 0)
            {
                using var db = new MyDbContext();
                Worker result =db.SelectWorkerBySurname(FindBySurnameWorker.Text);
                if (result != null)
                {
                    MessageBox.Show("Id: " + result.Id + " Name: " + result.Name + " Surname: " + result.Surname + 
                                    " Position: " + result.Position + " Phone: " + result.PhoneNumber);
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

        private void WorkerShowTasks(object sender, RoutedEventArgs e)
        {
            if (SelectedWorker != null)
            {
                new WorkerTasks(SelectedWorker).ShowDialog();
            }
        }
    }
}
