using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MG.Core;

namespace MG.ViewModel
{
    public class Panel : INotifyPropertyChanged   //Основной DataContext В котором будут хранится ViewModel'и авторизации и игрового процесса
    {
        #region Advertisement
        private GamePanel _GameVM;          //ViewModel для авторизационной части
        public GamePanel GameVM
        {
            get { return _GameVM; }
            set
            {
                _GameVM = value;
                OnPropertyChanged("GameVM");
            }
        }

        private DisplayCountriesVM _LoginVM;        //ViewModel для игровой части
        public DisplayCountriesVM LoginVM
        {
            get { return _LoginVM; }
            set
            {
                _LoginVM = value;
                OnPropertyChanged("LoginVM");
            }
        }

        private Visibility _LoginVisible;                        //Привязка к видимости грида
        public Visibility LoginVisible
        {
            get { return _LoginVisible; }
            set
            {
                _LoginVisible = value;
                OnPropertyChanged("LoginVisible");
            }
        }

        private Visibility _GameVisible;                        //Привязка к видимости грида
        public Visibility GameVisible
        {
            get { return _GameVisible; }
            set
            {
                _GameVisible = value;
                OnPropertyChanged("GameVisible");
            }
        }

        #endregion

        public LoginPanelCommand CommandButton { get; set; }            //Команда кнопки "Далее"

        public void NextCommand()
        {
            GameVM = new GamePanel(LoginVM.NamesCountries);
            LoginVisible = System.Windows.Visibility.Hidden;
            GameVisible = System.Windows.Visibility.Visible;
        }

        public Panel()
        {
            _LoginVM = new DisplayCountriesVM();
            GameVisible = System.Windows.Visibility.Hidden;
            CommandButton = new LoginPanelCommand(this);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion

    }
}
