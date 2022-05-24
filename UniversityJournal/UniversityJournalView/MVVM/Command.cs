using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace UniversityJournalView.MVVM
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Func<object, bool> canExecute;
        private readonly Action<object> execute;

        public Command(Func<object, bool> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public void InvokeCanExecuteChange()
        {
            CanExecuteChanged.Invoke(this, new EventArgs());
        }
    }
}
