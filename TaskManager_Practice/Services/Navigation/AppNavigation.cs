using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using TaskManager_Practice.Infrastructure;
using TaskManager_Practice.Views.Pages;
using TaskManager_Practice.Views.Windows;

namespace TaskManager_Practice.Services.Navigation
{
    public static class AppNavigation
    {
        #region Private Fields

        private static NavigationService _Navigation;
        private static Page _CurrentPage;

        #endregion
        
        #region Public Methods

        public static Result Open(PageID page)
        {
            try
            {
                var newPage = GeneratePage(page);
                if (_CurrentPage == newPage)
                    return Result.Aborted;
                _Navigation.Navigate(newPage);
                _CurrentPage = newPage;
                return Result.Ok;
            }
            catch(Exception exception)
            {
                return Result.Exception;
            }
        }

        public static Result Initialize(NavigationService service)
        {
            _Navigation = service;
            return Result.Ok;
        }
        
        #endregion


        #region Private Fields

        private static Page GeneratePage(PageID page) => page switch
        {
            PageID.Projects => new ProjectsPage(),
            PageID.Workers => new WorkersPage(),
            _ => throw new NotImplementedException()
        };

        #endregion
    }
}