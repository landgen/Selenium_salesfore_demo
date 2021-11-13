using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using TestApp.PageObjects;
using TestApp.Src.PageObject;

namespace TestApp
{
    [Parallelizable(ParallelScope.All)]
    class SalesforceTest
    {
        String username = "kontakt-rme6@force.com";
        String password = "Killerek86!";
        private static Random random = new Random();
        String account_name = "account_" + RandomString(2);
        String website = "website_" + RandomString(2);

        IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver("C:\\chromedriver");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [Test]
        public void CreateAndVerifyAccount()
        {
            Accounts account_page = this.CreateAccount(account_name);
            driver.FindElement(By.XPath(string.Format("//span[.='{0}']", account_name)));
        }
        [Test]
        public void EditAccount()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Accounts account_page = this.CreateAccount(account_name);
            AccountForm account_form = account_page.EditForm();
            account_form.GetWebsite().SendKeys(website);
            account_form.GetSaveButton().Click();
            driver.FindElement(By.XPath(string.Format("//span[.='{0}']", website)));

        }
        private Accounts CreateAccount(string name)
        {
            LoginPage login_page = new LoginPage(driver);
            login_page.goToPage();
            Dashboard dashboard = login_page.test_dashboard(username, password);
            Accounts accounts = dashboard.GetAccountMenu();
            AccountForm account_form = accounts.OpenForm();
            account_form.GetAccountName().SendKeys(name);
            account_form.GetSaveButton().Click();

            return accounts;
        }
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        [TearDown]
        public void CloseBrowser()
        {

            driver.Close();
        }
    }
}