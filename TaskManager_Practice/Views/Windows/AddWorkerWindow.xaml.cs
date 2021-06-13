using System.Windows;
using TaskManager_Practice.EntityFramework;
using TaskManager_Practice.Infrastructure;
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
            using var db = new MyDbContext();

            var check = db.AddWorker(AddWorkerName.Text, AddWorkerSurname.Text,
                AddWorkerPosition.Text, AddWorkerNumber.Text);

            if (check == Result.Ok)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Input!");
            }
            
        }
    }
}