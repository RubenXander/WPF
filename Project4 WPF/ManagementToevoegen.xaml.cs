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
    /// Interaction logic for ManagementToevoegen.xaml
    /// </summary>
    public partial class ManagementToevoegen : Window
    {
        public ManagementToevoegen()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Management win = new Management();
            win.Show();
        }

        private void btnAanmaken_Click(object sender, RoutedEventArgs e)
        {
            User U = new User();
            U.Naam = tbNaam.Text;
            U.e_Mail = tbE_Mail.Text;
            U.Wachtwoord = tbWachtwoord.Text;
        }
    }
}
