using TaskManager_Practice.Services;
using TaskManager_Practice.Services.Common;
using TaskManager_Practice.Services.Navigation;

namespace TaskManager_Practice
{
    public partial class App
    {
        public static void Initialize(MainWindow window)
        {
            Paths.CreateFoldersIfNotExist();
            Logger.Initialize();
            AppNavigation.Initialize(window.MainFrame.NavigationService);
        }
    }
    
    
}
