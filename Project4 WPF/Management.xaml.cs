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
            //haalt de gegevens op en zet ze in de ListViews

            lvWerknemers.ItemsSource = cnn.GetAllUsers();
            lvPizzas.ItemsSource = cnn.GetOnlyPizzas();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
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
            //verbergd alle items behalve de medewerkers

            csEmployees.Visibility = Visibility.Visible;
            csPizzas.Visibility = Visibility.Hidden;
            btnGridEmployees.Visibility = Visibility.Hidden;
            btnGridPizzas.Visibility = Visibility.Hidden;
            btnUitloggen.Visibility = Visibility.Hidden;
            LoadAssets();
        }

        private void btnGridPizzas_Click(object sender, RoutedEventArgs e)
        {
            //verbergd alle items behalve de pizza's

            csEmployees.Visibility = Visibility.Hidden;
            csPizzas.Visibility = Visibility.Visible;
            btnGridEmployees.Visibility = Visibility.Hidden;
            btnGridPizzas.Visibility = Visibility.Hidden;
            btnUitloggen.Visibility = Visibility.Hidden;
            LoadAssets();
        }
        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            //gaat naar de pagina waar je medewerkers kan toevoegen

            ManagementToevoegen win = new ManagementToevoegen();
            click = 1;
            win.Show();
            this.Close();
            click = 0;
        }
        private void btnToevoegenP_Click(object sender, RoutedEventArgs e)
        {
            //gaat naar de pagina waar je pizza"s kan toevoegen

            ManagementPizzaToevoegen win = new ManagementPizzaToevoegen();
            click = 1;
            win.Show();
            this.Close();
            click = 0;
        }
        private void btnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            //gaat naar de pagina waar je wijzigingen kan maken bij de medewerkers

            if (selectedMedewerker != null)
            {
                //stuurd de gegevens van de medewerker door naar de andere pagina

                User users = lvWerknemers.SelectedItem as User;
                ManagementMedewerkersAanpassen win = new ManagementMedewerkersAanpassen(users);
                click = 1;
                win.Show();
                this.Close();
                click = 0;
            }
            else
            {
                MessageBox.Show("Selecteer eerst een Medewerker");
            }
        }

        private void btnWijzigenP_Click(object sender, RoutedEventArgs e)
        {
            //gaat naar de pagina waar je wijzigen kan maken bij de pizza's

            if (selectedPizza != null)
            {
                //stuurd de gegevens van de pizza door naar de andere pagina

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
        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            //verwijdered de geselecteerde medewerker

            User_Roles user_Roles = new User_Roles();

            //kijkt of er een medewerker is geselecteerd

            if (selectedMedewerker != null)
            {
                //verwijdered de geselecteerde medewerker

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

        private void btnVerwijderenP_Click(object sender, RoutedEventArgs e)
        {
            //kijkt of er een medewerker is geselecteerd

            if (selectedPizza != null)
            {
                //verwijderd de geselecteerde pizza

                cnn.DeletePizza(selectedPizza);
                LoadAssets();
            }
            else
            {
                MessageBox.Show("Selecteer eerst een Pizza");
            }
        }
        
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //gaat terug naar de vorige pagina door alle andere items omzichtbaar te maken

            csEmployees.Visibility = Visibility.Hidden;
            csPizzas.Visibility = Visibility.Hidden;
            btnGridEmployees.Visibility = Visibility.Visible;
            btnGridPizzas.Visibility = Visibility.Visible;
            btnUitloggen.Visibility = Visibility.Visible;
        }
        
        private void btnBackP_Click(object sender, RoutedEventArgs e)
        {
            //gaat terug naar de vorige pagina door alle andere items omzichtbaar te maken

            csEmployees.Visibility = Visibility.Hidden;
            csPizzas.Visibility = Visibility.Hidden;
            btnGridEmployees.Visibility = Visibility.Visible;
            btnGridPizzas.Visibility = Visibility.Visible;
            btnUitloggen.Visibility = Visibility.Visible;
        }

        private void btnUitloggen_Click(object sender, RoutedEventArgs e)
        {
            //gaat terug naar de login pagina

            this.Close();
        }
    }
}
