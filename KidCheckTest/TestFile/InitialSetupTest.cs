using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using KidCheckTest.DetailModel;
using KidCheckTest.PageModel;


namespace KidCheckTest.TestFile
{
    [TestClass]
    public class InitialSetupTest : UITestBase
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

        #region SignUp

        [TestMethod]
        public void CreateNewAccountWithCustomerSetupWitEmail()
        {
            driver.Navigate()
                .GoToUrl(Helper.AppConstant.SignUpURL);

            var signupPage = new SignupPageModel(driver, BaseUri);

            signupPage.ClickReadyToGo();
            signupPage.FillNewAccountDetails(_signupDetails, false);
            signupPage.ContinueToStep2();
            signupPage.ContinueUsingSameLogin();
            signupPage.FillChildCareOrgDetails(_childcareOrganizationDetailsModel);
            signupPage.ContinueToStep3();
            signupPage.KidcheckProductSelection();
            signupPage.ContinueToStep4();
            signupPage.SubmitDetails();

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

            signupPage.ClickReadyToGo();
            signupPage.FillNewAccountDetails(_signupDetails, true);
            signupPage.ContinueToStep2();
            signupPage.ContinueUsingSameLogin();
            signupPage.FillChildCareOrgDetails(_childcareOrganizationDetailsModel);
            signupPage.ContinueToStep3();
            signupPage.KidcheckProductSelection();
            signupPage.ContinueToStep4();
            signupPage.SubmitDetails();

            driver.Navigate()
                .GoToUrl(Helper.AppConstant.SignInURL);

            var loginPage = new LoginPageModel(driver, BaseUri);

            HomePageModel homePage = loginPage
                .InitiateLogin(_signupDetails.Account_UserName, _signupDetails.Account_Password)
                .ClickIAgree();

            Assert.AreEqual(homePage.HomeTabElement.Text, "Home");
        }

        #endregion


        [TestMethod]
        public void CreateNewKidCheckAccountWithEmailIdLogin()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);

            loginPage.Load()
                .ClickCreateNewAccount();
            loginPage.ClickNeverUsedKidCheck();
            loginPage.FillNewKidCheckAccountDetails(_signupDetails, false, false);
            loginPage.Register();

            HomePageModel homePage = loginPage.AcceptEULA();

            Assert.AreEqual(homePage.HomeTabElement.Text, "Home");
        }

        [TestMethod]
        public void CreateNewKidCheckAccountWithUsernameLogin()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);

            loginPage.Load()
               .ClickCreateNewAccount();
            loginPage.ClickNeverUsedKidCheck();
            loginPage.FillNewKidCheckAccountDetails(_signupDetails, true, false);
            loginPage.Register();

            HomePageModel homePage = loginPage.AcceptEULA();

            Assert.AreEqual(homePage.HomeTabElement.Text, "Home");
        }

        [TestMethod]
        public void CreateNewKidCheckAccountWithrefOrg()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);

            loginPage.Load()
                .ClickCreateNewAccount();
            loginPage.ClickNeverUsedKidCheck();
            loginPage.FillNewKidCheckAccountDetails(_signupDetails, false, true);
            loginPage.Register();

            HomePageModel homePage = loginPage.AcceptEULA();

            Assert.AreEqual(homePage.HomeTabElement.Text, "Home");
        }

        [TestMethod]
        public void AccountCreationViaRegistrationAssistant()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);

            PreCheckinPageModel preCheckinPage = loginPage.Load()
                .InitiateLogin(_loginDetails.UserName, _loginDetails.Password)
                .ClickCheckinTab()
                .ClickUtitlitiesTab()
                .ClickRegistrationAssistantStartButton();

            preCheckinPage.FillRegistrationBasicInfo();
            preCheckinPage.ClickRegNext();
            preCheckinPage.FillNewUserDetails(false);
            preCheckinPage.PrimaryGuardianNextClick();
        }
    }
}
