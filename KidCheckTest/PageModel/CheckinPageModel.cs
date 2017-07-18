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
    class CheckinPageModel :HomePageModel
    {
        #region Page Setup
        public SignupDetailsModel regNewUserDetails;
        public CheckinPageModel(IWebDriver driver, Uri baseUri)
           : base(driver, baseUri)
        {
            regNewUserDetails = new SignupDetailsModel();
        }

        public CheckinPageModel Load()
        {
            Driver.Navigate().GoToUrl(GetAbsoluteUri("/"));
            return this;
        }
        #endregion

        #region CheckinPage Elements
        
        public IWebElement AddNewTemplateElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_lnkAddNewTemplate']"); }
        }
        public IWebElement UtilitiesElement
        {
            get { return ById("AdminConsoleTab"); }
        }
        public IWebElement RegistrationAssistantStartElement
        {
            get { return ById("ctl00_ContentMain_btnPreCheckin_btnRadButton"); }
        }
        public IWebElement Registration_HomePhoneElement
        {
            get { return ById("ctl00_ContentMain_tbHomePhone"); }
        }
        public IWebElement Registration_CellPhoneElement
        {
            get { return ById("ctl00_ContentMain_tbCellPhone"); }
        }
        public IWebElement Registration_EmailIdElement
        {
            get { return ById("ctl00_ContentMain_tbEmailAddress"); }
        }
        public IWebElement Registration_NextElement
        {
            get { return ById("ctl00_ContentMain_tdNext"); }
        }
        public IWebElement PrimaryGuardian_FirstnameElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_tbFirstName"); }
        }
        public IWebElement PrimaryGuardian_LastnameElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_tbLastName"); }
        }
        public IWebElement PrimaryGuardian_AddressElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_tbAddress"); }
        }
        public IWebElement PrimaryGuardian_CityElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_tbCity"); }
        }
        public IWebElement PrimaryGuardian_StateElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_cbStateID"); }
        }
        public IWebElement PrimaryGuardian_SelectedStateElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_cbStateID_DropDown']/div/ul/li[8]"); }
        }
        public IWebElement PrimaryGuardian_PostalCode
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_tbPostalCode"); }
        }
        public IWebElement PrimaryGuardian_CountryElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_cbCountryID"); }
        }
        public IWebElement PrimaryGuardian_SelectedCountryElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucPrimaryGuardian_ucPersonAddress_cbCountryID_DropDown']/div/ul/li[13]"); }
        }
        public IWebElement PrimaryGuardian_HomePhoneElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_tbHomePhone"); }
        }
        public IWebElement PrimaryGuardian_EmailID
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_tbEmailAddress"); }
        }
        public IWebElement PrimaryGuardian_CellPhoneElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_tbCellPhone"); }
        }
        public IWebElement PrimaryGuardian_CellphoneCarrierElement
        {
            get { return ById("ctl00_ContentMain_ucPrimaryGuardian_cbSMS_CarrierID_Arrow"); }
        }
        public IWebElement PrimaryGuardian_SelectedCellphoneCompanyElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucPrimaryGuardian_cbSMS_CarrierID_DropDown']/div/ul/li[61]"); }
        }
        public IWebElement PrimaryGuardian_UsernameElement
        {
            get { return ById("ctl00_ContentMain_tbUsername"); }
        }
        public IWebElement PrimaryGuardian_PasswordElement
        {
            get { return ById("ctl00_ContentMain_tbPassword"); }
        }
        public IWebElement PrimaryGuardian_NextElement
        {
            get { return ById("ctl00_ContentMain_lnkNext_btnRadButton"); }
        }
        public IWebElement TemplateNameElement
        {
            get { return ById("ctl00_ContentMain_tbName"); }
        }
        public IWebElement TemplateDescriptionElement
        {
            get { return ById("ctl00_ContentMain_tbDescription"); }
        }
        public IWebElement CampusDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ddCheckinSiteID"); }
        }
        public IWebElement CampusSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ddCheckinSiteID_DropDown']/div/ul/li[1]"); }
        }
        public IWebElement SubmitTemplateElement
        {
            get { return ById("ctl00_ContentMain_btnSaveItem_btnRadButton"); }
        }
        public IWebElement LocationElement
        {
            get { return ById("ctl00_ContentMain_ucChildSelector_rgAvailableLocations_ctl00__0"); }
        }

        public IWebElement SelectedLocationElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucChildSelector_rgSelectedLocations_ctl00']/tbody"); }
        }
        public IWebElement SaveTemplateLocationElement
        {
            get { return ById("ctl00_ContentMain_btnSave_View_btnRadButton"); }
        }
        #endregion

        #region Methods

        public CheckinPageModel ClickUtitlities()
        {
            UtilitiesElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new CheckinPageModel(Driver, BaseUri);
        }

        public CheckinPageModel ClickRegistrationAssistantStart()
        {
            RegistrationAssistantStartElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new CheckinPageModel(Driver, BaseUri);
        }

        public CheckinPageModel FillRegistrationBasicInfoForNewUser(SignupDetailsModel _newUserDetails, bool includeLogin)
        {
            regNewUserDetails.Account_FirstName = _newUserDetails.Account_FirstName;
            regNewUserDetails.Account_Lastname = _newUserDetails.Account_Lastname;
            regNewUserDetails.Account_PhoneNumber = _newUserDetails.Account_PhoneNumber;
            regNewUserDetails.Account_EmailID = _newUserDetails.Account_EmailID;
            regNewUserDetails.Account_MobileNumber = _newUserDetails.Account_MobileNumber;
            regNewUserDetails.Account_MailingAddress = _newUserDetails.Account_MailingAddress;
            regNewUserDetails.Account_City = _newUserDetails.Account_City;
            regNewUserDetails.Account_PostalCode = _newUserDetails.Account_PostalCode;

            if (includeLogin)
            {
                regNewUserDetails.Account_UserName = _newUserDetails.Account_UserName;
                regNewUserDetails.Account_Password = _newUserDetails.Account_Password;
            }

            Registration_HomePhoneElement.SendKeys(regNewUserDetails.Account_PhoneNumber);
            Registration_CellPhoneElement.SendKeys(regNewUserDetails.Account_MobileNumber);
            Registration_EmailIdElement.SendKeys(regNewUserDetails.Account_EmailID);

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new CheckinPageModel(Driver, BaseUri);
        }

        public CheckinPageModel ClickRegNext()
        {
            Registration_NextElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new CheckinPageModel(Driver, BaseUri);
        }

        public CheckinPageModel FillRegistrationInfoForNewUser()
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

            PrimaryGuardian_UsernameElement.SendKeys(regNewUserDetails.Account_UserName);
            PrimaryGuardian_PasswordElement.SendKeys(regNewUserDetails.Account_Password);

            Thread.Sleep(AppConstant.SleepTime * 4);
            return new CheckinPageModel(Driver, BaseUri);
        }

        public CheckinPageModel ClickPrimaryGuardianNext()
        {
            PrimaryGuardian_NextElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new CheckinPageModel(Driver, BaseUri);
        }

        public CheckinPageModel ClickAddNewTemplate()
        {
            AddNewTemplateElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new CheckinPageModel(Driver, BaseUri);
        }

        public CheckinPageModel FillNewTemplateDetails(AddNewTemplate _addNewTemplate)
        {
            TemplateNameElement.SendKeys(_addNewTemplate.TemplateName);
            TemplateDescriptionElement.SendKeys(_addNewTemplate.Description);
            CampusDropDownElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
            CampusSelectedDropDownElement.Click();
            return new CheckinPageModel(Driver, BaseUri);
        }

        public CheckinPageModel SubmitNewTemplate()
        {
            SubmitTemplateElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new CheckinPageModel(Driver, BaseUri);
        }

        public CheckinPageModel DragDropLocationTemplate()
        {
            ActionHelper.DragDrop(Driver, LocationElement, SelectedLocationElement);

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new CheckinPageModel(Driver, BaseUri);
        }
        public CheckinPageModel SaveNewTemplateLocation()
        {
            SaveTemplateLocationElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new CheckinPageModel(Driver, BaseUri);
        }




        #endregion
    }
}
