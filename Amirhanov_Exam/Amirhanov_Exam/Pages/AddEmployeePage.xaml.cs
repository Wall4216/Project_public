using Amirhanov_Exam.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Amirhanov_Exam.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        public AddEmployeePage()
        {
            InitializeComponent(); 
            LoadRoles();
        }

        private void LoadRoles()
        {
            RoleBox.ItemsSource = App.DB.Roles.ToList();
            RoleBox.DisplayMemberPath = "RoleName";
            RoleBox.SelectedValuePath = "RoleID";
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameBox.Text) ||
                RoleBox.SelectedItem == null ||
                string.IsNullOrWhiteSpace(LoginBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password) ||
                string.IsNullOrWhiteSpace(SecretWordBox.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            var newEmployee = new Employees
            {
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
                RoleID = (int)RoleBox.SelectedValue,
                Login = LoginBox.Text,
                Password = PasswordBox.Password, 
                SecretWord = SecretWordBox.Text
            };

            App.DB.Employees.Add(newEmployee);
            App.DB.SaveChanges();

            MessageBox.Show("Сотрудник успешно добавлен");
            NavigationService.GoBack(); 
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.loggedEmployee = null;

            NavigationService.Navigate(new LoginPage());
        }
        
        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeesPage());
        }
    }
}
