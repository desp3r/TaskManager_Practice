using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ICommand SomeCommandTemplate { get; }

        private bool CanSomeCommandTemlateExecute(object ob) => true;

        private void OnSomeCommandTemplate(object ob)
        {
            //Здесь описание работы команды, пример:
            //Application.Current.Shutdown();
        }
    }
}
