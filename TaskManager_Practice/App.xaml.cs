using TaskManager_Practice.Services.Common;
using TaskManager_Practice.Services.Navigation;

namespace TaskManager_Practice
{
    public partial class App
    {
        /// <summary>
        /// Первоначальная настройка приложения
        /// </summary>
        /// <param name="window">Основное окно нашего приложения</param>
        public static void Initialize(MainWindow window)
        {
            Paths.CreateFoldersIfNotExist();
            AppNavigation.Initialize(window.MainFrame.NavigationService);
        }
    }
    
    
}
