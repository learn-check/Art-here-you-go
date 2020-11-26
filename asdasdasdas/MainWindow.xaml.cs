using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using data;

namespace asdasdasdas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Rekening MijnRekening = new Rekening(1000);

        private readonly Rekening MijnRekening2 = new Rekening(500);

        private Rekening Current;

        public MainWindow()
        {
            InitializeComponent();

            Current = MijnRekening;

            SaldoLabel.Content = MijnRekening.Saldo.ToString("C");
            SaldoLabel2.Content = MijnRekening2.Saldo.ToString("C");

            Btn.Click += (e, s) => DoeIets();
            Btn2.Click += (e, s) => DoeIets2();
            Btn3.Click += (e, s) => DoeIets3();

            rk1.Checked += (s, e) => {
                Current = MijnRekening;
                SaldoLabel.Content = MijnRekening.Saldo.ToString("C");
                SaldoLabel2.Content = MijnRekening2.Saldo.ToString("C");
            };
            rk2.Checked += (s, e) => { 
                Current = MijnRekening2;
                SaldoLabel.Content = MijnRekening.Saldo.ToString("C");
                SaldoLabel2.Content = MijnRekening2.Saldo.ToString("C");
            };
        }

        private void DoeIets() 
        {
            
            if (string.IsNullOrEmpty(getal.Text))
            {
                MessageBox.Show("Vul een getal in");
                return;
            }

            double.TryParse(getal.Text, out double ngetal);

            Current.Bijschrijven(ngetal);

            SaldoLabel.Content = MijnRekening.Saldo.ToString("C");
            SaldoLabel2.Content = MijnRekening2.Saldo.ToString("C");
        }

        private void DoeIets2()
        {

            if (string.IsNullOrEmpty(getal.Text))
            {
                MessageBox.Show("Vul een getal in");
                return;
            }

            double.TryParse(getal.Text, out double ngetal);

            Current.Afschrijven(ngetal);

            SaldoLabel.Content = MijnRekening.Saldo.ToString("C");
            SaldoLabel2.Content = MijnRekening2.Saldo.ToString("C");
        }

        private void DoeIets3() 
        {
            if (string.IsNullOrEmpty(getal.Text))
            {
                MessageBox.Show("Vul een getal in");
                return;
            }

            double.TryParse(getal.Text, out double ngetal);

            Current.OverSchrijven(Current == MijnRekening ? MijnRekening2 : MijnRekening, ngetal);

            SaldoLabel.Content = MijnRekening.Saldo.ToString("C");
            SaldoLabel2.Content = MijnRekening2.Saldo.ToString("C");
        }
    }
}
