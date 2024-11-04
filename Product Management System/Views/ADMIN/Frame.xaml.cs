using Product_Management_System.Views.Authentication;
using Product_Management_System.Views.Product;
using Product_Management_System.Views.ProductCostHistory;
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
    /// Interaction logic for Frame.xaml
    /// </summary>
    public partial class Frame : Window
    {
        public Frame()
        {
            InitializeComponent();
        }

        private void btnPriceHistory_Click(object sender, RoutedEventArgs e)
        {
            frMainContent.Navigate(new ProductPriceHistoryPage());
        }

        private void btnProductInventory_Click(object sender, RoutedEventArgs e)
        {
            frMainContent.Navigate(new ProductInventoryPage());
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            AdminHome page = new AdminHome();
            page.Show();
            this.Hide();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            frMainContent.Navigate(new ProductManagement());
        }

        private void btnProductCostHistory_Click(object sender, RoutedEventArgs e)
        {
            frMainContent.Navigate(new ProductCostHistoryManagePage());
        }
    }
}
