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

namespace sssssssss.page
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Window
    {
        SALONEntities context;
        public PageMain()
        {
            InitializeComponent();
            context = new SALONEntities();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            var user = context.Client.FirstOrDefault(u => (u.Email == Login.Text || u.Phone == Login.Text) && u.LastName == Password.Password);
            if (user == null)
            {
                MessageBox.Show("Неверные данные");
                return;
            }
            else
            {
                if (user.ID == 1)
                {
                    MessageBox.Show("Привет");
                    var admin = new MainWindow();
                    admin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Привет");
                    var tables = new MainWindow();
                    tables.Show();
                    this.Close();
                }
            }
        }
    }
}
