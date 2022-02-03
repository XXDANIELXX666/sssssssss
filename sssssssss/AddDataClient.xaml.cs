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
    /// Логика взаимодействия для AddDataClient.xaml
    /// </summary>
    public partial class AddDataClient : Window
    {
        SALONEntities context;
        public AddDataClient(SALONEntities context, Client newclient)
        {
            InitializeComponent();
            Cmb.ItemsSource = context.Gender.ToList();
            this.context = context;
            this.DataContext = newclient;
        }

        private void BtnSav_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }
    }
}
