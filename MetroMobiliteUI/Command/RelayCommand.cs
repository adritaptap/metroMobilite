using MetroMobiliteUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MetroMobiliteUI.Command
{
    public class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action mMethodToExecute;

        public MyCommand(Action methodToExecute)
        {
            mMethodToExecute = methodToExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (mMethodToExecute != null)
            {
                mMethodToExecute();
            }
        }
    }
}
