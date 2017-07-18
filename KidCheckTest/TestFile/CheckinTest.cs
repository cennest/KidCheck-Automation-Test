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
    public class CheckinTest : UITestBase
    {
        IWebDriver driver = null;
        private LoginModel loginModel;
        private TemplateModel templateModel;

        [TestInitialize]
        public void Setup()
        {
            driver = GetDriver();
            loginModel = new LoginModel(UserRole.Administrator);
            templateModel = new TemplateModel();
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

            loginPage.Load();
            TemplatePageModel templatePage = loginPage.InitiateLogin(loginModel.UserName, loginModel.Password)
                .ClickCheckinTab()
                .ClickTemplatesTab();

            int iRowCount = driver.FindElements(By.XPath("//*[@id='ctl00_ContentMain_rgList_ctl00']/tbody/tr")).Count;

            templatePage.ClickAddNewTemplate();
            templatePage.FillNewTemplateDetails(templateModel);
            templatePage.SubmitNewTemplate();
            templatePage.DragDropLocationTemplate();
            templatePage.SaveNewTemplateLocation();

            int iRowCountAfterInsert = driver.FindElements(By.XPath("//*[@id='ctl00_ContentMain_rgList_ctl00']/tbody/tr")).Count;

            bool isTemplateAdded = false;
            if (iRowCount < iRowCountAfterInsert)
            {
                isTemplateAdded = true;
            }

            Assert.IsTrue(isTemplateAdded);
        }

        #endregion
    }
}
