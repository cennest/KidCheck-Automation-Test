using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using KidCheckTest.DetailModel;
using KidCheckTest.PageModel;
using System.Collections.Generic;

namespace KidCheckTest.TestFile
{
    [TestClass]
    public class AccountHomeTest : UiTestBase
    {
        IWebDriver driver = null;
        private LoginDetailsModel _adminLoginDetails;
        private LoginDetailsModel _kidCheckAdminLoginDetails;
        private AddNewChild _addNewChild;
        SignupDetailsModel _newUserDetails;

        [TestInitialize]
        public void Setup()
        {
            driver = GetDriver();
            _adminLoginDetails = new LoginDetailsModel(UserRole.Administrator);
            _kidCheckAdminLoginDetails = new LoginDetailsModel(UserRole.KidCheckAdmin);
            _addNewChild = new AddNewChild();
            _newUserDetails = new SignupDetailsModel();
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
        public void AddNewKid()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);

            AccountHomePageModel addNewKid = loginPage.Load()
                /*.InitiateLogin()*/
                .FillLoginDetail(_adminLoginDetails.UserName, _adminLoginDetails.Password)
                .SubmitLogin()
                .ClickMyAccount()
                .ClickKids()
                .ClickAddNewKid();

            IList<IWebElement> row = driver.FindElements(By.XPath("//*[@id='ctl00_ContentMain_dgKids']" + " / tbody/tr[*]"));

            int rowCount = row.Count;

            driver.SwitchTo()
                .Frame(0);

            addNewKid.FillNewKidDetails(_addNewChild)
                .SubmitNewKid();

            IList<IWebElement> rowAfterInsert = driver.FindElements(By.XPath("//*[@id='ctl00_ContentMain_dgKids']" + " / tbody/tr[*]"));

            int rowCountAterInsert = rowAfterInsert.Count;

            bool isKidAdded = false;
            if (rowCount < rowCountAterInsert)
            {
                isKidAdded = true;
            }

            Assert.IsTrue(isKidAdded);
        }

        [TestMethod]
        public void AccountCreationViaRegistrationAssistant()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);

            AccountHomePageModel test = loginPage.Load()
                .FillLoginDetail(_adminLoginDetails.UserName, _adminLoginDetails.Password)
                .SubmitLogin()
                .ClickCheckin()
                .ClickUtitlities()
                .ClickRegistrationAssistantStart()
                .FillRegistrationBasicInfoForNewUser(_newUserDetails, true)
                .ClickRegNext()
                .FillRegistrationInfoForNewUser()
                .ClickPrimaryGuardianNext();
        }

    }
}
