using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using KidCheckTest.DetailModel;
using KidCheckTest.PageModel;
using System.Collections.Generic;

namespace KidCheckTest.TestFile
{
    [TestClass]
    public class AccountHomeTest : UITestBase
    {
        IWebDriver driver = null;
        private LoginDetailsModel _loginDetails;
        private AddNewChild _addNewChild;

        [TestInitialize]
        public void Setup()
        {
            driver = GetDriver();
            _loginDetails = new LoginDetailsModel(UserRole.Administrator);
            _addNewChild = new AddNewChild();
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

            MyAccountPageModel myAccountPage = loginPage.Load()
                .InitiateLogin(_loginDetails.UserName, _loginDetails.Password)
                .ClickMyAccountTab();

            myAccountPage.ClickKidsTab();
            myAccountPage.ClickAddNewKidLink();

            IList<IWebElement> row = driver.FindElements(By.XPath("//*[@id='ctl00_ContentMain_dgKids']" + " / tbody/tr[*]"));

            int initialRowCount = row.Count;
            driver.SwitchTo().Frame(0);

            myAccountPage.FillNewKidDetails(_addNewChild);
            myAccountPage.SubmitNewKid();

            IList<IWebElement> rowAfterInsert = driver.FindElements(By.XPath("//*[@id='ctl00_ContentMain_dgKids']" + " / tbody/tr[*]"));
            
            bool isKidAdded = false;
            if (initialRowCount < rowAfterInsert.Count)
            {
                isKidAdded = true;
            }

            Assert.IsTrue(isKidAdded);
        }

    }
}
