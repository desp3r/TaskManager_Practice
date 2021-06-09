using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TaskManager_Practice.Infrastructure.Commands;
using TaskManager_Practice.ViewModels.Base;

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


        #region Data

        public ObservableCollection<>


        #endregion


        public ICommand SomeCommandTemplate { get; }

        private bool CanSomeCommandTemlateExecute(object ob) => true;

        private void OnSomeCommandTemplate(object ob)
        {
            //Здесь описание работы команды, пример:
            //Application.Current.Shutdown();
        }


        public ICommand OpenChildWindow { get; }

        private bool CanOpenChildWindow(object ob) => true;

        private void OnOpenChildWindow(object ob)
        {
            var displayRootRegistry = (Application.Current as App).displayRootRegistry;

            var otherWindowViewModel = new OtherWindowViewModel();
            displayRootRegistry.ShowPresentation(otherWindowViewModel);
        }


        public MainWindowViewModel()
        {
            SomeCommandTemplate = new ActionCommand(OnSomeCommandTemplate, CanSomeCommandTemlateExecute);
            OpenChildWindow = new ActionCommand(OnOpenChildWindow, CanOpenChildWindow);
        }
    }
}
