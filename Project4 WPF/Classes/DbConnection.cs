using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_WPF.Classes
{
    class DbConnection
    {
        string connString = ConfigurationManager.ConnectionStrings["connProject4"].ConnectionString;

        public ObservableCollection<User> GetAllUsers()
        {
            ObservableCollection<User> ocReturnMenus = new ObservableCollection<User>();

            DataTable dtUsers = new DataTable();
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from users";
                MySqlDataReader reader = cmd.ExecuteReader();
                dtUsers.Load(reader);
            }

            foreach (DataRow row in dtUsers.Rows)
            {
                User tmpMenu = new User();
                tmpMenu.Id = Convert.ToInt32(row["Id"].ToString());
                tmpMenu.Naam = row["Name"].ToString();
                tmpMenu.e_Mail = row["Email"].ToString();
                tmpMenu.Wachtwoord = row["Password"].ToString();
                ocReturnMenus.Add(tmpMenu);
            }

            return ocReturnMenus;
        }
        public User GetLogin(string gebruikersnaam)
        {
            User login = new User();
            DataTable DTinloggen = new DataTable();
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM users WHERE name = @gebruikersnaam";
                cmd.Parameters.AddWithValue("@gebruikersnaam", gebruikersnaam);
                MySqlDataReader read = cmd.ExecuteReader();
                DTinloggen.Load(read);

                foreach (DataRow row in DTinloggen.Rows)
                {
                    login.Id = Convert.ToInt32(row["id"].ToString());
                    login.Wachtwoord = row["password"].ToString();
                }
                return login;
            };
        }
    }
}
