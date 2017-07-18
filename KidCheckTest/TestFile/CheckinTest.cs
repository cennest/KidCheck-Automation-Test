using KidCheckTest.DetailModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using KidCheckTest.PageModel;
using KidCheckTest.Helper;

namespace KidCheckTest.TestFile
{
    [TestClass]
    public class CheckinTest : UiTestBase
    {
        IWebDriver driver = null;
        private LoginDetailsModel _adminLoginDetails;
        private LoginDetailsModel _kidCheckAdminLoginDetails;
        private AddNewTemplate _addNewTemplate;
        SignupDetailsModel _newUserDetails;

        [TestInitialize]
        public void Setup()
        {
            driver = GetDriver();
            _adminLoginDetails = new LoginDetailsModel(UserRole.Administrator);
            _kidCheckAdminLoginDetails = new LoginDetailsModel(UserRole.KidCheckAdmin);
            _addNewTemplate = new AddNewTemplate();
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

        #region Templates

        [TestMethod]
        public void AddNewTemplate()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);

            CheckinPageModel addNewTemplate = loginPage.Load()
                /*.InitiateLogin()*/
                .FillLoginDetail(_adminLoginDetails.UserName, _adminLoginDetails.Password)
                .SubmitLogin()
                .ClickCheckin();
            int iRowCount = driver.FindElements(By.XPath("//*[@id='ctl00_ContentMain_rgList_ctl00']/tbody/tr")).Count;
            addNewTemplate.ClickAddNewTemplate()
                .FillNewTemplateDetails(_addNewTemplate)
                .SubmitNewTemplate()
                .DragDropLocationTemplate()
                .SaveNewTemplateLocation();
            int iRowCountAfterInsert = driver.FindElements(By.XPath("//*[@id='ctl00_ContentMain_rgList_ctl00']/tbody/tr")).Count;

            bool isTemplateAdded = false;
            if (iRowCount < iRowCountAfterInsert)
            {
                isTemplateAdded = true;
            }

            Assert.IsTrue(isTemplateAdded);
        }

        #endregion

        #region Utilities

        [TestMethod]
        public void AccountCreationViaRegistrationAssistant()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);

            CheckinPageModel test = loginPage.Load()
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

        #endregion


    }
}
