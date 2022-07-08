using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverProject.PageObject;
using WebDriverProject.Shared;

namespace WebDriverProject.TelasTestes
{
    [TestFixture]
    internal class TestHomePage
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private Contact contactPageObject;
        private Language languagetPageObject;
        private WebDriverWait wait;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            //Remote
            //driver = Comands.getRemoteDrivers(driver, "http://192.168.56.1:5555/wd/hub");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            baseURL = "https://livros.inoveteste.com.br/";
            verificationErrors = new StringBuilder();
            // Acessa o site
            driver.Navigate().GoToUrl(baseURL + "/");
            // Acessa o menu Contato
            Thread.Sleep(5000);
            
            contactPageObject = new Contact();
            languagetPageObject = new Language();
            PageFactory.InitElements(driver, contactPageObject);
            PageFactory.InitElements(driver, languagetPageObject);

        }
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void validarTrocaDelinguagem()
        {
            var action = new Actions(driver);
            action.MoveToElement(languagetPageObject.languageIcon).Perform();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[1]/div/div/div[2]/div[2]/nav/ul/li[7]/ul/li[1]/a/img")));
            driver.FindElement(By.CssSelector("#sidr-navigation-container > nav:nth-child(2) > ul:nth-child(1) > li:nth-child(7) > ul:nth-child(2) > li:nth-child(1) > a:nth-child(1) > img:nth-child(1)")).Click();
            Thread.Sleep(5000);
            var contact = driver.FindElement(By.XPath(ContactConstants.navbarContactMenuXPath));
            Assert.AreEqual("Contact", contact.Text);
        }
    }
}
