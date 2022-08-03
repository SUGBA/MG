using MG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MG.Core
{
    public class ToBaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        GamePanel panel;
        public ToBaseCommand(GamePanel panel)
        {
            this.panel = panel; 
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            panel.ToBase();
        }
    }
}
