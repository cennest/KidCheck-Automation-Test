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

            MyAccountPageModel addNewKid = loginPage.Load()
                .InitiateLogin(_loginDetails.UserName, _loginDetails.Password)
                .ClickMyAccountTab()
                .ClickKidsTab()
                .ClickAddNewKidLink();

            IList<IWebElement> row = driver.FindElements(By.XPath("//*[@id='ctl00_ContentMain_dgKids']" + " / tbody/tr[*]"));

            int initialRowCount = row.Count;

            driver.SwitchTo()
                .Frame(0);

            addNewKid.FillNewKidDetails(_addNewChild)
                .SubmitNewKid();

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
