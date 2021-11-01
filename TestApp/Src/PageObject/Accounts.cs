using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestApp.Src.PageObject;

namespace TestApp.PageObjects.Accounts
{
    class Accounts
    {
        IWebDriver driver;
        public Accounts(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        private IWebElement new_button => driver.FindElement(By.XPath("//a[@title='New']"));
        public AccountForm OpenForm()
        {
        new_button.Click();
            
            return new AccountForm(driver);
        }

    }
}
