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

namespace KidCheckTest
{
    [TestClass]
    public class LoginTest : UiTestBase
    {
        IWebDriver driver = null;
        private LoginDetailsModel _adminLoginDetails;
        private LoginDetailsModel _kidCheckAdminLoginDetails;
        private LoginDetailsModel _InvalidLoginDetails;
        private SignupDetailsModel _signuopDetailsModel;

        [TestInitialize]
        public void Setup()
        {
            driver = GetDriver();
            _adminLoginDetails = new LoginDetailsModel(UserRole.Administrator);
            _kidCheckAdminLoginDetails = new LoginDetailsModel(UserRole.KidCheckAdmin);
            _InvalidLoginDetails = new LoginDetailsModel();
            _signuopDetailsModel = new SignupDetailsModel();
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
            AccountHomePageModel homePage= loginPage.Load()/*.InitiateLogin()*/.FillLoginDetail(_adminLoginDetails.UserName, _adminLoginDetails.Password).SubmitLogin();
            string homeElementText = homePage.Account_HomeElement.Text;
            Assert.AreEqual(homeElementText, "Home");
        }

        [TestMethod]
        public void LoginWithEmailID()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);
            AccountHomePageModel homePage = loginPage.Load()/*.InitiateLogin()*/.FillLoginDetail(_kidCheckAdminLoginDetails.UserName, _kidCheckAdminLoginDetails.Password).SubmitLogin();
            string homeElementText = homePage.Account_HomeElement.Text;
            Assert.AreEqual(homeElementText, "Home");
        }

        [TestMethod]
        public void LoginWithInvalidUserName()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);
            loginPage.Load()/*.InitiateLogin()*/.FillLoginDetail(_InvalidLoginDetails.UserName, _InvalidLoginDetails.Password).SubmitLogin();
            string errorText = loginPage.Login_UserErrorPageElement.Text;
            Assert.AreEqual(errorText, "The credentials you entered are invalid. Please re-enter your username and password.");
        }

        [TestMethod]
        public void LoginWithInvalidPassword()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);
            loginPage.Load()/*.InitiateLogin()*/.FillLoginDetail(_InvalidLoginDetails.UserName, _InvalidLoginDetails.Password).SubmitLogin();
            string errorText = loginPage.Login_UserErrorPageElement.Text;
            Assert.AreEqual(errorText, "The credentials you entered are invalid. Please re-enter your username and password.");
        }

        [TestMethod]
        public void LoginWithInvalidUSerAndPassword()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);
            loginPage.Load()/*.InitiateLogin()*/.FillLoginDetail(_InvalidLoginDetails.UserName, _InvalidLoginDetails.Password).SubmitLogin();
            string errorText = loginPage.Login_UserErrorPageElement.Text;
            Assert.AreEqual(errorText, "The credentials you entered are invalid. Please re-enter your username and password.");
        }

        [TestMethod]
        public void LockedLoginAccount()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);
            var submit = loginPage.Load()/*.InitiateLogin()*/;
            for(int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                submit.FillLoginDetail("tsstlogin@gmail.com", "cennes").SubmitLogin();
            }
            Thread.Sleep(1000);
            submit.FillLoginDetail("tsstlogin@gmail.com", "cennes").SubmitLogin();
            string UserErrorText = submit.Login_UserErrorPageElement.Text;
            Assert.AreEqual(UserErrorText, "The username you are attempting to use is temporarily disabled because of too many invalid login attempts. You can attempt another login in 11 minutes.\r\nYou can contact KidCheck support at 1-855-543-2432 to have this login unlocked.");
        }

        [TestMethod]
        public void CreateNewKidCheckAccountWithEmailIdLogin()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);
            AccountHomePageModel homePage = loginPage.Load()/*.InitiateLogin()*/.ClickCreateNewKidCheckAccount().ClickNeverUsedKidCheck()
                .FillNewKidCheckAccountDetailForEmailLogin(_signuopDetailsModel).Register().IAgree();
            string homeElementText = homePage.Account_HomeElement.Text;
            Assert.AreEqual(homeElementText, "Home");
        }

        [TestMethod]
        public void CreateNewKidCheckAccountWithUsernameLogin()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);
            AccountHomePageModel homePage = loginPage.Load()/*.InitiateLogin()*/.ClickCreateNewKidCheckAccount().ClickNeverUsedKidCheck()
                .FillNewKidCheckAccountDetailForUsernameLogin(_signuopDetailsModel).Register().IAgree();
            string homeElementText = homePage.Account_HomeElement.Text;
            Assert.AreEqual(homeElementText, "Home");
        }

        [TestMethod]
        public void CreateNewKidCheckAccountWithrefOrg()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);
            AccountHomePageModel homePage = loginPage.Load()/*.InitiateLogin()*/.ClickCreateNewKidCheckAccount().ClickNeverUsedKidCheck()
                .FillNewKidCheckAccountDetailRefOrg(_signuopDetailsModel).Register().IAgree();
            string homeElementText = homePage.Account_HomeElement.Text;
            Assert.AreEqual(homeElementText, "Home");
        }
    }
}
