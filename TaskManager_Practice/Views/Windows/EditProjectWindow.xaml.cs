using System;
using System.Windows;
using TaskManager_Practice.EntityFramework;
using TaskManager_Practice.Infrastructure;
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
            
            DataContext = this;
            
            EditProjectName.Text = project.Name;
            EditProjectTime.SelectedDate = project.Deadline;
        }

        private void SaveChangesClick(object sender, RoutedEventArgs e)
        {
            var db = new MyDbContext();
            var check = db.EditProject(insideProject, EditProjectName.Text, EditProjectTime.SelectedDate.Value.Date);

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