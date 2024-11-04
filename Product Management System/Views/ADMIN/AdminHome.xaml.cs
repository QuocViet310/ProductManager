using BusinessObjects.Models;
using Product_Management_System.Views.Admin;
using Product_Management_System.Views.Authentication;
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

namespace Product_Management_System.Views.ADMIN
{
    /// <summary>
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : Window
    {
        public AdminHome()
        {
            InitializeComponent();
        }


        private void btnUserManagement_Click(object sender, RoutedEventArgs e)
        {
            AdminDashboardWindow page = new AdminDashboardWindow();
            page.Show();
            this.Hide();
        }

        private void btnReportManagement_Click(object sender, RoutedEventArgs e)
        {
            Frame page = new Frame();
            page.Show();
            this.Hide();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            //frAdminContent.Navigate(new SettingsPage());
        }

        private void txtAdminFullName_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Xử lý sự kiện khi người dùng nhấn vào tên admin
        }

        private void btnOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow page = new LoginWindow();
            page.Show();
            this.Hide();
        }
    }
}
