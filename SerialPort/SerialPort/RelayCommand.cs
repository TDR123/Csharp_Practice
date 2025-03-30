using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SerialPort
{
    public class RelayCommand : ICommand

    {
        private Action<object>? _execute;
        private Func<object, bool>? _canExecute;
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (_execute != null)
            {
                _execute(parameter);
            }

        }
    }
}
