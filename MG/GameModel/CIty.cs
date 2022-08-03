using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MG.Model
{
    public class CIty:INotifyPropertyChanged
    {
        #region Advertisement
        private int _Development;
        public int Development      //Развитость города
        {
            get { return _Development; }
            set
            {
                _Development = value;
                OnPropertyChanged("Development");
            }
        }

        private int _LvlLive;
        public int LvlLive                  //Уровень жизни
        {
            get { return _LvlLive; }
            set
            {
                _LvlLive = value;
                OnPropertyChanged("LvlLive");
            }
        }

        private float _Income;
        public float Income             //Доход
        {
            get { return _Income; }
            set
            {
                _Income = value;
                OnPropertyChanged("Income");   
            }
        }

        private bool _Protection;
        public bool Protection                  //Наличие щита
        {
            get { return _Protection; }
            set
            {
                _Protection = value;
                OnPropertyChanged("Protection");
            }
        }

        private string _NameCity;           //Имя города
        public string NameCity
        {
            get { return _NameCity; }
            set
            {
                _NameCity = value;
                OnPropertyChanged("string");
            }
        }

        #endregion

        #region Flags Of Store

        private bool _CanBuyDevelopment;            //Может ли город развиться(была ли покупка на этом ходу)
        public bool CanBuyDevelopment
        {
            get { return _CanBuyDevelopment; }
            set
            {
                _CanBuyDevelopment = value;
                OnPropertyChanged("CanBuyDevelopment");
            }
        }

        private bool _CanBuyProtection;             //Может ли город установить щит(была ли покупка на этом ходу)
        public bool CanBuyProtection
        {
            get { return _CanBuyProtection; }
            set
            {
                _CanBuyProtection = value;
                OnPropertyChanged("CanBuyProtection");
            }
        }
        #endregion

        public CIty(){ }

        public CIty(string NameCity)
        {
            Development = 60;
            LvlLive = 57;
            Income = 171;
            Protection = false;
            this.NameCity = NameCity;
            CanBuyDevelopment=true;
            CanBuyProtection=true;
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
