using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using static MineUWP.VM;

namespace MineUWP
{
    class Cell : INotifyPropertyChanged
    {
        #region attributes
        int i; //stupac
        int j; //redak
        string text;
        bool mina = false;
        Visibility showBomb = Visibility.Collapsed;
        Visibility showFlag = Visibility.Collapsed;
        Visibility showButton = Visibility.Visible;
        VM vm=null;
        private ICommand _lijeviKlik;
        #endregion

        #region properties
        public string Text
        {
            get { return text; }
            set { text = value;
                RaisePropertyChanged("Text"); }
        }

        public int I
        {
            get { return i; }
            set { i = value; }
        }

        public int J
        {
            get { return j; }
            set { j = value; }
        }

        public bool Mina
        {
            get { return mina; }
            set { mina = value; }
        }

        public Visibility ShowBomb
        {
            get { return showBomb; }
            set { showBomb = value;
                RaisePropertyChanged("ShowBomb"); }
        }

        public Visibility ShowFlag
        {
            get { return showFlag; }
            set { showFlag = value;
                RaisePropertyChanged("ShowFlag"); }
        }

        public Visibility ShowButton
        {
            get { return showButton; }
            set { showButton = value;
                RaisePropertyChanged("ShowButton"); }
        }

        internal VM VM
        {
            get { return vm; }
            set { vm = value;
                RaisePropertyChanged("VM"); }
        }
        #endregion

        #region icommand lijeviklik
        public ICommand LijeviKlik
        {
            get { return _lijeviKlik ?? (_lijeviKlik = new CommandHandler_Cell((Cell c) => vm.LijeviKlikObrada(c), true));} // PROBLEMIIII!!!
        }
        #endregion

        #region propertychanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
