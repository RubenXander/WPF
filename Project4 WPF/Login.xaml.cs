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
            //haalt gegevens van gebruikers op

            User login = cnn.GetLogin(tbGebruikersnaam.Text);
            string sLogin = login.Id.ToString();
            int iLogin = int.Parse(sLogin);
            if (iLogin > 0)
            {
                //checkt op het wachtwoord klopt

                string sWachtwoord = login.Wachtwoord.ToString();
                MessageBox.Show("ID " + iLogin + " Wachtwoord " + sWachtwoord);
                bool bWachtwoord = BCrypt.Net.BCrypt.Verify(tbWachtwoord.Text, sWachtwoord);
                
                //kijkt welke rol er bij de gebruikers hoort

                if (bWachtwoord == true)
                {
                    User_Roles Roles = cnn.GetRoles(login.Id.ToString());
                    MessageBox.Show("ingelogd");

                    switch (Roles.role_Id)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            Bereiding win3 = new Bereiding();
                            win3.Show();
                            this.Close();
                            break;
                        case 4:
                            break;
                        case 5:
                            Management win5 = new Management();
                            win5.Show();
                            this.Close();
                            break;
                        default:
                            break;
                    }
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

            
        }
    }
}
