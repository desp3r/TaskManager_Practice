using System.Windows;
using TaskManager_Practice.EntityFramework;
using TaskManager_Practice.Models;

namespace TaskManager_Practice.Views.Windows
{
    public partial class AddWorkerWindow : Window
    {
        public AddWorkerWindow()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void AddWorkerClick(object sender, RoutedEventArgs e)
        {
            var db = new MyDbContext();
            db.Add(new Worker(workerName.Text, workerSurname.Text));
            db.SaveChanges();
            this.Close();
        }
    }
}