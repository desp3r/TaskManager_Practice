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

        #region Commands

        public ActionCommand OpenProjectsCommand { get; }
        public ActionCommand OpenWorkersCommand { get; }
        public ActionCommand OpenTasksCommand { get; }
        
        #endregion


        #region Ctor

        public MainWindowViewModel()
        {
            OpenProjectsCommand = new ActionCommand(OpenProjectsCommand_Execute, OpenProjectsCommand_CanExecute);
            OpenTasksCommand = new ActionCommand(OpenTasksCommand_Execute, OpenTasksCommand_CanExecute);
            OpenWorkersCommand = new ActionCommand(OpenWorkersCommand_Execute, OpenWorkersCommand_CanExecute);
        }

        #endregion
        
        
        #region Commands handlers

        private bool OpenProjectsCommand_CanExecute(object arg) => true;
        private void OpenProjectsCommand_Execute(object obj)=>  AppNavigation.Open(PageID.Projects);
        
        private bool OpenTasksCommand_CanExecute(object arg) => true;
        private void OpenTasksCommand_Execute(object obj)=>  AppNavigation.Open(PageID.Tasks);
        
        private bool OpenWorkersCommand_CanExecute(object arg) => true;
        private void OpenWorkersCommand_Execute(object obj)=>  AppNavigation.Open(PageID.Workers);
        

        #endregion
    }
}
