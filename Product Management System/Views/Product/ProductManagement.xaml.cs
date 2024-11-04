using BusinessObjects.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Product_Management_System.Views.Product
{
    /// <summary>
    /// Interaction logic for ProductManagement.xaml
    /// </summary>
    public partial class ProductManagement : Page
    {
        private readonly IProductsService iProductsService;
        public ProductManagement()
        {
            InitializeComponent();
            iProductsService = new ProductsService();
            LoadData();
        }

        private void LoadData()
        {
            dgProducts.ItemsSource = iProductsService.GetAllProducts();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text) ||
                string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtCost.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                !dpStartDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Please fill requires fields(ProductId, Name, Cost, Price, StartDate).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var product = new BusinessObjects.Models.Product();
                product.ProductId = int.Parse(txtProductId.Text);
                product.Name = txtProductName.Text;
                product.Color = txtColor.Text;
                product.Cost = decimal.Parse(txtCost.Text);
                product.Price = decimal.Parse(txtPrice.Text);
                if (!string.IsNullOrEmpty(txtSubcategoryId.Text))
                {
                    product.SubcategoryId = int.Parse(txtSubcategoryId.Text);
                }
                if (!string.IsNullOrEmpty(txtModelId.Text))
                {
                    product.ModelId = int.Parse(txtModelId.Text);
                }
                product.SellStartDate = dpStartDate.SelectedDate.Value;
                if (dpEndDate.SelectedDate != null)
                {
                    product.SellEndDate = dpEndDate.SelectedDate.Value;
                }
                iProductsService.CreateProduct(product);
                MessageBox.Show("Create successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
                ClearForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text) ||
                string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtCost.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                !dpStartDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Please fill requires fields(ProductId, Name, Cost, Price, StartDate).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var product = new BusinessObjects.Models.Product();
                product.ProductId = int.Parse(txtProductId.Text);
                product.Name = txtProductName.Text;
                product.Color = txtColor.Text;
                product.Cost = decimal.Parse(txtCost.Text);
                product.Price = decimal.Parse(txtPrice.Text);
                if (!string.IsNullOrEmpty(txtSubcategoryId.Text))
                {
                    product.SubcategoryId = int.Parse(txtSubcategoryId.Text);
                }
                if (!string.IsNullOrEmpty(txtModelId.Text))
                {
                    product.ModelId = int.Parse(txtModelId.Text);
                }
                product.SellStartDate = dpStartDate.SelectedDate.Value;
                if(dpEndDate.SelectedDate != null)
                {
                    product.SellEndDate = dpEndDate.SelectedDate.Value;
                }
                iProductsService.UpdateProduct(product);
                MessageBox.Show("Update successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
                ClearForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text))
            {
                MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var product = new BusinessObjects.Models.Product
            {
                ProductId = int.Parse(txtProductId.Text)
            };

            iProductsService.DeleteProduct(product);
            MessageBox.Show("Delete successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            LoadData();
            ClearForm();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtColor.Clear();
            txtCost.Clear();
            txtPrice.Clear();
            txtSubcategoryId.Clear();
            txtModelId.Clear();
            dpStartDate.SelectedDate = null;
            dpEndDate.SelectedDate = null;
        }

        private void dgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProducts.SelectedItem is BusinessObjects.Models.Product selectedProduct)
            {
                txtProductId.Text = selectedProduct.ProductId.ToString();
                txtProductName.Text = selectedProduct.Name;
                txtColor.Text = selectedProduct.Color;
                txtCost.Text = selectedProduct.Cost.ToString();
                txtPrice.Text = selectedProduct.Price.ToString();
                txtSubcategoryId.Text = selectedProduct.SubcategoryId.ToString();
                txtModelId.Text = selectedProduct.ModelId.ToString();
                dpStartDate.SelectedDate = selectedProduct.SellStartDate;
                dpEndDate.SelectedDate = selectedProduct.SellEndDate;
            }
        }
    }
}
