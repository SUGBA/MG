using MG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MG.Core
{
    public class LoginPanelCommand : ICommand
    {
        public LoginPanelCommand(Panel panel) => this.panel = panel;
        Panel panel;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return panel.LoginVM.NamesCountries.Count != 0;
        }

        public void Execute(object parameter)
        {
            panel.NextCommand();
        }
    }
}
