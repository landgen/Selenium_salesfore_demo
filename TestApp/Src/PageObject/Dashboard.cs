using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestApp.Src.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.PageObjects
{
    class Dashboard
    {
        private IWebDriver driver;

        public Dashboard(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        private IWebElement account_menu => driver.FindElement(By.XPath("//a[@title='Accounts']/parent::*"));
        public Accounts GetAccountMenu()
        {
            account_menu.Click();

            return new Accounts(driver);
            
        }
    }
}
