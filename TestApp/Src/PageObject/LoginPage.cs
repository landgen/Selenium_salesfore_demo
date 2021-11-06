using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace TestApp.PageObjects
{
    class LoginPage
    {
        String test_url = "https://geotix.my.salesforce.com";

        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
        private IWebElement username_input => driver.FindElement(By.Name("username"));
        private IWebElement password_input => driver.FindElement(By.Name("pw"));
        private IWebElement login_button => driver.FindElement(By.Name("Login"));

        public void goToPage()
        {
            driver.Navigate().GoToUrl(test_url);
        }

        public Dashboard test_dashboard(string login, string password)
        {
            username_input.SendKeys(login);
            password_input.SendKeys(password);
            login_button.Click();


            return new Dashboard(driver);
        }

    }
}
