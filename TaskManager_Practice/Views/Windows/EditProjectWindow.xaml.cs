using System;
using System.Windows;
using TaskManager_Practice.EntityFramework;
using TaskManager_Practice.Models;

namespace TaskManager_Practice.Views.Windows
{
    public partial class EditProjectWindow : Window
    {
        private Project insideProject;
        public EditProjectWindow(Project project)
        {
            insideProject = project;
            InitializeComponent();

            EditProjectName.Text = project.Name;
            // EditProjectTime.Text = project.Deadline.ToShortDateString();
            DataContext = this;
        }

        private void SaveChangesClick(object sender, RoutedEventArgs e)
        {
            var db = new MyDbContext();
            // db.EditProject(insideProject, EditProjectName.Text, DateTime.Parse(EditProjectTime.Text));
            Close();
        }
    }
}