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
        public SignupDetailsModel regNewUserDetails;
        public PreCheckinPageModel(IWebDriver driver, Uri baseUri) : base(driver, baseUri)
        {
            regNewUserDetails = new SignupDetailsModel();
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

        public void FillRegistrationBasicInfo()
        {
            HomePhoneElement.SendKeys(regNewUserDetails.Account_PhoneNumber);
            CellPhoneElement.SendKeys(regNewUserDetails.Account_MobileNumber);
            EmailIdElement.SendKeys(regNewUserDetails.Account_EmailID);
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void ClickRegNext()
        {
            NextElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void FillNewUserDetails(bool createLogin)
        {
            PrimaryGuardian_FirstnameElement.SendKeys(regNewUserDetails.Account_UserName);
            PrimaryGuardian_LastnameElement.SendKeys(regNewUserDetails.Account_Lastname);
            PrimaryGuardian_AddressElement.SendKeys(regNewUserDetails.Account_MailingAddress);
            PrimaryGuardian_CityElement.SendKeys(regNewUserDetails.Account_City);
            PrimaryGuardian_PostalCode.SendKeys(regNewUserDetails.Account_PostalCode);

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
                PrimaryGuardian_UsernameElement.SendKeys(regNewUserDetails.Account_UserName);
                PrimaryGuardian_PasswordElement.SendKeys(regNewUserDetails.Account_Password);
            }

            Thread.Sleep(AppConstant.SleepTime * 4);
        }

        public void PrimaryGuardianNextClick()
        {
            PrimaryGuardian_NextElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }


        #endregion
    }
}
