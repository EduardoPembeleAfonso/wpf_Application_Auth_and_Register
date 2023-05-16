using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace myFirtsAppDesktop.ViewModels
{
    public class ViewModelCommand : ICommand
    {
        // fields
        readonly Action<object> _executeAction;
        //private readonly Func<object> _canExecuteAction;
        readonly Predicate<object> _canExecuteAction;

        public ViewModelCommand(Action<object> executeAction) : this(executeAction, null) { }

        // contructors
        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            if (executeAction == null) throw new ArgumentNullException();
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteAction == null ? true : _canExecuteAction.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _executeAction?.Invoke(parameter);
        }

        // contructors
        //public ViewModelCommand(Action<object> executeAction)
        //{
        //    _executeAction = executeAction;
        //    _canExecuteAction = null;
        //}

        //public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        //{
        //    _executeAction = executeAction;
        //    _canExecuteAction = canExecuteAction;
        //}

        //// events
        //public event EventHandler CanExecuteChanged
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}

        //public bool CanExecute(object parameter)
        //{
        //    //return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        //    return _canExecuteAction == null || _canExecuteAction(parameter);

        //}

        //public void Execute(object parameter)
        //{
        //    _canExecuteAction(parameter);
        //}
    }
}
