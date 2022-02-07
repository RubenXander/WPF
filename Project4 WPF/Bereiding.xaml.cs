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
    /// Interaction logic for Bereiding.xaml
    /// </summary>
    public partial class Bereiding : Window, INotifyPropertyChanged
    {
        DbConnection cnn = new DbConnection();
        
        #region classes 
        private ObservableCollection<User> user;
        private ObservableCollection<Orders> order;

        public ObservableCollection<User> User
        {
            get { return user; }
            set { user = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<Orders> Order
        {
            get { return order; }
            set { order = value; NotifyPropertyChanged(); }
        }

        private Orders selectedOrders;

        public Orders SelectedOrders
        {
            get { return selectedOrders; }
            set { selectedOrders = value; NotifyPropertyChanged(); }
        }

        private string selectedStatus;

        public string SelectedStatus
        {
            get { return selectedStatus; }
            set { selectedStatus = value; }
        }

        private List<string> stati = new List<string>() { "Besteld", "Bereid", "In de oven", "Klaar voor bezorging", "Klaar om op te halen" };

        public List<string> Stati
        {
            get { return stati; }
        }

        #endregion

        public Bereiding()
        {
            InitializeComponent();
            DataContext = this;
            LoadAssets();
        }
        private void LoadAssets()
        {
            Order = cnn.GetAllOrders();
        }
        private void LoadPizza()
        {
            if (SelectedOrders == null)
            {
                return;
            }
            lvPizza.ItemsSource = cnn.GetAllPizza(SelectedOrders.Id);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Login win = new Login();
            win.Show();
        }

        private void lvBestellingen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadPizza();
        }

        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            Orders O = new Orders();
            O.Status = SelectedStatus;

            cnn.EditStatus(O, SelectedOrders.Id);
            LoadAssets();
        }
        
        private void btnUitloggen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
