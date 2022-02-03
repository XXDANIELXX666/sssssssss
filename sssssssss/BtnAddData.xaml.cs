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
    /// Логика взаимодействия для BtnAddData.xaml
    /// </summary>
    public partial class BtnAddData : Window
    {
        SALONEntities context;
        public BtnAddData(SALONEntities context, ClientService ClientService)
        {
            InitializeComponent();
            this.context = context;
            CmbClient.ItemsSource = context.Client.ToList();
            CmbService.ItemsSource = context.Service.ToList();
            this.DataContext = ClientService;


        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
