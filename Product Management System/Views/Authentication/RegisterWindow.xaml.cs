using System;
using System.Windows;
using BusinessObjects.Models;
using Repositories;

namespace Product_Management_System.Views.Authentication
{
    public partial class RegisterWindow : Window
    {
        private readonly UserRepository _userRepository;

        public RegisterWindow()
        {
            InitializeComponent();
            _userRepository = new UserRepository(new ProductManagementDbContext());
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string username = txtUser.Text;
            string password = txtPass.Password;
            string confirmPassword = txtConfirmPass.Password;

            // Check for empty fields
            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Full Name cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_userRepository.GetUserByUsername(username) != null)
            {
                MessageBox.Show("Username already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_userRepository.GetUserByUsername(username) != null)
            {
                MessageBox.Show("Username already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            User newUser = new User
            {
                Username = username,
                Password = password,
                Fullname = fullName,
                Email = email,
                IsActive = true,
                RoleId = 2
            };

            try
            {
                _userRepository.AddUser(newUser);
                MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void clear()
        {
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtUser.Text = "";
            txtPass.Password = "";
            txtConfirmPass.Password = "";
        }
    }
}
