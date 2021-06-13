using System;
using System.Windows;
using TaskManager_Practice.ViewModels;

namespace TaskManager_Practice
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            App.Initialize(this);
            
        }
    }
}
