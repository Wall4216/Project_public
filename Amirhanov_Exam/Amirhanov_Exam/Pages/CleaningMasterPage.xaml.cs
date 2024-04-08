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
    /// Логика взаимодействия для CleaningMasterPage.xaml
    /// </summary>
    public partial class CleaningMasterPage : Page
    {
        public CleaningMasterPage()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            var employeeCleaningGroupIds = App.DB.CleaningGroupMembers
                .Where(member => member.EmployeeID == App.loggedEmployee.EmployeeID)
                .Select(member => member.GroupID)
                .Distinct()
                .ToList();

            var orders = App.DB.Orders
                .Where(order => employeeCleaningGroupIds.Contains(order.CleaningGroupId))
                .ToList();

            OrdersDataGrid.ItemsSource = orders;
        }

        private void ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int orderId = (int)button.CommandParameter;
            var order = App.DB.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order != null)
            {
                order.StatusID = 3; 
                App.DB.SaveChanges(); 
                LoadOrders();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.loggedEmployee = null;

            NavigationService.Navigate(new LoginPage());
        }

        private void AddReport_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int orderId = (int)button.CommandParameter;
            var order = App.DB.Orders.FirstOrDefault(o => o.OrderID == orderId);

            if (order != null && order.StatusID == 3 && App.loggedEmployee.RoleID == 4)
            {
                NavigationService.Navigate(new ReportPage(orderId));
            }
        }
    }
}
