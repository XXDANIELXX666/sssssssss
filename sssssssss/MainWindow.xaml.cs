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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sssssssss
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SALONEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new SALONEntities();
            ShowLetters();
            
            ShowTable();
            DataGridClientService.ItemsSource = context.Client.ToList();
            DataGridClientService.ItemsSource = context.Service.ToList();
            DataGridClientService.ItemsSource = context.ClientService.ToList();
            if (CmbTablse.SelectedIndex == 0)
            {
                DataGridClientService.ItemsSource = context.Client.ToList();
            }
            if (CmbTablse.SelectedIndex == 1)
            {
                DataGridClientService.ItemsSource = context.Service.ToList();
            }

        }

        private void ShowLetters()
        {
            
        }

        private void ShowTable()
        {
            DataGridClientService.ItemsSource = context.ClientService.ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewClientService = new ClientService();
            context.ClientService.Add(NewClientService);
            var BtnAddData = new BtnAddData(context, NewClientService);
            BtnAddData.ShowDialog();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentClientService = DataGridClientService.SelectedItem as ClientService;
            if (currentClientService == null)
            {
                MessageBox.Show("");
                return;

            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.ClientService.Remove(currentClientService);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentRental = BtnEdit.DataContext as ClientService;
            var EdiWindow = new BtnAddData(context, currentRental);
            EdiWindow.ShowDialog();
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            var RentalSelect = new MainWindowClient();
            RentalSelect.ShowDialog();
        }

        private void CmbTablse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            var ClientSelect = new Client();
            ClientSelect.ShowDialog();
        }

        private void BtnService_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
