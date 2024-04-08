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
    /// Логика взаимодействия для EditEmployeePage.xaml
    /// </summary>
    public partial class EditEmployeePage : Page
    {
        private Employees _employeeToEdit;

        public EditEmployeePage(Employees employeeToEdit)
        {
            InitializeComponent();
            _employeeToEdit = employeeToEdit;
            this.DataContext = _employeeToEdit;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            App.DB.SaveChanges();

            this.CancelButton_Click(sender, e);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.loggedEmployee = null;

            NavigationService.Navigate(new LoginPage());
        }
    }
}