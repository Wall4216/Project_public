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
        }

        private void LoadStatuses()
        {
            StatusBox.ItemsSource = App.DB.Statuses.ToList();
            StatusBox.DisplayMemberPath = "StatusName";
            StatusBox.SelectedValuePath = "StatusID";
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AddressBox.Text) ||
                string.IsNullOrWhiteSpace(RoomCountBox.Text) ||
                string.IsNullOrWhiteSpace(TotalAreaBox.Text) ||
                DatePicker.SelectedDate == null ||
                StatusBox.SelectedItem == null ||
                HoursBox.SelectedItem == null ||
                MinutesBox.SelectedItem == null)
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            var selectedDate = DatePicker.SelectedDate.Value.Date;
            var hours = int.Parse(HoursBox.SelectedItem.ToString());
            var minutes = int.Parse(MinutesBox.SelectedItem.ToString());
            var time = new TimeSpan(hours, minutes, 0);
            var dateTime = selectedDate + time;

            var newOrder = new Orders
            {
                EmployeeID = App.loggedEmployee.EmployeeID,
                Address = AddressBox.Text,
                RoomCount = int.Parse(RoomCountBox.Text),
                TotalArea = double.Parse(TotalAreaBox.Text),
                Date = dateTime,
                StatusID = (int)StatusBox.SelectedValue
            };

            App.DB.Orders.Add(newOrder);
            App.DB.SaveChanges();

            MessageBox.Show("Заказ успешно добавлен.");
            NavigationService.GoBack();
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
