using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using TestApp.PageObjects;
using TestApp.Src.PageObject;

namespace TestApp
{
    [Parallelizable(ParallelScope.All)]
    class SalesforceTest
    {
        String username = "geotix.md-4ufz@force.com";
        String password = "Killerek86!";

        IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver("C:\\chromedriver");
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void CreateAndVerifyAccount()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Accounts account_page = this.CreateAccount(); //modal dont close??
            account_page.GetAccountMenu()
                .Click();
            account_page.GetAccountNameFromList("account1");


        }
        [Test]
        public void EditAccount()
        {
            this.CreateAccount();
            
        }
        private Accounts CreateAccount()
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage login_page = new LoginPage(driver);
            login_page.goToPage();
            Dashboard dashboard = login_page.test_dashboard(username, password);
            Accounts accounts = dashboard.GetAccountMenu();
            AccountForm account_form = accounts.OpenForm();
            account_form.GetAccountName().SendKeys("account1");
            account_form.GetSaveButton().Click();
            //account_form.GetCloseButton().Click();

            return accounts;
        }
        [TearDown]
        public void CloseBrowser()
        {
          
            driver.Close();
        }
    }
}