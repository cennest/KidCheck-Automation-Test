using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using KidCheckTest.DetailModel;
using KidCheckTest.Helper;

namespace KidCheckTest.PageModel
{
    class LoginPageModel : BasePageModel
    {

        #region Page Setup
        public LoginPageModel(IWebDriver driver, Uri baseUri)
           : base(driver, baseUri)
        {
        }

        public LoginPageModel Load()
        {
            Driver.Navigate().GoToUrl(GetAbsoluteUri("/"));
            return this;
        }
        #endregion

        #region Login Page Elements
        public IWebElement UserNameElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i0_i0_tbUsername"); }
        }

        public IWebElement PasswordElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i0_i0_tbPassword"); }
        }

        public IWebElement ForgotPasswordElement
        {
            get { return ById("btnForgetPassword"); }
        }

        public IWebElement LoginElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i0_i0_btnLogin_btnRadButton"); }
        }

        public IWebElement CreateNewAccountElement
        {
            get { return ByXPath("//*[@id='rpiRegisterPanel']/span/span[2]"); }
        }

        public IWebElement NewAccountElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_KcButton1_btnRadButton"); }
        }
        public IWebElement Account_FirstNameElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbFirstName"); }
        }
        public IWebElement Account_LastNameElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbLastName"); }
        }
        public IWebElement Account_EmailIDElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbEmail"); }
        }
        public IWebElement Account_HomePhoneElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbHomePhone"); }
        }
        public IWebElement Account_CellPhoneElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbCellPhone"); }
        }
        public IWebElement Account_CellPhoneCarrierElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_ddSMSCarrier_Arrow"); }
        }
        public IWebElement Account_CellPhoneCarrierSelectElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_pbLogin_i2_i0_ddSMSCarrier_DropDown']/div/ul/li[5]"); }
        }
        public IWebElement Account_PasswordElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbPassword1"); }
        }
        public IWebElement Account_ConfirmPasswordElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbPassword2"); }
        }
        public IWebElement Account_RefOrgValueElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_ddCustomerID_Input"); }
        }
        public IWebElement Account_RefCompanyElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_ddCustomerID_Arrow"); }
        }
        public IWebElement Account_RefCompanySelectElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_pbLogin_i2_i0_ddCustomerID_DropDown']/div/ul/li[2]"); }
        }
        public IWebElement Account_RegisterElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_btnRegister_btnRadButton"); }
        }
        public IWebElement EULA_IAgreeElement
        {
            get { return ById("ctl00_ContentMain_btnAgree_btnRadButton"); }
        }
        public IWebElement Login_UserErrorPageElement
        {
            get { return ById("ctl00_ContentMain_ucUserMessages_lblUserMessages"); }
        }

        public IWebElement Login_IDontHaveEmailidElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_lnkNoEmail"); }
        }

        public IWebElement Login_UsernameElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbUsername1"); }
        }

        #endregion

        #region Methods

        private LoginPageModel FillLoginDetail(string username, string password)
        {
            ActionHelper.WaitUntil(Driver, UserNameElement);

            UserNameElement.Clear();
            PasswordElement.Clear();
            UserNameElement.SendKeys(username);
            PasswordElement.SendKeys(password);

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new LoginPageModel(Driver, BaseUri);
        }

        private void FillUsername(string userName)
        {
            Login_IDontHaveEmailidElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Login_UsernameElement.SendKeys(userName);
        }

        private void FillRefOrganization(string orgName)
        {
            Account_RefOrgValueElement.SendKeys(orgName);

            Thread.Sleep(2000);
            Account_RefCompanySelectElement.Click();
        }

        private HomePageModel SubmitLogin()
        {
            LoginElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
            return new HomePageModel(Driver, BaseUri);
        }

        public HomePageModel InitiateLogin(string username, string password)
        {
            return FillLoginDetail(username, password).SubmitLogin();
        }        

        public LoginPageModel ClickCreateNewAccount()
        {
            CreateNewAccountElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new LoginPageModel(Driver, BaseUri);
        }

        public LoginPageModel ClickNeverUsedKidCheck()
        {
            NewAccountElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new LoginPageModel(Driver, BaseUri);
        }

        public LoginPageModel FillNewKidCheckAccountDetails(SignupDetailsModel _signuopDetailsModel, bool fillUsername, bool fillRefOrg)
        {
            Account_FirstNameElement.SendKeys(_signuopDetailsModel.Account_FirstName);
            Account_LastNameElement.SendKeys(_signuopDetailsModel.Account_Lastname);
            Account_EmailIDElement.SendKeys(_signuopDetailsModel.Account_EmailID);

            if (fillUsername)
            {
                FillUsername(_signuopDetailsModel.Account_UserName);
            }

            Account_HomePhoneElement.SendKeys(_signuopDetailsModel.Account_PhoneNumber);
            Account_CellPhoneElement.SendKeys(_signuopDetailsModel.Account_MobileNumber);
            Account_CellPhoneCarrierElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_CellPhoneCarrierSelectElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_PasswordElement.SendKeys(_signuopDetailsModel.Account_Password);
            Account_ConfirmPasswordElement.SendKeys(_signuopDetailsModel.Account_ConfirmPassword);

            if (fillRefOrg)
            {
                FillRefOrganization("cenn");
            }

            return new LoginPageModel(Driver, BaseUri);
        }

        public LoginPageModel Register()
        {
            Account_RegisterElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new LoginPageModel(Driver, BaseUri);
        }

        public HomePageModel AcceptEULA()
        {
            EULA_IAgreeElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new HomePageModel(Driver, BaseUri);
        }
        #endregion
    }
}
