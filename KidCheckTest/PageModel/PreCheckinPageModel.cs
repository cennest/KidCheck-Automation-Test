using KidCheckTest.DetailModel;
using KidCheckTest.Helper;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KidCheckTest.PageModel
{
    class PreCheckinPageModel : BasePageModel
    {

        #region Page Setup
        public SignupModel signupModel;
        public PreCheckinPageModel(IWebDriver driver, Uri baseUri) : base(driver, baseUri)
        {
            signupModel = new SignupModel();
        }

        public PreCheckinPageModel Load()
        {
            Driver.Navigate().GoToUrl(GetAbsoluteUri("/"));
            return this;
        }

        #endregion

        #region

        public IWebElement HomePhoneElement
        {
            get { return ById("ctl00_ContentMain_tbHomePhone"); }
        }
        private IWebElement CellPhoneElement
        {
            get { return ById("ctl00_ContentMain_tbCellPhone"); }
        }
        private IWebElement EmailIdElement
        {
            get { return ById("ctl00_ContentMain_tbEmailAddress"); }
        }
        private IWebElement NextElement
        {
            get { return ById("ctl00_ContentMain_tdNext"); }
        }

        private IWebElement PrimaryGuardian_FirstnameElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_tbFirstName"); }
        }
        private IWebElement PrimaryGuardian_LastnameElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_tbLastName"); }
        }
        private IWebElement PrimaryGuardian_AddressElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_tbAddress"); }
        }
        private IWebElement PrimaryGuardian_CityElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_tbCity"); }
        }
        private IWebElement PrimaryGuardian_StateElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_cbStateID"); }
        }
        private IWebElement PrimaryGuardian_SelectedStateElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_cbStateID_DropDown']/div/ul/li[8]"); }
        }
        private IWebElement PrimaryGuardian_PostalCode
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_tbPostalCode"); }
        }
        private IWebElement PrimaryGuardian_CountryElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_cbCountryID"); }
        }
        private IWebElement PrimaryGuardian_SelectedCountryElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_cbCountryID_DropDown']/div/ul/li[13]"); }
        }
        private IWebElement PrimaryGuardian_HomePhoneElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_tbHomePhone"); }
        }
        private IWebElement PrimaryGuardian_EmailID
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_tbEmailAddress"); }
        }
        private IWebElement PrimaryGuardian_CellPhoneElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_tbCellPhone"); }
        }
        private IWebElement PrimaryGuardian_CellphoneCarrierElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_cbSMS_CarrierID_Arrow"); }
        }
        private IWebElement PrimaryGuardian_SelectedCellphoneCompanyElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucPrimaryGuardian_cbSMS_CarrierID_DropDown']/div/ul/li[61]"); }
        }
        private IWebElement PrimaryGuardian_UsernameElement
        {
            get { return ById("ctl00_ContentMain_tbUsername"); }
        }
        private IWebElement PrimaryGuardian_PasswordElement
        {
            get { return ById("ctl00_ContentMain_tbPassword"); }
        }
        private IWebElement PrimaryGuardian_NextElement
        {
            get { return ById("ctl00_ContentMain_lnkNext_btnRadButton"); }
        }

        #endregion

        #region Methods        
        
        public void ClickRegNext()
        {
            NextElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void PrimaryGuardianNextClick()
        {
            PrimaryGuardian_NextElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void FillRegistrationBasicInfo()
        {
            HomePhoneElement.SendKeys(signupModel.PhoneNumber);
            CellPhoneElement.SendKeys(signupModel.MobileNumber);
            EmailIdElement.SendKeys(signupModel.EmailID);
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void FillNewUserDetails(bool createLogin)
        {
            PrimaryGuardian_FirstnameElement.SendKeys(signupModel.UserName);
            PrimaryGuardian_LastnameElement.SendKeys(signupModel.Lastname);
            PrimaryGuardian_AddressElement.SendKeys(signupModel.MailingAddress);
            PrimaryGuardian_CityElement.SendKeys(signupModel.City);
            PrimaryGuardian_PostalCode.SendKeys(signupModel.PostalCode);

            Thread.Sleep(AppConstant.SleepTime * 2);
            PrimaryGuardian_StateElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            PrimaryGuardian_SelectedStateElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            PrimaryGuardian_CountryElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            PrimaryGuardian_SelectedCountryElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            PrimaryGuardian_CellphoneCarrierElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            PrimaryGuardian_SelectedCellphoneCompanyElement.Click();

            if (createLogin)
            {
                PrimaryGuardian_UsernameElement.SendKeys(signupModel.UserName);
                PrimaryGuardian_PasswordElement.SendKeys(signupModel.Password);
            }
            Thread.Sleep(AppConstant.SleepTime * 4);
        }

        public void AddChild()
        {
           
        }

        #endregion
    }
}
