using Amirhanov_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        public AddOrderPage()
        {
            InitializeComponent();
            LoadStatuses();
            LoadCleaningGroups(); 
        }

        private void LoadStatuses()
        {
            StatusBox.ItemsSource = App.DB.Statuses.ToList();
            StatusBox.DisplayMemberPath = "StatusName";
            StatusBox.SelectedValuePath = "StatusID";
        }
        private void LoadCleaningGroups()
        {
            CleaningGroupBox.ItemsSource = App.DB.CleaningGroups.ToList();
            CleaningGroupBox.DisplayMemberPath = "GroupName";
            CleaningGroupBox.SelectedValuePath = "GroupID";
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddressBox.Text) ||
                string.IsNullOrWhiteSpace(RoomCountBox.Text) ||
                string.IsNullOrWhiteSpace(TotalAreaBox.Text) ||
                DatePicker.SelectedDate == null ||
                StatusBox.SelectedItem == null ||
                CleaningGroupBox.SelectedItem == null)
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            if (!int.TryParse(RoomCountBox.Text, out int roomCount))
            {
                MessageBox.Show("Количество комнат должно быть числом.");
                return;
            }

            if (!double.TryParse(TotalAreaBox.Text, out double totalArea))
            {
                MessageBox.Show("Общая площадь должна быть числом.");
                return;
            }

            var newOrder = new Orders
            {
                EmployeeID = App.loggedEmployee.EmployeeID, 
                Address = AddressBox.Text,
                RoomCount = roomCount,
                TotalArea = totalArea,
                Date = DatePicker.SelectedDate.Value.Date,
                StatusID = (int)StatusBox.SelectedValue,
                CleaningGroupId = (int)CleaningGroupBox.SelectedValue 
            };

            App.DB.Orders.Add(newOrder); 
            App.DB.SaveChanges(); 

            MessageBox.Show("Заказ успешно добавлен.");
            NavigationService?.GoBack(); 
        }

        private void CallCenterPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CallCenterPage());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.loggedEmployee = null;

            NavigationService.Navigate(new LoginPage());
        }
    }
}
