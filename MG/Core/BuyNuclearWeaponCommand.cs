using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MG.ViewModel;

namespace MG.Core
{
    public class BuyNuclearWeaponCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        GamePanel panel;
        public BuyNuclearWeaponCommand(GamePanel panel)
        {
            this.panel = panel;
        }

        public bool CanExecute(object parameter)
        {
            return panel.CountrySelection1 != null;
        }

        public void Execute(object parameter)
        {
            panel.buyNuclearWeapon();
        }
    }
}

