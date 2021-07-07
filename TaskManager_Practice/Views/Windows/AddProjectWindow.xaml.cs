using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using TaskManager_Practice.EntityFramework;
using TaskManager_Practice.Infrastructure;
using TaskManager_Practice.Models;

namespace TaskManager_Practice.Views.Windows
{
    
    public partial class AddProjectWindow : Window
    {
        public AddProjectWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void AddProjectClick(object sender, RoutedEventArgs e)
        {
            var db = new MyDbContext();
            var result = db.AddProject(AddProjectName.Text, DatePickerProject.SelectedDate.Value.Date);
            if (result == Result.Ok)
            {
                this.Close();
            }
            else if(result == Result.Error)
            {
                MessageBox.Show("Invalid Input!!");
            }
        }
    }
}
