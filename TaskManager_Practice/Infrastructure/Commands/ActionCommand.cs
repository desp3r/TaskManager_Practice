using System;
using TaskManager_Practice.Infrastructure.Base;

namespace TaskManager_Practice.Infrastructure.Commands
{
    class ActionCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;
        
        public ActionCommand(Action<object> Execute, Func<object, bool> CanExecute)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter) =>_CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => _Execute(parameter);
    }
}
