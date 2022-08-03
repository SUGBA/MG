using MG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MG.Core
{
    public class BoomCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        GamePanel panel;
        public BoomCommand(GamePanel panel)
        {
            this.panel = panel;
        }
    
        public bool CanExecute(object? parameter)
        {
            return panel.CitySelection != null && panel.CountrySelection1 != null && panel.CountrySelection2!= null;
        }

        public void Execute(object? parameter)
        {
            panel.Boom();
        }
    }
}
