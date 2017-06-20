using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Drawing;

namespace KidCheckTest.TestFile
{
    public class UiTestBase
    {
        protected Uri BaseUri;
        static string driverPath = AppDomain.CurrentDomain.BaseDirectory;     
        protected string uri = "https://www.kidcheck.com/";
        protected string localLoginUri = "https://localhost/signin.aspx";
        protected string localSignupUri = "https://localhost/signup/";

        public UiTestBase()
        {
            BaseUri = GetBaseUri();
        }

        public static IWebDriver GetDriver()
        {
            IWebDriver driver = InitializeDriver("CR");
            try
            {
                //driver.Manage().Window.Size = new Size(700, 700);
                driver.Manage().Window.Size = new Size(1500, 1000);
                driver.Manage().Window.Position = new Point(0, 0);
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            }
            catch (Exception)
            {
                driver.Quit();
            }
            return driver;
        }

        //the property of driver needs to chnge to copy if never
        public static IWebDriver InitializeDriver(string BrowserName)
        {
            IWebDriver driver = null;
            if (driver == null)
            {
                switch (BrowserName)
                {
                    case "IE":
                        //set the zoom level 100% in IE browser
                        //Neve hold the mouse while test is getting run
                        driver = new InternetExplorerDriver(driverPath);
                        break;
                    case "FF":
                        driver = new FirefoxDriver();
                        break;
                    case "CR":
                        ChromeOptions cromeOption = new ChromeOptions();
                        cromeOption.AddArguments("--test-type");
                        driver = new ChromeDriver(driverPath);
                        break;
                    default:
                        driver = new FirefoxDriver();
                        break;
                }
            }
            return driver;
        }

        protected Uri GetBaseUri()
        {
            //if(loginType == "login")
            //{
            //    return new Uri(localLoginUri);
            //} else if(loginType == "signup")
            //{
            //    return new Uri(localSignupUri);
            //}
            //else
            //{
                return new Uri(localLoginUri);
            //}
        }
    }
}
