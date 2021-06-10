using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TaskManager_Practice.Models;
using TaskManager_Practice.Views.Windows;

namespace TaskManager_Practice.Views.Pages
{
    public partial class ProjectsPage
    {
        public ProjectsPage()
        {
            InitializeComponent();

            var projects = new List<Project>()
            {
                new()
                {
                    Name = "Oleg"
                },
                new()
                {
                    Name = "Oleg2"
                }
            };

            DataContext = this;

            MainGrid.ItemsSource = projects;
        }

        
        private void MainGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var project = MainGrid.SelectedItem as Project;
            new AddProjectWindow(project).Show();
        }
    }
}