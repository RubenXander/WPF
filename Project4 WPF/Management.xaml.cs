using Project4_WPF.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for Management.xaml
    /// </summary>
    public partial class Management : Window, INotifyPropertyChanged
    {
        DbConnection cnn = new DbConnection();
        
        #region Classes
        
        private int click = 0;
        private ObservableCollection<User> user;
        private ObservableCollection<Pizza> pizza;
        
        private Pizza selectedPizza;
        private User selectedMedewerker;

        public ObservableCollection<User> User
        {
            get { return user; }
            set { user = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<Pizza> Pizza
        {
            get { return pizza; }
            set { pizza = value; NotifyPropertyChanged(); }
        }
        
        public User SelectedMedewerker
        {
            get { return selectedMedewerker; }
            set { selectedMedewerker = value; NotifyPropertyChanged(); }
        }

        public Pizza SelectedPizza
        {
            get { return selectedPizza; }
            set { selectedPizza = value; NotifyPropertyChanged(); }
        }
        #endregion

        public Management()
        {
            InitializeComponent();
            LoadAssets();
            DataContext = this;
        }
        private void LoadAssets()
        {
            lvWerknemers.ItemsSource = cnn.GetAllUsers();
            lvPizzas.ItemsSource = cnn.GetOnlyPizzas();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            ManagementToevoegen win = new ManagementToevoegen();
            click = 1;
            win.Show();
            this.Close();
            click = 0;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Login win2 = new Login();
         
            if (click == 0)
            {
                win2.Show();
            }
            else
            {

            }
        }

        private void btnGridEmployees_Click(object sender, RoutedEventArgs e)
        {
            csEmployees.Visibility = Visibility.Visible;
            csPizzas.Visibility = Visibility.Hidden;
            btnGridEmployees.Visibility = Visibility.Hidden;
            btnGridPizzas.Visibility = Visibility.Hidden;
            btnUitloggen.Visibility = Visibility.Hidden;
            LoadAssets();
        }

        private void btnGridPizzas_Click(object sender, RoutedEventArgs e)
        {
            csEmployees.Visibility = Visibility.Hidden;
            csPizzas.Visibility = Visibility.Visible;
            btnGridEmployees.Visibility = Visibility.Hidden;
            btnGridPizzas.Visibility = Visibility.Hidden;
            btnUitloggen.Visibility = Visibility.Hidden;
            LoadAssets();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            csEmployees.Visibility = Visibility.Hidden;
            csPizzas.Visibility = Visibility.Hidden;
            btnGridEmployees.Visibility = Visibility.Visible;
            btnGridPizzas.Visibility = Visibility.Visible;
            btnUitloggen.Visibility = Visibility.Visible;
        }

        private void btnUitloggen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBackP_Click(object sender, RoutedEventArgs e)
        {
            csEmployees.Visibility = Visibility.Hidden;
            csPizzas.Visibility = Visibility.Hidden;
            btnGridEmployees.Visibility = Visibility.Visible;
            btnGridPizzas.Visibility = Visibility.Visible;
            btnUitloggen.Visibility = Visibility.Visible;
        }

        private void btnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            if (selectedMedewerker != null)
            {
                User users = lvWerknemers.SelectedItem as User;
                ManagementMedewerkersAanpassen win = new ManagementMedewerkersAanpassen(users);
                click = 1;
                win.Show();
                this.Close();
                click = 0;
            }
            else
            {
                MessageBox.Show("Selecteer eerst een Pizza");
            }
        }

        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            User_Roles user_Roles = new User_Roles();

            if (selectedMedewerker != null)
            {
                user_Roles.user_Id = selectedMedewerker.Id;
                
                cnn.DeleteUsers(SelectedMedewerker);
                cnn.DeleteUser_Roles(user_Roles);
                LoadAssets();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een Pizza");
            }
        }

        private void btnToevoegenP_Click(object sender, RoutedEventArgs e)
        {
            ManagementPizzaToevoegen win = new ManagementPizzaToevoegen();
            click = 1;
            win.Show();
            this.Close();
            click = 0;
        }

        private void btnWijzigenP_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPizza != null)
            {
                Pizza pizzas = lvPizzas.SelectedItem as Pizza;
                ManagementPizzaAanpassen win = new ManagementPizzaAanpassen(pizzas);
                click = 1;
                win.Show();
                this.Close();
                click = 0;
            }
            else
            {
                MessageBox.Show("Selecteer eerst een Pizza");
            }
        }

        private void btnVerwijderenP_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPizza != null)
            {
                cnn.DeletePizza(selectedPizza);
                LoadAssets();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een Pizza");
            }
        }
    }
}
