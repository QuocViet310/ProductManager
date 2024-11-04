using BusinessObjects.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Product_Management_System
{
    public partial class ProductInventoryPage : Page
    {
        private readonly IInventoryService _inventoryService;
        private List<ProductInventory> _inventories;

        public ProductInventoryPage()
        {
            InitializeComponent();
            _inventoryService = new InventoryService();
            LoadInventories();
        }

        private void LoadInventories()
        {
            _inventories = _inventoryService.GetAllInventories();
            dgData.ItemsSource = _inventories;
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            int? productId = string.IsNullOrEmpty(txtFilterProductID.Text) ? null : (int?)int.Parse(txtFilterProductID.Text);
            short? locationId = string.IsNullOrEmpty(txtFilterLocationID.Text) ? null : (short?)short.Parse(txtFilterLocationID.Text);

            var filteredInventories = _inventories.Where(i =>
                (!productId.HasValue || i.ProductId == productId) &&
                (!locationId.HasValue || i.LocationId == locationId)).ToList();

            dgData.ItemsSource = filteredInventories;
        }

        private void btnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            txtFilterProductID.Clear();
            txtFilterLocationID.Clear();
            dgData.ItemsSource = _inventories;
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is ProductInventory selectedInventory)
            {
                txtProductID.Text = selectedInventory.ProductId.ToString();
                txtLocationID.Text = selectedInventory.LocationId.ToString();
                txtShelf.Text = selectedInventory.Shelf;
                txtBin.Text = selectedInventory.Bin.ToString();
                txtQuantity.Text = selectedInventory.Quantity.ToString();
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputFields())
            {
                try
                {
                    var newInventory = new ProductInventory
                    {
                        ProductId = int.Parse(txtProductID.Text),
                        LocationId = short.Parse(txtLocationID.Text),
                        Shelf = txtShelf.Text,
                        Bin = byte.Parse(txtBin.Text),
                        Quantity = short.Parse(txtQuantity.Text)
                    };

                    _inventoryService.InsertInventory(newInventory);
                    MessageBox.Show("Create successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadInventories();
                    ClearInputFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating inventory: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem is ProductInventory selectedInventory)
            {
                if (ValidateInputFields())
                {
                    try
                    {
                        selectedInventory.Shelf = txtShelf.Text;
                        selectedInventory.Bin = byte.Parse(txtBin.Text);
                        selectedInventory.Quantity = short.Parse(txtQuantity.Text);

                        _inventoryService.UpdateInventory(selectedInventory);
                        MessageBox.Show("Update successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadInventories();
                        ClearInputFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating inventory: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an inventory to update.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgData.SelectedItem is ProductInventory selectedInventory)
            {
                var result = MessageBox.Show("Are you sure you want to delete this inventory?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _inventoryService.DeleteInventory(selectedInventory);
                        MessageBox.Show("Delete successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadInventories();
                        ClearInputFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting inventory: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an inventory to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearInputFields()
        {
            txtProductID.Clear();
            txtLocationID.Clear();
            txtShelf.Clear();
            txtBin.Clear();
            txtQuantity.Clear();
        }

        private bool ValidateInputFields()
        {
            StringBuilder validationErrors = new StringBuilder();

            if (!int.TryParse(txtProductID.Text, out int productId) || productId <= 0)
            {
                validationErrors.AppendLine("Product ID must be a positive integer.");
            }

            if (!short.TryParse(txtLocationID.Text, out short locationId) || locationId <= 0)
            {
                validationErrors.AppendLine("Location ID must be a positive short integer.");
            }

            if (!byte.TryParse(txtBin.Text, out byte bin) || bin < 0)
            {
                validationErrors.AppendLine("Bin must be a non-negative byte.");
            }

            if (!short.TryParse(txtQuantity.Text, out short quantity) || quantity < 0)
            {
                validationErrors.AppendLine("Quantity must be a non-negative short integer.");
            }

            if (validationErrors.Length > 0)
            {
                MessageBox.Show(validationErrors.ToString(), "Validation Errors", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
