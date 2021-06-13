using System;
using System.Windows.Input;

namespace Application.Utils.Command
{
    public class RelayCommand<TParameter> : ICommand
    {
        private readonly Predicate<TParameter> _canExecute;
        private readonly Action<TParameter> _execute;

        public RelayCommand(Action<TParameter> execute, Predicate<TParameter> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((TParameter) parameter);
        }

        public void Execute(object parameter)
        {
            _execute((TParameter) parameter);
        }
    }

    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null) : base(execute, canExecute)
        {
        }
    }
}