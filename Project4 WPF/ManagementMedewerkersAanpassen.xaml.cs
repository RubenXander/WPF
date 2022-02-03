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
    /// Interaction logic for ManagementMedewerkersAanpassen.xaml
    /// </summary>
    public partial class ManagementMedewerkersAanpassen : Window
    {
        public ManagementMedewerkersAanpassen(User users)
        {
            InitializeComponent();
            LoadAssets(users);
        }

        private void LoadAssets(User users)
        {

            tbUserId.Text = users.Id.ToString();
            tbNaam.Text = users.Naam.ToString();
            tbE_Mail.Text = users.e_Mail.ToString();
            tbWachtwoord.Text = users.Wachtwoord.ToString();


        }

        private void btnAanpassen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
