using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using TaskManager_Practice.Infrastructure;
using TaskManager_Practice.Infrastructure.Commands;
using TaskManager_Practice.Services.Navigation;
using TaskManager_Practice.ViewModels.Base;
using TaskManager_Practice.Views.Windows;

namespace TaskManager_Practice.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Private Fields

        private string _Title;
        

        #endregion

        #region Properties

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion




        #region Private Methods

        

        #endregion

        
        
        #region Commands

        public ICommand OpenProjectsCommand { get; }
        public ICommand OpenWorkersCommand { get; }
        public ICommand OpenNewWindow { get; }
        
        #endregion


        #region Ctor

        public MainWindowViewModel()
        {
            OpenNewWindow = new ActionCommand(OnOpenChildWindow, CanOpenChildWindow);
            OpenProjectsCommand = new ActionCommand(OpenProjectsCommand_Execute, OpenProjectsCommand_CanExecute);
            OpenWorkersCommand = new ActionCommand(OpenWorkersCommand_Execute, OpenWorkersCommand_CanExecute);
        }

        #endregion
        
        
        #region Commands handlers

        // Тут какое-то условие можешь придумать, если не надо то сноси
        private bool OpenProjectsCommand_CanExecute(object arg) => true;
        private void OpenProjectsCommand_Execute(object obj)=>  AppNavigation.Open(PageID.Projects);
        
        // Тут какое-то условие можешь придумать, если не надо то сноси
        private bool OpenWorkersCommand_CanExecute(object arg) => true;
        private void OpenWorkersCommand_Execute(object obj)=>  AppNavigation.Open(PageID.Workers);

        
        private bool CanOpenChildWindow(object ob) => true;

        private void OnOpenChildWindow(object ob)
        {
            // AddProjectWindow addProjectWindow = new AddProjectWindow(null);
            // addProjectWindow.Show();
        }

        #endregion
        

    }
}
