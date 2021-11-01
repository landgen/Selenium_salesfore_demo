using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
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

        public IWebElement GetAccountMenu()
        {
     
             IWebElement account_menu = driver.FindElement(By.XPath("//a[@title='Accounts']/parent::*"));
            
            return account_menu;
            
        }
    }
}
