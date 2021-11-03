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
    class ScenarioOneTest
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
        public void LogInTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage  login_page = new LoginPage(driver);
            login_page.goToPage();
            Dashboard dashboard = login_page.test_dashboard(username, password);
            Accounts accounts = dashboard.GetAccountMenu();
            AccountForm account_form = accounts.OpenForm();
            account_form.GetAccountName().SendKeys("account1");
            account_form.GetSaveButton().Click();
        }

        [TearDown]
        public void closeBrowser()
        {
          
            driver.Close();
        }
    }
}