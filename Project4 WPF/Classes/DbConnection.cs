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
                cmd.CommandText = "SELECT users.*, user_roles.role_id from users JOIN user_roles on users.id = user_roles.user_id WHERE user_roles.role_id BETWEEN 2 AND 999";
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

        public ObservableCollection<Orders> GetAllOrders()
        {
            ObservableCollection<Orders> ocReturnMenus = new ObservableCollection<Orders>();

            DataTable dtUsers = new DataTable();
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM orders, pizza";
                MySqlDataReader reader = cmd.ExecuteReader();
                dtUsers.Load(reader);
            }

            foreach (DataRow row in dtUsers.Rows)
            {
                Orders tmpMenu = new Orders();
                tmpMenu.Id = Convert.ToInt32(row["id"].ToString());
                tmpMenu.Customer_id = Convert.ToInt32(row["customer_id"].ToString());
                tmpMenu.Status = row["status"].ToString();
                tmpMenu.Pizza = row["pizza"].ToString();
                ocReturnMenus.Add(tmpMenu);
            }

            return ocReturnMenus;
        }

        public ObservableCollection<Orders> GetAllPizza(int bestellingid)
        {
            ObservableCollection<Orders> ocReturnMenus = new ObservableCollection<Orders>();

            DataTable dtUsers = new DataTable();
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = @"SELECT o.id, o.customer_id, o.status, p.pizza, p.prijs FROM orders o INNER JOIN order_pizza op on o.id = op.order_id INNER JOIN pizza p ON p.id = op.pizza_id WHERE o.id = @bestellingid";
                cmd.Parameters.AddWithValue("@bestellingid", bestellingid);
                MySqlDataReader reader = cmd.ExecuteReader();
                dtUsers.Load(reader);
            }

            foreach (DataRow row in dtUsers.Rows)
            {
                Orders tmpMenu = new Orders();
                tmpMenu.Id = Convert.ToInt32(row["id"].ToString());
                tmpMenu.Customer_id = Convert.ToInt32(row["customer_id"].ToString());
                tmpMenu.Status = row["status"].ToString();
                tmpMenu.Pizza = row["pizza"].ToString();
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

        public User_Roles GetRoles(string UserId)
        {
            User_Roles login = new User_Roles();
            DataTable DTinloggen = new DataTable();
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM user_roles WHERE user_id = @userid";
                cmd.Parameters.AddWithValue("@userid", UserId);
                MySqlDataReader read = cmd.ExecuteReader();
                DTinloggen.Load(read);

                foreach (DataRow row in DTinloggen.Rows)
                {
                    login.role_Id = Convert.ToInt32(row["role_id"].ToString());
                }
                return login;
            };
        }
    }
}
