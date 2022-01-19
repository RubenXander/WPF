using Project4_WPF.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project4_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbConnection cnn = new DbConnection();

        private ObservableCollection<User> user;

        public ObservableCollection<User> User
        {
            get { return user; }
            set { user = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadAssets();
        }

        private void LoadAssets()
        {
            lvBestellingen.ItemsSource = cnn.GetAllUsers().ToList();
        }

        private void btnBereidenToevoegen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
