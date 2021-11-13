using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestApp.Src.PageObject;

namespace TestApp.PageObjects
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
        private IWebElement account_menu => driver.FindElement(By.XPath("//a[@title='Accounts']/parent::*"));
        private IWebElement edit_button => driver.FindElement(By.XPath("/html/body/div[4]/div[1]/section/div[1]/div[2]/div[2]/div[1]/div/div/div/div[2]/div/one-record-home-flexipage2/forcegenerated-adg-rollup_component___force-generated__flexipage_-record-page___-account_-record_-page___-account___-v-i-e-w/forcegenerated-flexipage_account_record_page_account__view_js/record_flexipage-record-page-decorator/div[1]/records-record-layout-event-broker/slot/slot/flexipage-record-home-template-desktop2/div/div[1]/slot/slot/flexipage-component2/slot/records-lwc-highlights-panel/records-lwc-record-layout/forcegenerated-highlightspanel_account___012000000000000aaa___compact___view___recordlayout2/force-highlights2/div[1]/div[1]/div[3]/div/runtime_platform_actions-actions-ribbon/ul/li[2]/runtime_platform_actions-action-renderer/runtime_platform_actions-executor-page-reference/slot/slot/lightning-button/button"));
        public IWebElement GetAccountMenu()
        {

            return account_menu;

        }
        public IWebElement GetNewButton()
        {

            return new_button;
        }
        public IWebElement GetEditButton()
        {

            return edit_button;
        }
        public IWebElement GetAccountNameFromList(string name)
        {

            return driver.FindElement(By.XPath(string.Format("//a[@title='{0}']", name)));
        }
        public AccountForm OpenForm()
        {
        new_button.Click();
            
            return new AccountForm(driver);
        }
        public AccountForm EditForm()
        {
            edit_button.Click();

            return new AccountForm(driver);
        }

    }
}
