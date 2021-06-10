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
        public string Name { get; set; }
        public AddProjectWindow(Project project)
        {
            InitializeComponent();
            TextBlock.Text = project.Name;
            DataContext = this;
        }
    }
}
