using System;
using System.Runtime.Remoting.Proxies;
using System.Windows.Input;


namespace DashBoard_Advance
{
    /// <summary>
    /// RealyCommand allows you to inject the command's logic via delegates passed into its Constructor. This Method enables ViewModel Classes to implement commands in a concise Manner.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
            canExecute = null;
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// canExecuteChanged delegates the event subscription to the CommandManager.RequerySuggested event.
        /// This ensures that the Wpf Commanding infrastructure asks all RelayCommand Objects if they can executewhenever it asks the built-in commands.
        /// </summary>

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }



    }
}
