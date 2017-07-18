using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System.Linq;
using KidCheckTest.DetailModel;
using KidCheckTest.TestFile;
using KidCheckTest.PageModel;
using KidCheckTest.Helper;

namespace KidCheckTest
{
    [TestClass]
    public class LoginTest : UITestBase
    {
        IWebDriver driver = null;
        private LoginModel loginModel;
        private LoginModel invalidLoginModel;

        [TestInitialize]
        public void Setup()
        {
            driver = GetDriver();
            loginModel = new LoginModel(UserRole.Administrator);
            invalidLoginModel = new LoginModel();
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void LoginWithUserName()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);
            HomePageModel homePage = loginPage.Load()
                .InitiateLogin(loginModel.UserName, loginModel.Password);

            string homeElementText = homePage.HomeTabElement.Text;
            Assert.AreEqual(homeElementText, "Home");
        }

        [TestMethod]
        public void LoginWithEmailID()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);
            HomePageModel homePage = loginPage.Load()
                .InitiateLogin(loginModel.UserName, loginModel.Password);
            
            Assert.AreEqual(homePage.HomeTabElement.Text, "Home");
        }

        [TestMethod]
        public void LoginWithInvalidUserName()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);
            loginPage.Load()
                .InitiateLogin(loginModel.UserName, loginModel.Password);
            
            Assert.AreEqual(loginPage.Login_UserErrorPageElement.Text, "The credentials you entered are invalid. Please re-enter your username and password.");
        }

        [TestMethod]
        public void LoginWithInvalidPassword()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);
            loginPage.Load()
                .InitiateLogin(invalidLoginModel.UserName, invalidLoginModel.Password);
            
            Assert.AreEqual(loginPage.Login_UserErrorPageElement.Text, "The credentials you entered are invalid. Please re-enter your username and password.");
        }

        [TestMethod]
        public void LoginWithInvalidUSerAndPassword()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);
            loginPage.Load()
                .InitiateLogin(invalidLoginModel.UserName, invalidLoginModel.Password);
            
            Assert.AreEqual(loginPage.Login_UserErrorPageElement.Text, "The credentials you entered are invalid. Please re-enter your username and password.");
        }

        [TestMethod]
        public void LockedLoginAccount()
        {
            var loginPage = new LoginPageModel(driver, BaseUri).Load();

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(AppConstant.SleepTime * 2);
                loginPage.InitiateLogin("tsstlogin@gmail.com", "cennes");
            }

            Thread.Sleep(AppConstant.SleepTime * 2);
            loginPage.InitiateLogin("tsstlogin@gmail.com", "cennes");
            
            Assert.AreEqual(loginPage.Login_UserErrorPageElement.Text, "The username you are attempting to use is temporarily disabled because of too many invalid login attempts. You can attempt another login in 11 minutes.\r\nYou can contact KidCheck support at 1-855-543-2432 to have this login unlocked.");
        }        
    }
}
