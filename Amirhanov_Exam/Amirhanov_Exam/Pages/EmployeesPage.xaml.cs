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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();
            LoadRoles();
            LoadEmployees();
        }

        private void LoadRoles()
        {
            var roles = App.DB.Roles.ToList();
            roles.Insert(0, new Roles { RoleID = 0, RoleName = "Все" });
            RoleFilterComboBox.ItemsSource = roles;
            RoleFilterComboBox.SelectedIndex = 0;
        }

        private void LoadEmployees()
        {
            var employees = App.DB.Employees.Include("Roles").ToList();
            EmployeesDataGrid.ItemsSource = employees;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var filteredEmployees = App.DB.Employees.Include("Roles").AsQueryable();

            if (RoleFilterComboBox.SelectedIndex > 0)
            {
                var selectedRoleId = (int)RoleFilterComboBox.SelectedValue;
                filteredEmployees = filteredEmployees.Where(emp => emp.RoleID == selectedRoleId);
            }

            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                var searchText = SearchTextBox.Text.ToLower();
                filteredEmployees = filteredEmployees.Where(emp =>
                    emp.FirstName.ToLower().Contains(searchText) ||
                    emp.LastName.ToLower().Contains(searchText));
            }

            EmployeesDataGrid.ItemsSource = filteredEmployees.ToList();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmployeePage());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.loggedEmployee = null;

            NavigationService.Navigate(new LoginPage());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Employees employeeToDelete = (sender as Button).DataContext as Employees;
            if (employeeToDelete != null)
            {
                App.DB.Employees.Remove(employeeToDelete); 
                App.DB.SaveChanges(); 
                LoadEmployees(); 
            }
            else
            {
                MessageBox.Show("Вы не выбрали сотрудника");
            }    
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Employees employeeToEdit = (sender as Button).DataContext as Employees;
            if (employeeToEdit != null)
            {
                NavigationService.Navigate(new EditEmployeePage(employeeToEdit));
            }
        }
    }
}
