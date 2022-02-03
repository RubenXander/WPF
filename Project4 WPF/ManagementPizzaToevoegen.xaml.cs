using Project4_WPF.Classes;
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
using System.Windows.Shapes;

namespace Project4_WPF
{
    /// <summary>
    /// Interaction logic for ManagementPizzaToevoegen.xaml
    /// </summary>
    public partial class ManagementPizzaToevoegen : Window
    {
        DbConnection cnn = new DbConnection();
        public ManagementPizzaToevoegen()
        {
            InitializeComponent();
        }

        private void btnAanmaken_Click(object sender, RoutedEventArgs e)
        {
            if (tbPizza.Text == "" || tbPrijs.Text == "")
            {
                MessageBox.Show("Aanmaken mislukt");
            }
            else
            {
                Pizza P = new Pizza();
                P.Pizzas = tbPizza.Text;
                P.Prijs = "€ " + tbPrijs.Text;

                cnn.CreatePizzas(P);
                this.Close();
            }          
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Management win = new Management();
            win.Show();
        }
    }
}
