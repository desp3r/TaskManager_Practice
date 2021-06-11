using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TaskManager_Practice.EntityFramework;
using TaskManager_Practice.Models;
using TaskManager_Practice.Views.Windows;

namespace TaskManager_Practice.Views.Pages
{
    public partial class ProjectsPage
    {
        public ProjectsPage()
        {
            InitializeComponent();

            using var db = new MyDbContext();

            DataContext = this;

            MainGrid.ItemsSource = (from project in db.Projects
                select project).ToList();
        }

        private Project SelectedProject { get; set; }
        
        private void MainGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedProject = MainGrid.SelectedItem as Project;
        }

        private void RemoveProject(object sender, RoutedEventArgs e)
        {
            using var db = new MyDbContext();

            db.RemoveProject(SelectedProject);

            db.SaveChanges();


            MainGrid.ItemsSource = (from project in db.Projects
                select project).ToList();
        }
        
        
        
        

        private void AddProjectClick(object sender, RoutedEventArgs e)
        {
            using var db = new MyDbContext();

            db.Projects.Add(new()
            {
                Name = "Курсовая"
            });

            db.SaveChanges();


            MainGrid.ItemsSource = (from project in db.Projects
                select project).ToList();
        }

        private void RemoveAllClick(object sender, RoutedEventArgs e)
        {
            using var db = new MyDbContext();

            db.RemoveProjects();

            db.SaveChanges();


            MainGrid.ItemsSource = (from project in db.Projects
                select project).ToList();
        }


        private void EditProject(object sender, RoutedEventArgs e)
        {
            using var db = new MyDbContext();
            new EditProjectWindow(SelectedProject).ShowDialog();
            MainGrid.ItemsSource = (from project in db.Projects
                select project).ToList();
        }
    }
}