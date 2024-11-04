using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Product_Management_System
{
    /// <summary>
    /// Interaction logic for ProductPriceHistoryWindow.xaml
    /// </summary>
    public partial class ProductPriceHistoryPage : Page
    {
        private readonly IPriceHistoryService iPriceHistoryService;

        public ProductPriceHistoryPage()
        {
            InitializeComponent();
            iPriceHistoryService = new PriceHistoryService();
            LoadProductPriceHistory();
        }

        private void LoadProductPriceHistory()
        {
            dgData.ItemsSource = null;
            var priceHistory = iPriceHistoryService.GetAllPriceHistories();
            dgData.ItemsSource = priceHistory;
        }

        private void ClearInputField()
        {
            txtProductID.Clear();
            dpStartDate.SelectedDate = null;
            dpEndDate.SelectedDate = null;
            txtPrice.Clear();
            txtFilterPrice.Clear();
            dpFilterStartDate.SelectedDate = null;
            dpFilterEndDate.SelectedDate = null;
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is ProductPriceHistory selectedProduct)
            {
                txtProductID.Text = selectedProduct.ProductId.ToString();
                dpStartDate.SelectedDate = selectedProduct.StartDate;
                dpEndDate.SelectedDate = selectedProduct.EndDate.HasValue
                    ? selectedProduct.EndDate
                    : (DateTime?)null;
                txtPrice.Text = selectedProduct.Price.ToString();
            }
        }

        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            ClearInputField();
            LoadProductPriceHistory();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputFields())
            {
                try
                {
                    var newPriceHistory = new ProductPriceHistory
                    {
                        ProductId = Convert.ToInt32(txtProductID.Text),
                        StartDate = dpStartDate.SelectedDate ?? DateTime.Now,
                        EndDate = dpEndDate.SelectedDate,
                        Price = decimal.Parse(txtPrice.Text)
                    };
                    iPriceHistoryService.InsertPriceHistory(newPriceHistory);
                    MessageBox.Show("Create successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadProductPriceHistory();
                    ClearInputField();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating price history: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    LoadProductPriceHistory();
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateInputFields())
                {
                    if (dgData.SelectedItem is ProductPriceHistory selectedProduct)
                    //if (int.TryParse(txtProductID.Text, out int productId))
                    {
                        selectedProduct.StartDate = dpStartDate.SelectedDate.HasValue
                            ? dpStartDate.SelectedDate.Value : DateTime.Now;
                        selectedProduct.EndDate = dpEndDate.SelectedDate;
                        selectedProduct.Price = decimal.Parse(txtPrice.Text);

                        iPriceHistoryService.UpdatePriceHistory(selectedProduct);
                        MessageBox.Show("Update successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadProductPriceHistory();
                        ClearInputField();
                    }
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadProductPriceHistory();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgData.SelectedItem is ProductPriceHistory selectedProduct)
                {
                    iPriceHistoryService.DeletePriceHistory(selectedProduct);
                    MessageBox.Show("Delete successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadProductPriceHistory();
                    ClearInputField();
                }
                else
                {
                    MessageBox.Show("No product selected to remove!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting price history: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                LoadProductPriceHistory();
            }
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            DateTime? startDate = dpFilterStartDate.SelectedDate;
            DateTime? endDate = dpFilterEndDate.SelectedDate;
            decimal? price = null;

            if (!string.IsNullOrWhiteSpace(txtFilterPrice.Text) && decimal.TryParse(txtFilterPrice.Text, out decimal parsedPrice))
            {
                price = parsedPrice;
            }

            var filteredHistories = iPriceHistoryService.GetAllPriceHistories().AsQueryable();

            if (startDate != null)
            {
                filteredHistories = filteredHistories.Where(h => h.StartDate >= startDate);
            }

            if (endDate != null)
            {
                filteredHistories = filteredHistories.Where(h => h.EndDate <= endDate);
            }

            if (price != null)
            {
                filteredHistories = filteredHistories.Where(h => h.Price == price);
            }

            dgData.ItemsSource = filteredHistories.ToList();
        }

        private bool ValidateInputFields()
        {
            StringBuilder validationErrors = new StringBuilder();

            if (!int.TryParse(txtProductID.Text, out _))
            {
                validationErrors.AppendLine("Product ID must be a valid integer.");
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                validationErrors.AppendLine("Price must be a valid decimal number greater than 0.");
            }

            // Uncomment if you want to ensure that start date is selected and end date is after start date
            /*
            if (!dpStartDate.SelectedDate.HasValue)
            {
                validationErrors.AppendLine("Start Date must be selected.");
            }

            if (dpEndDate.SelectedDate.HasValue && dpStartDate.SelectedDate.HasValue && dpEndDate.SelectedDate.Value < dpStartDate.SelectedDate.Value)
            {
                validationErrors.AppendLine("End Date cannot be earlier than Start Date.");
            }
            */

            if (validationErrors.Length > 0)
            {
                MessageBox.Show(validationErrors.ToString(), "Validation Errors", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
