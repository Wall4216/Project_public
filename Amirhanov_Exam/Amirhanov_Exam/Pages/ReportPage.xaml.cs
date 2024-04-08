using Amirhanov_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        private readonly int _orderId;

        public ReportPage(int orderId)
        {
            InitializeComponent();
            _orderId = orderId; 
        }

        private void SaveReport_Click(object sender, RoutedEventArgs e)
        {
            var report = new Report()
            {
                OrderID = _orderId,
                EmployeeID = App.loggedEmployee.EmployeeID,
                Description = DescriptionTextBox.Text,
                Consumables = ConsumablesTextBox.Text,
                ReportDate = DateTime.Now 
            };
            App.DB.Report.Add(report);
            App.DB.SaveChanges();

            MessageBox.Show("Отчет сохранен!");
            
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.loggedEmployee = null;

            NavigationService.Navigate(new LoginPage());
        }
    }
}
