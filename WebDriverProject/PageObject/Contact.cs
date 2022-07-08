using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WebDriverProject.Shared;

namespace WebDriverProject.PageObject
{
    internal class Contact
    {
        [FindsBy(How = How.Name, Using = "your-name")]
        public IWebElement name { get; set; }

        [FindsBy(How = How.Name, Using = "your-email")]
        public IWebElement mail { get; set; }

        [FindsBy(How = How.Name, Using = "your-subject")]
        public IWebElement subject { get; set; }

        [FindsBy(How = How.Name, Using = "your-message")]
        public IWebElement message { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div/div/div/div[1]/div[1]/div/div/div[2]/form/p[5]/input")]
        public IWebElement enviarMensagem { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".wpcf7-response-output")]
        public IWebElement messageResponse { get; set; }

        [FindsBy(How = How.CssSelector, Using = ContactConstants.nameSpanCssSelector)]
        public IWebElement nameSpanCssSelector { get; set; }

        [FindsBy(How = How.CssSelector, Using = ContactConstants.mailSpanCssSelector)]
        public IWebElement mailSpanCssSelector { get; set; }

        [FindsBy(How = How.CssSelector, Using = ContactConstants.subjectSpanCssSelector)]
        public IWebElement subjectSpanCssSelector { get; set; }

        [FindsBy(How = How.CssSelector, Using = ContactConstants.messageSpanCssSelector)]
        public IWebElement messageSpanCssSelector { get; set; }

        public void sendMessageClick()
        {
            enviarMensagem.Click();
            //Aguarda resposta
            //Thread.Sleep(5000);

        }
    }
}
