using BusinessObjects.Models;
using Product_Management_System.Views.ADMIN;
using Product_Management_System.Views.Authentication;
using Product_Management_System.Views.Product;
using Product_Management_System.Views.ProductCostHistory;
using Repositories;
using System.Windows;

namespace Product_Management_System
{
    public partial class UserInfoWindow : Window
    {
        private User currentUser;

        public UserInfoWindow(User user)
        {
            InitializeComponent();
            currentUser = user;
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
            LoginWindow page = new LoginWindow();
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