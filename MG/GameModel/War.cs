using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MG.Model
{
    public class War
    {
        //О Б Ъ Я В Л Е Н И Е
        private World World;
        private Country CountrySelection1;
        private CIty CitySelection;
        private Country CountrySelection2;

        //М Е Т О Д Ы
        public War(World world, Country CountrySelection1,Country CountrySelection2, CIty CitySelection)
        {
            this.World = world;
            this.CountrySelection1 = CountrySelection1;
            this.CountrySelection2 = CountrySelection2;
            this.CitySelection = CitySelection;

            if (Check()) Destroy();         //Если война возможна, уничтожаем
        }
        private bool Check()        //Метод проверяющий возможна ли война
        {
            if (CountrySelection1.ValueNuclearWeapon == 0)  return false;
            return true;
        }
        private void Destroy()      //Метод ведения войны (True-Успешное уничтожение, False- Война невозможна)
        {
            if (CitySelection.Protection)
            {
                CitySelection.Protection = false;            //Если есть щит, сносим его
            }
            else
            {
                CountrySelection2.Cities.Remove(CitySelection);                 //Если нету, страна прекращает существование
                if (CountrySelection2.Cities.Count == 0) World.Countries.Remove(CountrySelection2);
            }

            CountrySelection1.ValueNuclearWeapon -= 1;
            World.Ecology -= 2;

            foreach (CIty city in CountrySelection1.Cities)        //Уменьшаем уровень жизни в каждой стране
            {
                city.LvlLive -= 2;
            }

        }

    }
}
