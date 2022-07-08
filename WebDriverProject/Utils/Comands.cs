using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverProject.Utils
{
     class Comands
    {
        public static IWebDriver getRemoteDrivers(IWebDriver driver, string uri)
        {
            var cap_firefox = new FirefoxOptions();
            driver = new RemoteWebDriver(new Uri(uri),cap_firefox);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
