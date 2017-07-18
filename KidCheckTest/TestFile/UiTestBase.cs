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

        public UiTestBase()
        {
            BaseUri = GetBaseUri();
        }

        public static IWebDriver GetDriver()
        {
            IWebDriver driver = InitializeDriver("CR");
            try
            {
                driver.Manage().Window.Size = new Size(1500, 1000);
                driver.Manage().Window.Position = new Point(0, 0);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
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
            //    return new Uri(Helper.AppConstant.SignUpURL);
            //}
            //else
            //{
            return new Uri(Helper.AppConstant.SignInURL);
            //}
        }
    }
}
