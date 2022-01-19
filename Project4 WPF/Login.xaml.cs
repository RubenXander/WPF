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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        DbConnection cnn = new DbConnection();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User login = cnn.GetLogin(tbGebruikersnaam.Text);
            string sLogin = login.Id.ToString();
            int iLogin = int.Parse(sLogin);
            if (iLogin > 0)
            {
                string sWachtwoord = login.Wachtwoord.ToString();
                MessageBox.Show("ID " + iLogin + " Wachtwoord " + sWachtwoord);
                bool bWachtwoord = BCrypt.Net.BCrypt.Verify(tbGebruikersnaam.Text, tbWachtwoord.Text);
                if (bWachtwoord == true)
                {
                    MessageBox.Show("ingelogd");
                }
                else if (bWachtwoord == false)
                {
                    MessageBox.Show("Wachtwoord incorrect");
                }
            }
            else
            {
                MessageBox.Show("Gebruikersnaam incorrect");
            }

            //MainWindow win = new MainWindow();
            //win.Show();
            //this.Close();
        }
    }
}
