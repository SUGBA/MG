using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MG.Model;
using System.Collections.ObjectModel;
using MG.Core;
using System.Windows;

namespace MG.ViewModel
{
    public class GamePanel : INotifyPropertyChanged
    {
        #region Advertisement

        private World _ThisWorld;           //Класс описывающий все данные по текущей сессии
        public World ThisWorld
        {
            get { return _ThisWorld; }
            set
            {
                _ThisWorld = value;
                OnPropertyChanged("ThisWorld");
            }
        }

        private Visibility _GameRightPanelVisible;          //Видимость  игровой панели
        public Visibility GameRightPanelVisible
        {
            get { return _GameRightPanelVisible; }
            set
            {
                _GameRightPanelVisible = value;
                OnPropertyChanged("GameRightPanelVisible");
            }
        }

        private Visibility _GameStoreVisible;                   //Видимость магазина
        public Visibility GameStoreVisible
        {
            get { return _GameStoreVisible; }
            set
            {
                _GameStoreVisible = value;
                OnPropertyChanged("GameStoreVisible");
            }
        }

        private Visibility _GameWarPanelVisible;            //Видимость панели войны
        public Visibility GameWarPanelVisible
        {
            get { return _GameWarPanelVisible; }
            set
            {
                _GameWarPanelVisible = value;
                OnPropertyChanged("GameWarPanelVisible");
            }
        }

        private Country _CountrySelection1;
        public Country CountrySelection1      //Выбранная страна (левая панель)
        {
            get { return _CountrySelection1; }
            set
            {
                _CountrySelection1 = value;
                OnPropertyChanged("CountrySelection1");
            }
        }

        private Country _CountrySelection2;
        public Country CountrySelection2      //Выбранная страна противник (правая панель)
        {
            get { return _CountrySelection2; }
            set
            {
                _CountrySelection2 = value;
                OnPropertyChanged("CountrySelection2");
            }
        }

        private CIty _CitySelection;
        public CIty CitySelection
        {
            get { return _CitySelection; }
            set
            {
                _CitySelection = value;
                OnPropertyChanged("CitySelection");
            }
        }

        private int _PriceDevelopmentNuclearWeapon;         //Цена на развитие ЯО (Меняется от хода)
        public int PriceDevelopmentNuclearWeapon
        {
            get { return _PriceDevelopmentNuclearWeapon; }
            set
            {
                _PriceDevelopmentNuclearWeapon = value;
                OnPropertyChanged("PriceDevelopmentNuclearWeapon");
            }
        }

        #endregion

        #region Command

        public NextStepCommand NextStep { get; set; }
        public ToStoreCommand CreateStore { get; set; }
        public ToBaseCommand CreateBase { get; set; }
        public ToWarCommand CreateWar { get; set; }
        public BoomCommand MakeBoom { get; set; }
        public BuyDevelopmentCommand buyDevelopmentCommand { get; set; }
        public BuyDevelopmentNuclearWeaponCommand buyDevelopmentNuclearWeaponCommand { get; set; }
        public BuyEcologyCommand buyEcologyCommand { get; set; }
        public BuyNuclearWeaponCommand buyNuclearWeaponCommand { get; set; }
        public BuyProtectionCommand buyProtectionCommand { get; set; }

        #endregion

        public GamePanel(List<string> NamesCountries)
        {
            ThisWorld = new World(NamesCountries);
            GameStoreVisible = Visibility.Hidden;
            GameWarPanelVisible = Visibility.Hidden;
            GameRightPanelVisible = Visibility.Visible;
            CreateBase = new ToBaseCommand(this);
            NextStep = new NextStepCommand(this);
            CreateStore = new ToStoreCommand(this);
            CreateWar=new ToWarCommand(this);
            MakeBoom = new BoomCommand(this);
            buyDevelopmentCommand = new BuyDevelopmentCommand(this);
            buyDevelopmentNuclearWeaponCommand = new BuyDevelopmentNuclearWeaponCommand(this);
            buyEcologyCommand = new BuyEcologyCommand(this);
            buyNuclearWeaponCommand = new BuyNuclearWeaponCommand(this);
            buyProtectionCommand = new BuyProtectionCommand(this);
            PriceDevelopmentNuclearWeapon = 200;
        }

        #region Command methods
        public void ToStore()
        {
            GameWarPanelVisible = Visibility.Hidden;            //Прячем панель войны
            GameRightPanelVisible = Visibility.Hidden;          //Прячем игровую панель
            GameStoreVisible = Visibility.Visible;              //Отображаем панель магазина
            CitySelection = null;
        }
        public void ToBase()
        {
            GameWarPanelVisible = Visibility.Hidden;        //Прячем панель войны
            GameStoreVisible = Visibility.Hidden;           //Прячем панель магазина
            GameRightPanelVisible = Visibility.Visible;     //Отображаем игровую панель
            CitySelection = null;
        }
        public void ToWar()
        {
            GameRightPanelVisible = Visibility.Hidden;      //Прячем игровую панель
            GameStoreVisible = Visibility.Hidden;           //Прячем панель магазина
            GameWarPanelVisible = Visibility.Visible;       //Отображаем панель войны
            CitySelection = null;
        }
        public void Boom()
        {
            new War(ThisWorld,CountrySelection1,CountrySelection2,CitySelection);
        }
        public void buyDevelopment()
        {
            Store.BuyDevelopment(CitySelection, CountrySelection1);
        }
        public void buyEcology()
        {
            Store.BuyEcology(ThisWorld, CountrySelection1);
        }
        public void buyDevelopmentNuclearWeapon()  //Вычетаем средства и Добавляем в список на выполнение
        {
            if (Store.BuyDevelopmentNuclearWeapon(ThisWorld, CountrySelection1)) ThisWorld.AddDevelopmentNuclearWeaponList.Add(CountrySelection1);
        }
        public void buyNuclearWeapon()
        {
            if (Store.BuyNuclearWeapon(CountrySelection1, ThisWorld)) ThisWorld.AddNuclearWeaponList.Add(CountrySelection1);
        }
        public void buyProtection()
        {
            if (Store.BuyProtection(CitySelection, CountrySelection1)) ThisWorld.AddProtectionList.Add(CitySelection);
        }

        #endregion
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
