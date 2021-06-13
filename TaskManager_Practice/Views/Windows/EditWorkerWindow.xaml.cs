using System.Windows;
using TaskManager_Practice.EntityFramework;
using TaskManager_Practice.Infrastructure;
using TaskManager_Practice.Models;

namespace TaskManager_Practice.Views.Windows
{
    public partial class EditWorkerWindow : Window
    {
        private Worker insideWorker { get; set; }
        
        public EditWorkerWindow(Worker worker)
        {
            InitializeComponent();

            insideWorker = worker;

            DataContext = this;

            EditWorkerName.Text = worker.Name;
            EditWorkerSurname.Text = worker.Surname;
            EditWorkerPosition.Text = worker.Position;
            EditWorkerNumber.Text = worker.PhoneNumber;
        }


        private void EditWorkerClick(object sender, RoutedEventArgs e)
        {
            using var db = new MyDbContext();

            var check = db.EditWorker(insideWorker, EditWorkerName.Text, EditWorkerSurname.Text,
                EditWorkerPosition.Text, EditWorkerNumber.Text);

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