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
        DbConnection cnn = new DbConnection();
        private string hash;
        private string salt;
        private string password;
        int CBselected;
        public ManagementMedewerkersAanpassen(User users)
        {
            InitializeComponent();
            LoadAssets(users);
        }
        public string Id;
        private void LoadAssets(User users)
        {
            Id = users.Id.ToString();
            tbUserId.Text = users.Id.ToString();
            tbNaam.Text = users.Naam.ToString();
            tbE_Mail.Text = users.e_Mail.ToString();
            password = users.Wachtwoord;
            User_Roles roles = cnn.GetRoles(Id.ToString());
            int Iroles = int.Parse(roles.role_Id.ToString());
            tbRoleId.Text = roles.role_Id.ToString();
            switch (Iroles)
            {
                case 1:
                    break;
                case 2:
                    cbRole.SelectedIndex = 0;
                    break;
                case 3:
                    cbRole.SelectedIndex = 1;
                    break;
                case 4:
                    cbRole.SelectedIndex = 2;
                    break;
                case 5:
                    cbRole.SelectedIndex = 3;
                    break;
                case 999:
                    cbRole.SelectedIndex = 4;
                    break;
                default:
                    break;
            }

        }
        private void cbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBselected = int.Parse(cbRole.SelectedIndex.ToString());
            switch (CBselected)
            {
                case 0:
                    tbRoleId.Text = "2";
                    break;
                case 1:
                    tbRoleId.Text = "3";
                    break;
                case 2:
                    tbRoleId.Text = "4";
                    break;
                case 3:
                    tbRoleId.Text = "5";
                    break;
                case 4:
                    tbRoleId.Text = "999";
                    break;
                default:
                    break;
            }
        }

        private void btnAanpassen_Click(object sender, RoutedEventArgs e)
        {
            int iID = int.Parse(tbUserId.Text.ToString());
            if (tbNaam.Text != "" || tbE_Mail.Text != "")
            {
                cnn.EditUser(tbNaam.Text, tbE_Mail.Text, password, iID);
            }
            else
            {
                MessageBox.Show("Zorg dat er een naam en een e-mail is ingevuld");
            }
            if (tbWachtwoordOud.Text != "")
            {
                bool Bwachtwoord = BCrypt.Net.BCrypt.Verify(tbWachtwoordOud.Text, password);
                if (Bwachtwoord == true && tbWachtwoordNieuw.Text != "")
                {
                    salt = BCrypt.Net.BCrypt.GenerateSalt();
                    hash = BCrypt.Net.BCrypt.HashPassword(tbWachtwoordNieuw.Text, salt);
                    int i = int.Parse(tbUserId.Text.ToString());
                    cnn.EditUser(tbNaam.Text, tbE_Mail.Text, hash, i);
                }
            }
            CBselected = int.Parse(cbRole.SelectedIndex.ToString());
             
            int UID = int.Parse(tbUserId.Text);
            int RID = int.Parse(tbRoleId.Text);
            int URID = UID;
            switch (CBselected)
            {
                case 0:                
                    cnn.EditUser_Roles(UID, RID, URID);
                    break;
                case 1:
                    cnn.EditUser_Roles(UID, RID, URID);
                    break;
                case 2:
                    cnn.EditUser_Roles(UID, RID, URID);
                    break;
                case 3:
                    cnn.EditUser_Roles(UID, RID, URID);
                    break;
                case 4:
                    cnn.EditUser_Roles(UID, RID, URID);
                    break;
                default:
                    break;
            }
            this.Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Management win = new Management();
            win.Show();
        }
    }
}
