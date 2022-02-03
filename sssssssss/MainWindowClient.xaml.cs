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

namespace sssssssss
{
    /// <summary>
    /// Логика взаимодействия для MainWindowClient.xaml
    /// </summary>
    public partial class MainWindowClient : Window
    {
        SALONEntities context;
        public MainWindowClient()
        {
            InitializeComponent();
            context = new SALONEntities();
            ShowTable();
        }

        private void ShowTable()
        {
            DataGridClient.ItemsSource = context.Client.ToList();
        }

        private void BtnAd_Click(object sender, RoutedEventArgs e)
        {
            var NewRental = new Client();
            context.Client.Add(NewRental);
            var addRentalWindow = new AddDataClient(context, NewRental);
            addRentalWindow.ShowDialog();
        }

        private void BtnD_Click(object sender, RoutedEventArgs e)
        {
            var currentClient = DataGridClient.SelectedItem as Client;
            if (currentClient == null)
            {
                MessageBox.Show("Выберите строку!");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удадить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Client.Remove(currentClient);
                context.SaveChanges();
                ShowTable();
            }
        }
        

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentCar = BtnEdit.DataContext as Client;
            var EdiWindow = new AddDataClient(context, currentCar);
            EdiWindow.ShowDialog();
        }
    }
}
