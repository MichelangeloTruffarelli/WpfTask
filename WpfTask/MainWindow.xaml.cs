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

namespace WpfTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public async Task TrovaMultipli(int a)
        {
            await Task.Run(() =>
            {
                int divisori = 200000000;
                int multipli = 0;
                for (int i = 0; i < divisori; i++)
                {
                    if ((i % a) == 0)
                    {
                        multipli++;
                    }
                    if (i % 200000000 == 0)
                    {
                        pb1.Dispatcher.Invoke(() =>
                        pb1.Value++);
                    };
                }

                lbl_Risultato.Dispatcher.Invoke(() =>
                    lbl_Risultato.Content = multipli
                );
            });
        }
        private void btn_esegui_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(txt_inserisci.Text);
            pb1.Minimum = 0;
            pb1.Maximum = 100;
            pb1.Value = 0;
            lbl_Risultato.Content = $" Risultato: {TrovaMultipli(a)}";
        }

        private void btn_primo_Click(object sender, RoutedEventArgs e)
        {
            bool primo = true;
            int a = int.Parse(txt_inserisci.Text);
            for (int i = 2; i <= a / 2; i++)
            {
                if (a % i == 0)
                {
                    primo = false;
                }
            }
            if (primo == false)
            {
                lbl_Ris_Primo.Content = "Il numero non è primo";
            }
            else
            {
                lbl_Ris_Primo.Content = "Il numero è primo";
            }
        }
    }
}
