using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverProject.Shared
{
    public class ContactConstants
    {
        public const string enviarMensagemXPath = "/html/body/div[2]/div/div/div/div/div/div[1]/div[1]/div/div/div[2]/form/p[5]/input";
        public const string nameSpanCssSelector = ".your-name > span:nth-child(2)";
        public const string mailSpanCssSelector = ".your-email > span:nth-child(2)";
        public const string subjectSpanCssSelector = ".your-subject > span:nth-child(2)";
        public const string messageSpanCssSelector = ".your-message > span:nth-child(2)";
        public const string mensagemSucessoCssSelector = ".wpcf7-response-output";
        public const string navbarContactMenuXPath = "/html/body/div[1]/div[1]/div/div/div[2]/div[2]/nav/ul/li[4]/a/span";

    }
}
