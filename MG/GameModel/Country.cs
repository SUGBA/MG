using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MG.Model;

public class Country:INotifyPropertyChanged
{
    #region Advertisement
    public ObservableCollection<CIty> Cities { get; set; }      //Массив городов конкретной страны

    private float _Budget;
    public float Budget             //бюджет страны
    {
        get { return _Budget; }
        set
        {
            _Budget = value;
            OnPropertyChanged("Budget");
        }
    }

    private bool _DevelopmentNuclearWeapon;
    public bool DevelopmentNuclearWeapon            //Развитость страны (True-Развита,False-Не развита)   
    {
        get { return _DevelopmentNuclearWeapon; }
        set
        {
            _DevelopmentNuclearWeapon = value;
            OnPropertyChanged("DevelopmentNuclearWeapon");
        }
    }

    private int _ValueNuclearWeapon;
    public int ValueNuclearWeapon               //Количество бомб
    {
        get { return _ValueNuclearWeapon; }
        set
        {
            _ValueNuclearWeapon = value;
            OnPropertyChanged("ValueNuclearWeapon");
        }
    }

    private string _NameCountry;
    public string NameCountry               //Имя страны
    {
        get { return _NameCountry; }
        set
        {
            _NameCountry = value;
            OnPropertyChanged("NameCountry");
        }
    }
    #endregion

    #region Flags Of Store

    private bool _CanBuyDevelopmentNuclearWeapon;
    public bool CanBuyDevelopmentNuclearWeapon
    {
        get { return _CanBuyDevelopmentNuclearWeapon; }
        set
        {
            _CanBuyDevelopmentNuclearWeapon = value;
            OnPropertyChanged("CanBuyDevelopmentNuclearWeapon");
        }
    }

    private bool _CanBuyEcology;
    public bool CanBuyEcology
    {
        get { return _CanBuyEcology; }
        set
        {
            _CanBuyEcology = value;
            OnPropertyChanged("CanBuyEcology");
        }
    }

    private bool _CanBuyNuclearWeapon;
    public bool CanBuyNuclearWeapon
    {
        get { return _CanBuyNuclearWeapon; }
        set
        {
            _CanBuyNuclearWeapon = value;
            OnPropertyChanged("CanBuyNuclearWeapon");
        }
    }


    #endregion

    public Country() { }
    public Country(string NameCountry)      //На вход поступает имя страны           
                                            //Заполняем дефолтные значения, заполняем города
    {
        Cities = new ObservableCollection<CIty>();
        Budget = 1000;
        DevelopmentNuclearWeapon = false;
        ValueNuclearWeapon = 0;
        this.NameCountry = NameCountry;
        CanBuyDevelopmentNuclearWeapon = true;
        CanBuyEcology = true;
        CanBuyNuclearWeapon = true;
        switch (NameCountry)
        {
            case "Америка":
                for (int i = 0; i < 4; i++)
                {
                    Cities.Add(new CIty(((NameAmerica)i).ToString()));
                }
                break;

            case "Нигерия":
                for (int i = 0; i < 4; i++)
                {
                    Cities.Add(new CIty(((NameNigers)i).ToString()));
                }
                break;

            case "Китай":
                for (int i = 0; i < 4; i++)
                {
                    Cities.Add(new CIty(((NameChina)i).ToString()));
                }
                break;

            case "Россия":
                for (int i = 0; i < 4; i++)
                {
                    Cities.Add(new CIty(((NameRussia)i).ToString()));
                }
                break;

            case "Германия":
                for (int i = 0; i < 4; i++)
                {
                    Cities.Add(new CIty(((NameGermany)i).ToString()));
                }
                break;

            case "Канада":
                for (int i = 0; i < 4; i++)
                {
                    Cities.Add(new CIty(((NameCanda)i).ToString()));
                }
                break;

            case "КНДР":
                for (int i = 0; i < 4; i++)
                {
                    Cities.Add(new CIty(((NameKNDR)i).ToString()));
                }
                break;

            case "Мексика":
                for (int i = 0; i < 4; i++)
                {
                    Cities.Add(new CIty(((NameMexico)i).ToString()));
                }
                break;

            case "Казахстан":
                for (int i = 0; i < 4; i++)
                {
                    Cities.Add(new CIty(((NameKazah)i).ToString()));
                }
                break;

            default:
                MessageBox.Show("Ошибка ввода имени страны");
                break;
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
