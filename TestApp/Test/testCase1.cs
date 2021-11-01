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
    //[TestFixture("chrome", "95.0.4638.54", "Windows 10")]
    //more fixtures for system environments
    [Parallelizable(ParallelScope.All)]
    class ScenarioOneTest
    {
        String username = "geotix.md-4ufz@force.com";
        String password = "Killerek86!";
        //ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        IWebDriver driver;

        [SetUp]
        public void Init()
        {/*
            String username = "user-name";
            String accesskey = "access-key";
            String gridURL = "@hub.lambdatest.com/wd/hub";
            
            DesiredCapabilities capabilities = new OpenQA.Selenium.Remote.DesiredCapabilities();

            capabilities.SetCapability("user", username);
            capabilities.SetCapability("accessKey", accesskey);
            capabilities.SetCapability("browserName", browser);
            capabilities.SetCapability("version", version);
            capabilities.SetCapability("platform", os);
            */
            //driver.Value = new RemoteWebDriver(new Uri("https://" + username + ":" + accesskey + gridURL), capabilities, TimeSpan.FromSeconds(600));

            //System.Threading.Thread.Sleep(2000);
            driver = new ChromeDriver("C:\\chromedriver");
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void LogInTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //IWebElement username_input = driver.FindElement(By.Name("username"));
            //username_input.SendKeys("geotix.md-4ufz@force.com");
            LoginPage  login_page = new LoginPage(driver);
            login_page.goToPage();
            Dashboard dashboard = login_page.test_dashboard(username, password);
            Accounts accounts = dashboard.GetAccountMenu();
            AccountForm account_form = accounts.OpenForm(); 
            

            /*IWebElement password_input = driver.FindElement(By.Name("pw"));
            password_input.SendKeys("Killerek86!");
            IWebElement login_button = driver.FindElement(By.Name("Login"));
            login_button.Click();
            */
        }
        /*
        [Test]
        public void checkTitle()
        {
            
            var title = driver.Title;
            
            Assert.AreEqual(title, "Login | Salesforce");
        }
        */
        [TearDown]
        public void closeBrowser()
        {
            //driver.Value.Quit();
            driver.Close();
        }
        //logowanie rezultatów 
    }
}