using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sonic_Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Press Enter to start Execution");
            Console.ReadLine();
            Browser();
            Login();
            Arrival();
            Delivery();
            Console.WriteLine("\n   Execution Completed");
            Console.ReadLine();
        }
        public static void Browser()
        {
            Properties.Driver = new ChromeDriver();
            Properties.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            Properties.Driver.Navigate().GoToUrl("https://app.sonic.pk/admin/login");
            Properties.Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        public static void Login()
        {
            DataTable table = ExcelLib.PopulateInCollection(ConfigurationManager.AppSettings["data"]);

            SignInPageObject obj1 = new SignInPageObject();
            obj1.SignIn(ExcelLib.ReadData(1, "PhoneNum"), ExcelLib.ReadData(1,"Pin"));
        }
        public static void Arrival()
        {
            //DataBase obj4 = new DataBase();
            //obj4.Tracking_Number();
            FirstMile obj2 = new FirstMile();
            obj2.FM(ExcelLib.ReadData(1, "Weight"));
        }
        public static void Delivery()
        {
            LastMile delv = new LastMile();
            delv.LM();
        }
    }

}