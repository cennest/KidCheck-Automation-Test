using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using KidCheckTest.DetailModel;
using KidCheckTest.PageModel;


namespace KidCheckTest.TestFile
{
    [TestClass]
    public class InitialSetupTest : UiTestBase
    {
        IWebDriver driver = null;
        private LoginDetailsModel _loginDetails;
        private SignupDetailsModel _signupDetails;
        private ChildcareOrganizationDetailsModel _childcareOrganizationDetailsModel;

        [TestInitialize]
        public void Setup()
        {
            driver = GetDriver();
            _loginDetails = new LoginDetailsModel(UserRole.Administrator);
            _signupDetails = new SignupDetailsModel();
            _childcareOrganizationDetailsModel = new ChildcareOrganizationDetailsModel();
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
        public void CreateNewAccountWithCustomerSetupWitEmail()
        {
            driver.Navigate()
                .GoToUrl(Helper.AppConstant.SignUpURL);

            var signupPage = new SignupPageModel(driver, BaseUri);

            SignupPageModel siginin = signupPage
                .WelcomePage()
                .FillNewAccountDetailsWithEmail(_signupDetails).ContinueToStep2()
                .ContinueUsingSameLogin()
                .FillChildCareOrgDetails(_childcareOrganizationDetailsModel)
                .ContinueToStep3()
                .KidcheckProductSelection()
                .ContinueToStep4()
                .Continue();

            driver.Navigate()
                .GoToUrl(Helper.AppConstant.SignInURL);

            var loginPage = new LoginPageModel(driver, BaseUri);
            HomePageModel homePage = loginPage
                .InitiateLogin(_signupDetails.Account_EmailID, _signupDetails.Account_Password)
                .ClickIAgree();

            Assert.AreEqual(homePage.HomeTabElement.Text, "Home");
        }

        [TestMethod]
        public void CreateNewAccountWithCustomerSetupWitUser()
        {
            driver.Navigate()
                .GoToUrl(Helper.AppConstant.SignUpURL);

            var signupPage = new SignupPageModel(driver, BaseUri);

            SignupPageModel siginin = signupPage
                .WelcomePage()
                .FillNewAccountDetailsWithUser(_signupDetails)
                .ContinueToStep2()
                .ContinueUsingSameLogin()
                .FillChildCareOrgDetails(_childcareOrganizationDetailsModel)
                .ContinueToStep3()
                .KidcheckProductSelection()
                .ContinueToStep4()
                .Continue();

            driver.Navigate()
                .GoToUrl(Helper.AppConstant.SignInURL);

            var loginPage = new LoginPageModel(driver, BaseUri);

            HomePageModel homePage = loginPage
                .InitiateLogin(_signupDetails.Account_UserName, _signupDetails.Account_Password)
                .ClickIAgree();

            Assert.AreEqual(homePage.HomeTabElement.Text, "Home");
        }

        [TestMethod]
        public void Login()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);

            HomePageModel homePage = loginPage.Load()
                .InitiateLogin(_loginDetails.UserName, _loginDetails.Password);

            Assert.AreEqual(homePage.HomeTabElement.Text, "Home");
        }
    }
}
