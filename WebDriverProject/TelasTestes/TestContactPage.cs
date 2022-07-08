using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverProject.PageObject;
using WebDriverProject.Shared;
using WebDriverProject.Utils;

namespace WebDriverProject.TelasTestes
{
    [TestFixture]
    internal class TestContactPage
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private Contact contactPageObject;
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
            driver.FindElement(By.XPath(ContactConstants.navbarContactMenuXPath)).Click();
            contactPageObject= new Contact();
            PageFactory.InitElements(driver, contactPageObject);

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
        public void ValidarLayoutTelaTest()
        {
            // Valida o layout da tela
            Assert.AreEqual("Envie uma mensagem", driver.FindElement(By.CssSelector("h1")).Text);
            Assert.IsTrue(contactPageObject.name.Enabled);
            Assert.IsTrue(contactPageObject.mail.Enabled);
            Assert.IsTrue(contactPageObject.subject.Enabled);
            Assert.IsTrue(contactPageObject.message.Enabled);
            Assert.IsTrue(contactPageObject.enviarMensagem.Enabled);


        }
        [Test]
        public void ValidarCamposVaziosErro()
        {
            // Clicar em enviar mensagem
            contactPageObject.sendMessageClick();
            // Valida erros
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(ContactConstants.nameSpanCssSelector)));
            Assert.AreEqual("O campo é obrigatório.", contactPageObject.nameSpanCssSelector.Text);
            Assert.AreEqual("O campo é obrigatório.", contactPageObject.mailSpanCssSelector.Text);
            Assert.AreEqual("O campo é obrigatório.", contactPageObject.subjectSpanCssSelector.Text);
            Assert.AreEqual("O campo é obrigatório.", contactPageObject.messageSpanCssSelector.Text);

        }
        [Test]
        public void ValidarMensagem()
        {
            
            // preencher campos
            contactPageObject.name.Clear();
            contactPageObject.mail.Clear();
            contactPageObject.subject.Clear();
            contactPageObject.message.Clear();
            contactPageObject.name.SendKeys(ConfigurationManager.AppSettings["name"]);
            contactPageObject.mail.SendKeys(ConfigurationManager.AppSettings["mail"]);
            contactPageObject.subject.SendKeys(ConfigurationManager.AppSettings["subject"]);
            contactPageObject.message.SendKeys(ConfigurationManager.AppSettings["message"]);

            // Clicar em enviar mensagem
            contactPageObject.sendMessageClick();

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(ContactConstants.mensagemSucessoCssSelector)));
            //wait.Until(ExpectedConditions.(By.(contactPageObject.messageResponse.)));
            Assert.AreEqual("Agradecemos a sua mensagem. Responderemos em breve.", contactPageObject.messageResponse.Text);
        }
        



    }
}

