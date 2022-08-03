using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using MG.Model;
using System.Windows;
using MG.Core;
using System.Windows;

namespace MG.ViewModel
{
    public class DisplayCountriesVM : INotifyPropertyChanged     //Класс предназначенный для отображения выбранных стран
    {
        #region Advertisement
        private string _CountrySelection;
        public string CountrySelection      //Выбранная страна
        {
            get { return _CountrySelection; }
            set
            {
                _CountrySelection = value;
                OnPropertyChanged("CountrySelection");

                if (Check(value)) DeleteFlag(value);      //Если было найдено вхождение, то удаляем из спиков ссылку и имя страны
                else AddFlag(value);                 //Если вхождения не было найдено добавляем ссылку и имя страны
            }
        }

        public ObservableCollection<BitmapImage> LinkCountrySelection { get; set; }     //Ссылки на картинки флагов
        
        public List<string> NamesCountries;        //Имя страны

        public string[] LeftPanelNames { get; set; }                //Список названий всех стран

        #endregion

        public DisplayCountriesVM()
        {
            NamesCountries = new List<string>();
            LinkCountrySelection = new ObservableCollection<BitmapImage>(new BitmapImage[Enum.GetNames(typeof(Countries)).Length]);
            LeftPanelNames = Enum.GetNames(typeof(Countries));
        }

        private bool Check(string CountryName)
        {
            if (NamesCountries.Find(a => a == CountryName) != null) return true;        //Если находим этот элемент возвращаем true
            else return false;          //Если не находим возвращаем false
        }

        public void AddFlag(string CountryName)
        {
            bool flag = true;

            NamesCountries.Add(CountryName.ToString());         //Добавляем в список стран
            for (int i = 0; i < LinkCountrySelection.Count && flag; i++)        //Заполняем первую пустую ячейку
            {
                if (LinkCountrySelection[i] == null)
                {
                    LinkCountrySelection[i] =new BitmapImage(new Uri ($"ImageFlags/{CountryName}.png",UriKind.Relative));
                    flag = false;
                }
            }
        }

        public void DeleteFlag(string CountryName)
        {
            bool flag = true;

            NamesCountries.Remove(CountryName.ToString());              //Удаляем из списка имен
            for (int i = 0; i < LinkCountrySelection.Count && flag; i++)        //Зануляем завново найденный элемент в листе картинок
            {
                if (LinkCountrySelection[i] != null && LinkCountrySelection[i].UriSource.ToString() == $"ImageFlags/{CountryName}.png")
                {
                    LinkCountrySelection[i] = null;
                    flag = false;
                }
            }
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
