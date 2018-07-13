using System;
using System.Windows.Input;

namespace BCSDirectory
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _condition;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public DelegateCommand(Action action, Func<bool> condition)
        {
            _action = action;
            _condition = condition;
        }

        public bool CanExecute(object parameter)
        {
            if (_condition == null)
            {
                return true;
            }

            return (bool)_condition?.Invoke();
        }

        public void Execute(object parameter)
        {
            _action?.Invoke();
        }

        public event EventHandler CanExecuteChanged = (sender, args) => { };
    }
}
