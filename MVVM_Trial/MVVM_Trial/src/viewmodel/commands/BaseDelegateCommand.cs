using System;
using System.Windows.Input;

namespace MVVM_Trial.src.viewmodel.commands
{
    /// <summary>
    /// The base Command implementation. All commands need to implement this class.
    /// </summary>
    public class BaseDelegateCommand : ICommand
    {
        /// <summary>
        /// <para>For an Action object:</para>
        /// <para>Ref: https://docs.microsoft.com/en-us/dotnet/api/system.action-1?view=netframework-4.8</para>
        /// <para>You can use the Action<T> delegate to pass a method as a parameter without explicitly
        /// declaring a custom delegate. </para>
        /// </summary>
        private readonly Action<object> _executeAction;

        private readonly Func<object, bool> _canExecuteAction;
        public event EventHandler CanExecuteChanged;

        public BaseDelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        // For `??`
        // Ref: https://stackoverflow.com/a/446839
        // Whatever to the left, if it is not null, execute
        // Else, execute whatever it is on the right
        // Basically, this means that if there is no canExecuteAction then the
        // command can ALWAYS execute.
        public bool CanExecute(object parameter) => _canExecuteAction?.Invoke(parameter) ?? true;

        // => basicalyl means
        // Left:  The member declaration
        // Right: The member implementation
        // member => expression
        public void Execute(object parameter) => _executeAction(parameter);
    }
}
