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
        private int click = 0;
        private ObservableCollection<User> user;
        
        public ObservableCollection<User> User
        {
            get { return user; }
            set { user = value; NotifyPropertyChanged(); }
        }
        public Management()
        {
            InitializeComponent();
            LoadAssets();
        }
        private void LoadAssets()
        {
            lvWerknemers.ItemsSource = cnn.GetAllUsers();
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
    }
}
