using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Src.PageObject
{
    class AccountForm
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public AccountForm(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
    }
}
