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
        DbConnection cnn = new DbConnection();

        private string salt;
        private string hash;
        int CBselected;

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
            DbConnection Connection = new DbConnection();
            salt = BCrypt.Net.BCrypt.GenerateSalt();
            hash = BCrypt.Net.BCrypt.HashPassword(tbWachtwoord.Text, salt);

            if (tbNaam.Text == "" || tbE_Mail.Text == "" || tbWachtwoord.Text == "" || CBselected == -1)
            {
                MessageBox.Show("Aanmaken mislukt");
            }
            else
            {
                User U = new User();
                U.Naam = tbNaam.Text;
                U.e_Mail = tbE_Mail.Text;
                U.Wachtwoord = hash;

                cnn.CreateEmployees(U);
                
                User user = cnn.GetLogin(tbE_Mail.Text);
                User_Roles US = new User_Roles();
                US.user_Id = int.Parse(user.Id.ToString());

                User_Roles UR = new User_Roles();
                UR.role_Id = int.Parse(U.Id.ToString());
                UR.user_Id = US.user_Id;

                CBselected = int.Parse(cbRole.SelectedIndex.ToString());
                switch (CBselected)
                {
                    case 0:
                        UR.role_Id = 2;
                        cnn.CreateRoles(UR);
                        break;
                    case 1:
                        UR.role_Id = 3;
                        cnn.CreateRoles(UR);
                        break;
                    case 2:
                        UR.role_Id = 4;
                        cnn.CreateRoles(UR);
                        break;
                    case 3:
                        UR.role_Id = 5;
                        cnn.CreateRoles(UR);
                        break;
                }

                MessageBox.Show("Gelukt");
                this.Close();
            }
        }
    }
}