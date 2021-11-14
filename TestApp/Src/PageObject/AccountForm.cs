using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestApp.Src.PageObject
{
    class AccountForm
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private IWebElement save_button => driver.FindElement(By.XPath("//button[@title='Save']/parent::*"));
        
        private IWebElement account_name => driver.FindElement(By.XPath("//div/label/span[text()='Account Name']/../following::input[1]"));

        private IWebElement website_input => driver.FindElement(By.XPath("//div/label/span[text()='Website']/../following::input[1]"));
        private IWebElement close_button => driver.FindElement(By.CssSelector("button[title='Close this window']"));
        public AccountForm(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
        public IWebElement GetAccountName()
        {

            return account_name;
        }
        public IWebElement GetSaveButton()
        {

            return save_button;
        }
        public IWebElement GetCloseButton()
        {

            return close_button;
        }
        public IWebElement GetWebsite()
        {

            return website_input;
        }
    }
}
