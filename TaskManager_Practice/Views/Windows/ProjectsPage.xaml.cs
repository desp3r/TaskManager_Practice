﻿using TaskManager_Practice.ViewModels;

namespace TaskManager_Practice.Views.Windows
{
    public partial class ProjectsPage
    {
        public ProjectsPage()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
