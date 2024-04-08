using Amirhanov_Exam.Models;
using Amirhanov_Exam.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Amirhanov_Exam
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Employees loggedEmployee = new Employees();
        public static Entities3 DB = new Entities3();
    }
}
