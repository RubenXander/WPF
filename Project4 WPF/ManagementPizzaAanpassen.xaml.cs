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
    /// Interaction logic for ManagementPizzaAanpassen.xaml
    /// </summary>
    public partial class ManagementPizzaAanpassen : Window
    {
        DbConnection cnn = new DbConnection();
        
        //haalt de gestuurde gegevens op
        public ManagementPizzaAanpassen(Pizza pizzas)
        {
            InitializeComponent();
            LoadAssets(pizzas);
        }

        private void LoadAssets(Pizza pizzas)
        {
            //laat de gegevens in de textvelden
            
            tbId.Text = pizzas.Id.ToString();
            tbPizza.Text = pizzas.Pizzas.ToString();
            tbPrijs.Text = pizzas.Prijs.ToString();

            
        }

        private void btnAanpassen_Click(object sender, RoutedEventArgs e)
        {
            //check de ingevulde gegevens en past ze toe in de tabel

            int i = int.Parse(tbId.Text.ToString());
            cnn.EditPizza(tbPizza.Text, tbPrijs.Text, i);
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
                Management win = new Management();
                win.Show();           
        }
    }
}
