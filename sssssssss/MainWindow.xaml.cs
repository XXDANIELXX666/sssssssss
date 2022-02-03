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
            ShowTable();

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
                MessageBox.Show("Выберите строку!");
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

        }
    }
}
