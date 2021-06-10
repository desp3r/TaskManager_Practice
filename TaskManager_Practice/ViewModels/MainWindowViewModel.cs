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

        public ICommand OpenFirstPage { get; }
        public ICommand OpenSecondPage { get; }
        public ICommand OpenNewWindow { get; }
        
        #endregion


        #region Ctor

        public MainWindowViewModel()
        {
            OpenNewWindow = new ActionCommand(OnOpenChildWindow, CanOpenChildWindow);
            OpenFirstPage = new ActionCommand(OpenFirstPage_Execute, OpenFirstPage_CanExecute);
            OpenSecondPage = new ActionCommand(OpenSecondPage_Execute, OpenSecondPage_CanExecute);
        }

        #endregion
        
        
        #region Commands handlers

        // Тут какое-то условие можешь придумать, если не надо то сноси
        private bool OpenFirstPage_CanExecute(object arg) => true;
        private void OpenFirstPage_Execute(object obj)=>  AppNavigation.Open(PageID.One);
        
        // Тут какое-то условие можешь придумать, если не надо то сноси
        private bool OpenSecondPage_CanExecute(object arg) => true;
        private void OpenSecondPage_Execute(object obj)=>  AppNavigation.Open(PageID.Two);

        
        private bool CanOpenChildWindow(object ob) => true;

        private void OnOpenChildWindow(object ob)
        {
            AddProjectWindow addProjectWindow = new AddProjectWindow();
            addProjectWindow.Show();
        }

        #endregion
        

    }
}
