using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Model
{
    enum Countries
    {
        Америка,
        Нигерия,
        Китай,
        Россия,
        Германия,
        Канада,
        КНДР,
        Мексика,
        Казахстан,
    }

    enum NameAmerica : byte       //Города Америки
    {
        Чикаго = 0,
        Филадельфия,
        Даллас,
        Денвер
    }
    enum NameNigers : byte        //Города Нигерии
    {
        Лагос = 0,
        Ибадан,
        Абуджа,
        Акуре
    }
    enum NameChina : byte     //Города китая
    {
        Пекин = 0,
        Тяньцзинь,
        Чунцин,
        Шанхай
    }
    enum NameRussia : byte          //Города России
    {
        Москва = 0,
        Ленинград,
        Пермь,
        Владивосток
    }
    enum NameGermany : byte     //Города германии
    {
        Берлин = 0,
        Гамбург,
        Мюнхен,
        Кёльн
    }
    enum NameCanda : byte       //Города Канады
    {
        Торонто = 0,
        Монреаль,
        Калгари,
        Оттава
    }
    enum NameKNDR : byte      //Города КНДР
    {
        Анджу = 0,
        Вонсан,
        Канге,
        Кимчхэк
    }
    enum NameMexico : byte      //Города Мексики
    {
        Мехико = 0,
        Тихуана,
        Гвадалахара,
        Леон
    }
    enum NameKazah : byte       //Города Казахстана
    {
        Абай = 0,
        Акколь,
        Аксу,
        Аральск
    }

}
