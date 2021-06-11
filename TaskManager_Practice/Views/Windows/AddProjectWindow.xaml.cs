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
using TaskManager_Practice.Models;

namespace TaskManager_Practice.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProjectWindow.xaml
    /// </summary>
    public partial class AddProjectWindow : Window
    {
        public AddProjectWindow(Project project)
        {
            InitializeComponent();
            DataContext = this;
            infoName.Text = project.Name;
            
        }

        private void DataGridWorkers_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
