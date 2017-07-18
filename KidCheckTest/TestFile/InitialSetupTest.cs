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
        private LoginModel loginModel;
        private SignupModel signupModel;
        private OrganizationModel organizationModel;

        [TestInitialize]
        public void Setup()
        {
            driver = GetDriver();
            loginModel = new LoginModel(UserRole.Administrator);
            signupModel = new SignupModel();
            organizationModel = new OrganizationModel();
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
            signupPage.FillNewAccountDetails(signupModel, false);
            signupPage.ContinueToStep2();
            signupPage.ContinueUsingSameLogin();
            signupPage.FillChildCareOrgDetails(organizationModel);
            signupPage.ContinueToStep3();
            signupPage.KidcheckProductSelection();
            signupPage.ContinueToStep4();
            signupPage.SubmitDetails();

            driver.Navigate()
                .GoToUrl(BaseUri);

            var loginPage = new LoginPageModel(driver, BaseUri);
            HomePageModel homePage = loginPage
                .InitiateLogin(signupModel.EmailID, signupModel.Password)
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
            signupPage.FillNewAccountDetails(signupModel, true);
            signupPage.ContinueToStep2();
            signupPage.ContinueUsingSameLogin();
            signupPage.FillChildCareOrgDetails(organizationModel);
            signupPage.ContinueToStep3();
            signupPage.KidcheckProductSelection();
            signupPage.ContinueToStep4();
            signupPage.SubmitDetails();

            driver.Navigate()
                .GoToUrl(BaseUri);

            var loginPage = new LoginPageModel(driver, BaseUri);

            HomePageModel homePage = loginPage
                .InitiateLogin(signupModel.UserName, signupModel.Password)
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
            loginPage.FillNewKidCheckAccountDetails(signupModel, false, false);
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
            loginPage.FillNewKidCheckAccountDetails(signupModel, true, false);
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
            loginPage.FillNewKidCheckAccountDetails(signupModel, false, true);
            loginPage.Register();

            HomePageModel homePage = loginPage.AcceptEULA();

            Assert.AreEqual(homePage.HomeTabElement.Text, "Home");
        }

        [TestMethod]
        public void AccountCreationViaRegistrationAssistant()
        {
            var loginPage = new LoginPageModel(driver, BaseUri);

            PreCheckinPageModel preCheckinPage = loginPage.Load()
                .InitiateLogin(loginModel.UserName, loginModel.Password)
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
