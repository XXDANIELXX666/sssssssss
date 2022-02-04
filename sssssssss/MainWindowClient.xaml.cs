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
        string currentLetter = "";
        public MainWindowClient()
        {
            InitializeComponent();
            context = new SALONEntities();
            ShowTable();
            if (TxtEmail.Text == null && TxtPhone.Text == null)
                return;
            List<Client> listClient = context.Client.ToList();
            listClient = listClient.Where(x => x.Email.ToLower().Contains(TxtEmail.Text.ToLower())).ToList();
            listClient = listClient.Where(x => x.Phone.ToLower().Contains(TxtPhone.Text.ToLower())).ToList();
            if (currentLetter.Count() == 1)
            {
                listClient = listClient.Where(x => x.FirstName.Contains(currentLetter)).ToList();
            }
            DataGridClient.ItemsSource = listClient.OrderBy(x => x.FirstName).ToList();
            ShowLetters();
        }

        private void ShowLetters()
        {
            for (char i = 'А'; i <= 'Я'; i++)
            {
                TextBlock letter = new TextBlock
                {
                    Text = i.ToString(),
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White,
                    Margin = new Thickness(10, 1, 5, 1)
                };
                letter.MouseLeftButtonDown += TextBlock_MouseLeftButtonDown;
                StackLetters.Children.Add(letter);
            }
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

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var label = (TextBlock)sender;
            currentLetter = label.Text;
            foreach (TextBlock letter in StackLetters.Children)
            {
                letter.Foreground = Brushes.White;
            }
            label.Foreground = Brushes.Gold;
            ShowTable();
        }

        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
