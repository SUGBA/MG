using MG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MG.Core
{
    public class BuyDevelopmentNuclearWeaponCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        GamePanel panel;
        public BuyDevelopmentNuclearWeaponCommand(GamePanel panel)
        {
            this.panel = panel;
        }

        public bool CanExecute(object parameter)
        {
            return panel.CountrySelection1!=null;
        }

        public void Execute(object parameter)
        {
            panel.buyDevelopmentNuclearWeapon();
        }
    }
}
