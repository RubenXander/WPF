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

        #region GetFunctions
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
                cmd.CommandText = "SELECT o.id, o.customer_id, o.status, p.pizza, p.prijs FROM orders o INNER JOIN order_pizza op on o.id = op.order_id INNER JOIN pizza p ON p.id = op.pizza_id";
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

        public ObservableCollection<Pizza> GetOnlyPizzas()
        {
            ObservableCollection<Pizza> ocReturnMenus = new ObservableCollection<Pizza>();

            DataTable dtUsers = new DataTable();
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM pizza";
                MySqlDataReader reader = cmd.ExecuteReader();
                dtUsers.Load(reader);
            }

            foreach (DataRow row in dtUsers.Rows)
            {
                Pizza tmpMenu = new Pizza();
                tmpMenu.Id = Convert.ToInt32(row["id"].ToString());
                tmpMenu.Pizzas = row["pizza"].ToString();
                tmpMenu.Prijs = row["prijs"].ToString();
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
        #endregion

        #region InsertFunctions
        public void CreateEmployees(User user)
        {
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO `users` (`name`, `email`, `password`) VALUES (@name, @email, @password) ";

                cmd.Parameters.AddWithValue("@name", user.Naam);
                cmd.Parameters.AddWithValue("@email", user.e_Mail);
                cmd.Parameters.AddWithValue("@password", user.Wachtwoord);
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateRoles(User_Roles user_Roles)
        {
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO `user_roles` (`user_id`, `role_id`) VALUES (@user_id, @role_id) ";
                cmd.Parameters.AddWithValue("@user_id", user_Roles.user_Id);
                cmd.Parameters.AddWithValue("@role_id", user_Roles.role_Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void CreatePizzas(Pizza pizza)
        {
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO `pizza` (`pizza`, `prijs`) VALUES (@pizza, @prijs) ";

                cmd.Parameters.AddWithValue("@pizza", pizza.Pizzas);
                cmd.Parameters.AddWithValue("@prijs", pizza.Prijs);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region EditFunctions
        public void EditStatus(Orders status, int bestellingid)
        {
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE orders SET status = @Status WHERE orders.id = @bestellingid";
                cmd.Parameters.AddWithValue("@bestellingid", bestellingid);
                cmd.Parameters.AddWithValue("@Status", status.Status);
                cmd.ExecuteNonQuery();
            }
        }

        public void EditPizza(string pizza, string prijs, int id)
        {
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE pizza SET pizza = @pizza, prijs = @prijs WHERE id = @id";
                cmd.Parameters.AddWithValue("@pizza", pizza);
                cmd.Parameters.AddWithValue("@prijs", prijs);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void EditUser(string name, string email, string password ,int id)
        {
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE users SET name = @name, email = @email, password = @password WHERE id = @id";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        public void EditUser_Roles(int user_id, int role_id, int id)
        {
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE user_roles SET user_id = @user_id, role_id = @role_id WHERE id = @id";
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@role_id", role_id);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region DeleteFunctions
        public void DeletePizza(Pizza pizza)
        {
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "DELETE FROM pizza WHERE id = @id;";
                cmd.Parameters.AddWithValue("@id", pizza.Id);
                int nrOfRowsAffected = cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUsers(User users)
        {
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "DELETE FROM users WHERE id = @id;";
                cmd.Parameters.AddWithValue("@id", users.Id);
                int nrOfRowsAffected = cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUser_Roles(User_Roles user_Roles)
        {
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "DELETE FROM user_roles WHERE user_id = @user_id;";
                cmd.Parameters.AddWithValue("@user_id", user_Roles.user_Id);
                int nrOfRowsAffected = cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
