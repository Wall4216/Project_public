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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var username = LoginBox.Text;
            var password = PasswordBox.Password;
            var secretWord = SecretWordBox.Text;

            var loggedUser = App.DB.Employees.FirstOrDefault(x => x.Login == username && x.Password == password && x.SecretWord == secretWord);

            if (loggedUser == null)
            {
                MessageBox.Show("Неверный логин, пароль или секретное слово. Попробуйте снова");
                return;
            }

            App.loggedEmployee = loggedUser;

            if (loggedUser.RoleID == 2)
            {
                NavigationService.Navigate(new ManagerPage());
            }
            else if (loggedUser.RoleID == 3)
            {
                NavigationService.Navigate(new CallCenterPage());
            }
            else
            {
                NavigationService.Navigate(new CleaningMasterPage());
            }
        }
    }
}
