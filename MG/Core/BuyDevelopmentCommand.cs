using MG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MG.Core
{
    public class BuyDevelopmentCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        GamePanel panel;
        public BuyDevelopmentCommand(GamePanel panel)
        {
            this.panel = panel;     
        }

        public bool CanExecute(object parameter)
        {
            return panel.CitySelection != null && panel.CountrySelection1 != null;
        }

        public void Execute(object parameter)
        {
            panel.buyDevelopment();
        }
    }
}
