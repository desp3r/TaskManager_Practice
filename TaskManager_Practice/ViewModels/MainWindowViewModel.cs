using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using TaskManager_Practice.Infrastructure.Commands;
using TaskManager_Practice.ViewModels.Base;
using TaskManager_Practice.Views.Windows;

namespace TaskManager_Practice.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        // Заголовок окна
        #region Title

        private string _Title;

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion


        #region Commands

        public ICommand OpenNewWindow { get; }

        private bool CanOpenChildWindow(object ob) => true;

        private void OnOpenChildWindow(object ob)
        {
            AddProjectWindow addProjectWindow = new AddProjectWindow();
            addProjectWindow.Show();
        }

        internal enum Pages
        {
            One, Two
        }

        
        
        private Page1 page1 = new Page1();

        public ICommand SwitchPage { get; }

        private UserControl page;
        public UserControl Page
        {
            get { return page; }
            set
            {
                page = value;
                OnPropertyChanged();
            }
        }

        private bool CanSwitchPage(object ob) => true;

        private void OnSwitchPage(object ob)
        {
           
        }
        
        public ICommand OpenPage { get; }

        private bool CanOpenPage(object ob) => true;

        private void OnOpenPage(object ob)
        {
           
        }

        #endregion

        public MainWindowViewModel()
        {
            OpenNewWindow = new ActionCommand(OnOpenChildWindow, CanOpenChildWindow);
            OpenPage = new ActionCommand(OnOpenPage, CanOpenPage);
        }

    }
}
