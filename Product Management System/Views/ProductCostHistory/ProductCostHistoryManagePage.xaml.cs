using Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BusinessObjects.Models;
using System.Text;

namespace Product_Management_System.Views.ProductCostHistory
{
    /// <summary>
    /// Interaction logic for ProductCostHistoryManagePage.xaml
    /// </summary>
    public partial class ProductCostHistoryManagePage : Page
    {
        private readonly IProductCostHistoryService _productCostHistoryService;
        public ProductCostHistoryManagePage()
        {
            InitializeComponent();
            _productCostHistoryService = new ProductCostHistoryService();
            LoadData();
        }

        private void LoadData()
        {
            dgProducts.ItemsSource = _productCostHistoryService.GetAllProductCostHistories();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSearch.Text) && int.TryParse(txtSearch.Text, out int productId))
                {
                    dgProducts.ItemsSource = _productCostHistoryService.GetAllProductCostHistories().Where(p => p.ProductId == productId);
                }
                else
                {
                    MessageBox.Show("Invalid Product ID format", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not found!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputFields())
            {
                try
                {
                    var productCostHistory = new BusinessObjects.Models.ProductCostHistory
                    {
                        StartDate = dpStartDate.SelectedDate.Value,
                        EndDate = dpEndDate.SelectedDate,
                        Cost = decimal.Parse(txtCost.Text),
                        ProductId = int.Parse(txtProductId.Text)
                    };

                    _productCostHistoryService.CreateProductCostHistory(productCostHistory);
                    MessageBox.Show("Create successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputFields())
            {
                try
                {
                    var productCostHistory = new BusinessObjects.Models.ProductCostHistory
                    {
                        ProductId = int.Parse(txtProductId.Text),
                        StartDate = dpStartDate.SelectedDate.Value,
                        EndDate = dpEndDate.SelectedDate,
                        Cost = decimal.Parse(txtCost.Text)
                    };

                    _productCostHistoryService.UpdateProductCostHistory(productCostHistory);
                    MessageBox.Show("Update successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var productCostHistory = new BusinessObjects.Models.ProductCostHistory
                {
                    ProductId = int.Parse(txtProductId.Text),
                    StartDate = dpStartDate.SelectedDate.Value,
                    EndDate = dpEndDate.SelectedDate,
                    Cost = decimal.Parse(txtCost.Text)
                };

                _productCostHistoryService.DeleteProductCostHistory(productCostHistory);
                MessageBox.Show("Delete successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtProductId.Clear();
            dpStartDate.SelectedDate = null;
            dpEndDate.SelectedDate = null;
            txtCost.Clear();
            txtSearch.Clear();
        }

        private bool ValidateInputFields()
        {
            StringBuilder validationErrors = new StringBuilder();

            if (!int.TryParse(txtProductId.Text, out _))
            {
                validationErrors.AppendLine("Product ID must be a valid integer.");
            }

            if (!decimal.TryParse(txtCost.Text, out decimal cost) || cost <= 0)
            {
                validationErrors.AppendLine("Cost must be a valid decimal number greater than 0.");
            }

            //if (!dpStartDate.SelectedDate.HasValue)
            //{
            //    validationErrors.AppendLine("Start Date must be selected.");
            //}

            //if (dpEndDate.SelectedDate.HasValue && dpEndDate.SelectedDate.Value < dpStartDate.SelectedDate.Value)
            //{
            //    validationErrors.AppendLine("End Date cannot be earlier than Start Date.");
            //}

            if (validationErrors.Length > 0)
            {
                MessageBox.Show(validationErrors.ToString(), "Validation Errors", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void dgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProducts.SelectedItem is BusinessObjects.Models.ProductCostHistory selectedProductCostHistory)
            {
                txtProductId.Text = selectedProductCostHistory.ProductId.ToString();
                dpStartDate.SelectedDate = selectedProductCostHistory.StartDate;
                dpEndDate.SelectedDate = selectedProductCostHistory.EndDate;
                txtCost.Text = selectedProductCostHistory.Cost.ToString();
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
