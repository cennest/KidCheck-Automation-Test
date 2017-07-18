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
        private LoginDetailsModel _adminLoginDetails;
        private LoginDetailsModel _kidCheckAdminLoginDetails;
        private SignupDetailsModel _signupDetails;
        private ChildcareOrganizationDetailsModel _childcareOrganizationDetailsModel;

        [TestInitialize]
        public void Setup()
        {
            driver = GetDriver();
            _adminLoginDetails = new LoginDetailsModel(UserRole.Administrator);
            _kidCheckAdminLoginDetails = new LoginDetailsModel(UserRole.KidCheckAdmin);
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
            var signupPage = new SignupPageModel(driver, BaseUri);
            driver.Navigate()
                .GoToUrl(Helper.AppConstant.SignUpURL);

            SignupPageModel siginin = signupPage
                /*.Load()
                 * .InitiateSignUp()
                 * .InitiateKidCheckSignUP()*/
                .WelcomePage()
                 .FillNewAccountDetailsWithEmail(_signupDetails);

            siginin.ContinueToStep2()
                .ContinueUsingSameLogin()
                .FillChildCareOrgDetails(_childcareOrganizationDetailsModel)
                .ContinueToStep3()
                .KidcheckProductSelection()
                .ContinueToStep4()
                .Continue();

            driver.Navigate().GoToUrl(Helper.AppConstant.SignInURL);

            var loginPage = new LoginPageModel(driver, BaseUri);
            HomePageModel homePage = loginPage
                /*.InitiateLogin()*/
                .FillLoginDetail(_signupDetails.Account_EmailID, _signupDetails.Account_Password)
                .SubmitLogin()
                .ClickIAgree();

            string homeElementText = homePage.HomeTabElement.Text;
            Assert.AreEqual(homeElementText, "Home");
        }

        [TestMethod]
        public void CreateNewAccountWithCustomerSetupWitUser()
        {
            var signupPage = new SignupPageModel(driver, BaseUri);
            driver.Navigate()
                .GoToUrl(Helper.AppConstant.SignUpURL);

            SignupPageModel siginin = signupPage
                .WelcomePage()
                 .FillNewAccountDetailsWithUser(_signupDetails);

            siginin.ContinueToStep2().
                ContinueUsingSameLogin()
                .FillChildCareOrgDetails(_childcareOrganizationDetailsModel)
                .ContinueToStep3()
                .KidcheckProductSelection()
                .ContinueToStep4()
                .Continue();

            driver.Navigate()
                .GoToUrl(Helper.AppConstant.SignInURL);

            var loginPage = new LoginPageModel(driver, BaseUri);

            HomePageModel homePage = loginPage
                .FillLoginDetail(_signupDetails.Account_UserName, _signupDetails.Account_Password)
                .SubmitLogin()
                .ClickIAgree();

            string homeElementText = homePage.HomeTabElement.Text;
            Assert.AreEqual(homeElementText, "Home");
        }

        [TestMethod]
        public void Login()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);

            HomePageModel homePage = loginPage.Load()
                .FillLoginDetail(_adminLoginDetails.UserName, _adminLoginDetails.Password)
                .SubmitLogin();

            string homeElementText = homePage.HomeTabElement.Text;
            Assert.AreEqual(homeElementText, "Home");
        }
    }
}
