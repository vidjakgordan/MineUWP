using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;

// https://dzone.com/articles/minesweeper-algorithms-explained

namespace MineUWP
{
    class VM : INotifyPropertyChanged
    {
        int brojMina=10;
        int brojRedaka=8;
        int brojStupaca = 8;
        int brojOtvorenih = 0;
        List<Cell> cells;
        private bool _canExecute;
        private ICommand _klik;
        private ICommand _level;

        public VM()
        {
            _canExecute = true;
        }

        public int BrojMina { get { return brojMina; } set { brojMina = value; RaisePropertyChanged("BrojMina"); } }
        public int BrojRedaka { get { return brojRedaka; } set { brojRedaka = value; RaisePropertyChanged("BrojRedaka"); } }
        public int BrojStupaca { get { return brojStupaca; } set { brojStupaca = value; RaisePropertyChanged("BrojStupaca"); } }

        public List<Cell> Cells { get { return cells; } set { cells = value; RaisePropertyChanged("Cells"); } }

        #region icommands
        public ICommand Klik
        {
            get
            {
                return _klik ?? (_klik = new CommandHandler(() => NovaIgra(), _canExecute));
            }
        }

        public ICommand Level
        {
            get
            {
                return _level ?? (_level = new CommandHandler_Level((string l) => NovaIgraLevel(l), _canExecute));
            }
        }
        #endregion

        private void NovaIgraLevel(string l)
        {
            if(l=="1")
            {
                BrojMina = 10;
                BrojRedaka = 8;
                BrojStupaca = 8;
            }
            else if (l == "2")
            {
                BrojMina = 40;
                BrojRedaka = 16;
                BrojStupaca = 16;
            }
            else if (l == "3")
            {
                BrojMina = 99;
                BrojRedaka = 16;
                BrojStupaca = 30;
            }
            NovaIgra();
        }

        #region obrada lijevi i desni klik
        public async void LijeviKlikObrada(Cell c)
        {
            if (c.Mina)
            {
                c.Text = "M";
                c.ShowBomb = Visibility.Visible;
                c.ShowButton = Visibility.Collapsed;
                OtvoriSveMine();

                MessageDialog messbox = new MessageDialog("IZGUBIO SI :(");
                var res = await messbox.ShowAsync();
                NovaIgra();
            }
            else
            {
                int n = BrojMinaOkoCelije(c.I, c.J);
                c.Text = n.ToString();
                brojOtvorenih++;

                if (n == 0)
                {
                    JasneCelijeOkolo(c.I, c.J); //???
                }

                if (BrojRedaka*BrojStupaca - brojOtvorenih == BrojMina)
                {
                    MessageDialog messbox = new MessageDialog("POBJEDIO SI :)");
                    var res = await messbox.ShowAsync();
                    NovaIgra();
                }
            }
        }
        

        public void DesniKlikObrada(Cell c)
        {
            if (c.ShowFlag == Visibility.Collapsed)
            {
                c.ShowFlag = Visibility.Visible;
                c.ShowButton = Visibility.Collapsed;
            }
                
            else if (c.ShowFlag == Visibility.Visible)
            {
                c.ShowFlag = Visibility.Collapsed;
                c.ShowButton = Visibility.Visible;
            }
                     
        }
        #endregion

        #region logikaigre
        public void NovaIgra()
        {
            bool postaviMine = true; // za nastavak fje random
            brojOtvorenih = 0;
            List<Cell> listaCelija = new List<Cell>();
            for (int i = 0; i < BrojRedaka; i++)
                for (int j = 0; j < BrojStupaca; j++)
                {
                    Cell c = new Cell();
                    c.I = i;
                    c.J = j;
                    c.Text = "";
                    c.Mina = false;
                    c.VM = this;
                    listaCelija.Add(c);
                }

            //problem - više mina nego polja
            if(BrojMina>=BrojRedaka*BrojStupaca)
            {
                BrojRedaka++;
                BrojStupaca++;
                postaviMine = false;
                NovaIgra();
            }

            if (postaviMine)
            { 
                for (int i = 0; i < BrojMina; i++)
                {
                    Random r = new Random();
                    int x = r.Next(0, listaCelija.Count);
                    if (listaCelija[x].Mina)
                        i--;
                    listaCelija[x].Mina = true;
                }
                Cells = listaCelija;
            }
        }

        private void OtvoriSveMine()
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                if (Cells[i].Mina)
                    Cells[i].ShowBomb = Visibility.Visible;
                if (Cells[i].ShowFlag == Visibility.Visible)
                    Cells[i].ShowFlag = Visibility.Collapsed;
            }
        }

        private void JasneCelijeOkolo(int i, int j)
        {
            if (i >= 0 && i < BrojRedaka && j >= 0 && j < BrojStupaca)
            {
                JasneCelijeOkolo_P(i - 1, j - 1);
                JasneCelijeOkolo_P(i - 1, j);
                JasneCelijeOkolo_P(i - 1, j + 1);
                JasneCelijeOkolo_P(i, j - 1);
                JasneCelijeOkolo_P(i, j + 1);
                JasneCelijeOkolo_P(i + 1, j - 1);
                JasneCelijeOkolo_P(i + 1, j);
                JasneCelijeOkolo_P(i + 1, j + 1);
            }
        }

        private void JasneCelijeOkolo_P(int i, int j)
        {
            if (i >= 0 && i < BrojRedaka && j >= 0 && j < BrojStupaca && (DohvatCelije(i, j).Text == string.Empty))
            {
                int n = BrojMinaOkoCelije(i, j);

                DohvatCelije(i, j).Text = n.ToString();
                brojOtvorenih++;

                if (DohvatCelije(i, j).ShowFlag == Visibility.Visible)
                    DohvatCelije(i, j).ShowFlag = Visibility.Collapsed;

                if (n == 0)
                    JasneCelijeOkolo(i, j);
            }
        }

        private int BrojMinaOkoCelije(int i, int j)
        {
            int n = 0;

            if(JeLiMina(i - 1, j - 1)) n++;
            if(JeLiMina(i - 1, j)) n++;
            if(JeLiMina(i - 1, j + 1)) n++;
            if(JeLiMina(i, j - 1)) n++;
            if(JeLiMina(i, j + 1)) n++;
            if(JeLiMina(i + 1, j - 1)) n++;
            if(JeLiMina(i + 1, j)) n++;
            if(JeLiMina(i + 1, j + 1)) n++;

            return n;
        }

        private bool JeLiMina(int i, int j)
        {
            if (i >= 0 && i < BrojRedaka && j >= 0 && j < BrojStupaca)
                return DohvatCelije(i, j).Mina;
            return false;
        }

        private Cell DohvatCelije(int i, int j)
        {
            return Cells.Where(p => p.I == i && p.J == j).First();
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

        #region commandhandleri 
        public class CommandHandler : ICommand
        {
            private Action _action;
            private bool _canExecute;
            public CommandHandler(Action action, bool canExecute)
            {
                _action = action;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _action();
            }
        }

        public class CommandHandler_Cell : ICommand
        {
            private Action<Cell> _action;
            private bool _canExecute;
            public CommandHandler_Cell(Action<Cell> action, bool canExecute)
            {
                _action = action;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _action((Cell)parameter);
            }
        }

        public class CommandHandler_Level : ICommand
        {
            private Action<string> _action;
            private bool _canExecute;
            public CommandHandler_Level(Action<string> action, bool canExecute)
            {
                _action = action;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _action((string)parameter);
            }
        }
        #endregion
    }
}
