using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E1WPF
{
    internal class DelegateCommand : ICommand
    {
        private readonly Predicate<object> canExecute;
        private readonly Action<object> execute;
        public event EventHandler? CanExecuteChanged;

        public DelegateCommand(Action<object> execute):this(execute,null)
        {

        }
        public DelegateCommand(Action<object> execute,Predicate<object> canExecute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }
        public bool CanExecute(object? parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            return canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
        public void ReiseCanExecuteChanged()
        {
            if(CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
