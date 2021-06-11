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
using TaskManager_Practice.Models;

namespace TaskManager_Practice.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProjectWindow.xaml
    /// </summary>
    public partial class AddProjectWindow : Window
    {
        public AddProjectWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void DataGridWorkers_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void AddProject(object sender, RoutedEventArgs e)
        {
            var db = new MyDbContext();
            db.AddProject(new Project(infoName.Text));
            db.SaveChanges();
            this.Close();
        }
    }
}
