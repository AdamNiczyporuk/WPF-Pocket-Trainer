using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Pocket_Trainer.Dashboard.Core
{
    class RelayCommand : ICommand  
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
             
            _execute = execute;
            _canExecute = canExecute;

        }
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = _ => execute();
            _canExecute = canExecute == null ? (Func<object, bool>)null : _ => canExecute();
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
