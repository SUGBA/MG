using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MG.Model
{
    public class World:INotifyPropertyChanged
    {
        #region Advertisement

        private int strokeNumber;   //Текущий ход
        public int StrokeNumber
        {
            get { return strokeNumber; }
            set
            {
                strokeNumber = value;
                if (strokeNumber != 1) ChangeAfterStep();
            }
        }

        private int _Ecology;
        public int Ecology          //Уровень экологии
        {
            get { return _Ecology; }
            set
            {
                _Ecology = value;
                OnPropertyChanged("Ecology");
            }
        }

        public int ValueCountry { get; set; }           //Колличество стран

        public ObservableCollection<Country> Countries { get; set; }            //Список стран

        #endregion

        #region Next step parameters

        public List<CIty> AddProtectionList { get; set; }       //Список стран у которых куплено улучшение города на следующий ход
        public List<Country> AddNuclearWeaponList { get; set; }     //Список стран у которых куплено ЯО на следующий ход
        public List<Country> AddDevelopmentNuclearWeaponList { get; set; }     //Список стран у которых куплено развитие ЯО на следующий ход

        #endregion

        public World() { }              //Конструктор без параметров

        public World(List<string> NamesCountries)       //На вход поступает списко имен стран
                                                        //Заполняем дефолтные значения, заполняем страны
        {
            ValueCountry = NamesCountries.Count;            //Колличество стран
            Countries =new ObservableCollection<Country>();
            for (int i = 0; i < ValueCountry; i++)              //Инициализируем каждую страну
            {
                Countries.Add(new Country(NamesCountries[i]));
            }
            StrokeNumber = 1;
            AddProtectionList = new List<CIty>();
            AddNuclearWeaponList = new List<Country>();
            AddDevelopmentNuclearWeaponList=new List<Country>();
        }

        public void ChangeAfterStep()              //Изменение доходов после каждого хода
        {
            foreach (Country country in Countries)
            {
                country.CanBuyDevelopmentNuclearWeapon = true;          //Возвращаем возможность покупки
                country.CanBuyEcology = true;
                country.CanBuyNuclearWeapon = true;
                strokeNumber += 1;
                foreach (CIty city in country.Cities)
                {
                    city.Income += (float)((city.LvlLive - 57) * 2.85);         //Фиксируем прибыль
                    country.Budget += city.Income;  
                    city.CanBuyProtection = true;       //Возвращаем возможность покупки
                    city.CanBuyDevelopment = true;
                }
            }
            #region calling methods from the last move
            if (AddProtectionList.Count != 0)           //Если есть элементы в списке на добавление
            {
                foreach (CIty item in AddProtectionList)            //Добавляем
                {
                    Store.AddProtection(item);
                }
                AddProtectionList.Clear();              //Чистим список
            }
            if (AddNuclearWeaponList.Count!=0)
            {
                foreach (Country item in AddNuclearWeaponList)
                {
                    Store.AddNuclearWeapon(item);
                }
                AddNuclearWeaponList.Clear();
            }
            if (AddDevelopmentNuclearWeaponList.Count!=0)
            {
                foreach (Country item in AddDevelopmentNuclearWeaponList)
                {
                    Store.AddDevelopmentNuclearWeapon(this, item);
                }
                AddDevelopmentNuclearWeaponList.Clear();
            }
            #endregion
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
