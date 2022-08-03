using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Model
{
    static class Store
    {
        // М Е Т О Д Ы
        static public bool BuyEcology(World world, Country country)
        {
            switch (world.StrokeNumber)         //Свитч по номеру хода
            {
                case 1:                         //Если первый ход
                    if (country.Budget >= 200)      //Если хватает бюджета
                    {
                        world.Ecology += 5;
                        country.Budget -= 200;
                        country.CanBuyEcology = false;
                        return true;                //Если покупка совершена, возвращаем true
                    }
                    break;

                default:            //Если не первый ход
                    if (country.Budget >= 500)      //Если хватает бюджета
                    {
                        world.Ecology += 5;
                        country.Budget -= 500;
                        country.CanBuyEcology = false;
                        return true;                //Если покупка совершена, возвращаем true
                    }
                    break;
            }
            return false;
        }
        static public bool BuyDevelopmentNuclearWeapon(World world, Country country)
        {
            if (country.Budget >= 500 && country.DevelopmentNuclearWeapon == false)        //Если хватает бюджета и еще не развито
            {
                country.Budget -= 500;
                country.CanBuyDevelopmentNuclearWeapon= false;              //На данном ходу невозможно больше совершить покупку
                return true;                        //Если покупка совершена, возвращаем true
            }
            return false;
        }
        static public bool BuyDevelopment(CIty city, Country country)
        {
            if (country.Budget >= 150)      //Если хватает бюджета
            {
                country.Budget -= 150;
                city.LvlLive += 2;          //Увеличиваем уровень жизни
                city.Development += 29;
                city.CanBuyDevelopment = false;         //На данном ходу невозможно больше совершить покупку
                return true;                    //Если покупка совершена, возвращаем true
            }
            return false;
        }
        static public bool BuyNuclearWeapon(Country country, World world)
        {
            if (country.Budget >= 150 && country.DevelopmentNuclearWeapon)      //Если хватает бюджета и ЯО развито
            {
                country.Budget -= 150;
                if ((world.AddNuclearWeaponList.FindAll(p=>p.NameCountry==country.NameCountry)).Count==2) country.CanBuyNuclearWeapon= false;   //Если колличество данная страна внесена в список на увелечения бомб 3 раза, то кнопка более не доступна
                return true;                    //Если покупка совершена, возвращаем true
            }
            return false;
        }
        static public bool BuyProtection(CIty city, Country country)
        {
            if (country.Budget >= 300 && city.Protection == false)      //Если хватает бюджета и щита еще нету
            {
                country.Budget -= 300;
                city.CanBuyProtection = false;          //На данном ходу невозможно больше совершить покупку
                return true;                //Если покупка совершена, возвращаем true
            }
            return false;
        }

        static public void AddProtection(CIty city) => city.Protection = true;
        static public void AddNuclearWeapon(Country country) => country.ValueNuclearWeapon += 1;
        static public void AddDevelopmentNuclearWeapon(World world, Country country)
        {
            country.DevelopmentNuclearWeapon = true;        //ЯО-Развито
            world.Ecology -= 3;             //Уменьшен уровень экологии
        }
    }
}
