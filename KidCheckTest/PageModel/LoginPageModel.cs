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
        private IWebElement UserNameElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i0_i0_tbUsername"); }
        }

        private IWebElement PasswordElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i0_i0_tbPassword"); }
        }

        private IWebElement ForgotPasswordElement
        {
            get { return ById("btnForgetPassword"); }
        }

        private IWebElement LoginElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i0_i0_btnLogin_btnRadButton"); }
        }

        private IWebElement CreateNewAccountElement
        {
            get { return ByXPath("//*[@id='rpiRegisterPanel']/span/span[2]"); }
        }

        private IWebElement NewAccountElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_KcButton1_btnRadButton"); }
        }
        private IWebElement Account_FirstNameElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbFirstName"); }
        }
        private IWebElement Account_LastNameElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbLastName"); }
        }
        private IWebElement Account_EmailIDElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbEmail"); }
        }
        private IWebElement Account_HomePhoneElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbHomePhone"); }
        }
        private IWebElement Account_CellPhoneElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbCellPhone"); }
        }
        private IWebElement Account_CellPhoneCarrierElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_ddSMSCarrier_Arrow"); }
        }
        private IWebElement Account_CellPhoneCarrierSelectElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_pbLogin_i2_i0_ddSMSCarrier_DropDown']/div/ul/li[5]"); }
        }
        private IWebElement Account_PasswordElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbPassword1"); }
        }
        private IWebElement Account_ConfirmPasswordElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbPassword2"); }
        }
        private IWebElement Account_RefOrgValueElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_ddCustomerID_Input"); }
        }
        private IWebElement Account_RefCompanyElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_ddCustomerID_Arrow"); }
        }
        private IWebElement Account_RefCompanySelectElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_pbLogin_i2_i0_ddCustomerID_DropDown']/div/ul/li[2]"); }
        }
        private IWebElement Account_RegisterElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_btnRegister_btnRadButton"); }
        }
        private IWebElement EULA_IAgreeElement
        {
            get { return ById("ctl00_ContentMain_btnAgree_btnRadButton"); }
        }
        private IWebElement Login_IDontHaveEmailidElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_lnkNoEmail"); }
        }
        private IWebElement Login_UsernameElement
        {
            get { return ById("ctl00_ContentMain_pbLogin_i2_i0_tbUsername1"); }
        }

        public IWebElement Login_UserErrorPageElement
        {
            get { return ById("ctl00_ContentMain_ucUserMessages_lblUserMessages"); }
        }

        #endregion

        #region Methods

        private void FillLoginDetail(string username, string password)
        {
            ActionHelper.WaitUntil(Driver, UserNameElement);

            UserNameElement.Clear();
            PasswordElement.Clear();
            UserNameElement.SendKeys(username);
            PasswordElement.SendKeys(password);            
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

        public HomePageModel InitiateLogin(string username, string password)
        {
            FillLoginDetail(username, password);

            Thread.Sleep(AppConstant.SleepTime * 2);
            LoginElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new HomePageModel(Driver, BaseUri);
        }        

        public void ClickCreateNewAccount()
        {
            CreateNewAccountElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void ClickNeverUsedKidCheck()
        {
            NewAccountElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void FillNewKidCheckAccountDetails(SignupModel signuopModel, bool fillUsername, bool fillRefOrg)
        {
            Account_FirstNameElement.SendKeys(signuopModel.FirstName);
            Account_LastNameElement.SendKeys(signuopModel.Lastname);
            Account_EmailIDElement.SendKeys(signuopModel.EmailID);

            if (fillUsername)
            {
                FillUsername(signuopModel.UserName);
            }

            Account_HomePhoneElement.SendKeys(signuopModel.PhoneNumber);
            Account_CellPhoneElement.SendKeys(signuopModel.MobileNumber);
            Account_CellPhoneCarrierElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_CellPhoneCarrierSelectElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_PasswordElement.SendKeys(signuopModel.Password);
            Account_ConfirmPasswordElement.SendKeys(signuopModel.ConfirmPassword);

            if (fillRefOrg)
            {
                FillRefOrganization("cenn");
            }
        }

        public void Register()
        {
            Account_RegisterElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
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
