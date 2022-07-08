using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverProject.PageObject
{
    internal class Language
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div/div[2]/div[2]/nav/ul/li[7]/a/img")]
        public IWebElement languageIcon { get; set; }
    }
}
