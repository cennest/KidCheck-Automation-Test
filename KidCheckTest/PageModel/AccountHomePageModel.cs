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
    class AccountHomePageModel : HomePageModel
    {
        #region Page Setup
        public SignupDetailsModel regNewUserDetails;
        public AccountHomePageModel(IWebDriver driver, Uri baseUri)
           : base(driver, baseUri)
        {
            regNewUserDetails = new SignupDetailsModel();
        }

        public AccountHomePageModel Load()
        {
            Driver.Navigate().GoToUrl(GetAbsoluteUri("/"));
            return this;
        }

        #endregion

        #region AccountHomePage Element
        public IWebElement MyAccountTabElement
        {
            get { return ByXPath("//*[@id='MyAccountTab']/span/span/span"); }
        }

        public IWebElement KidsTabElement
        {
            get { return ByXPath("//*[@id='KidsTab']/span/span"); }
        }
        public IWebElement AddNewChildElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_lnkAdd_Kids']"); }
        }
        public IWebElement Child_FirstnameElement
        {
            get { return ById("ctl00_WorkAreaPlaceholder_tbFirstName"); }
        }
        public IWebElement Child_LastnameElement
        {
            get { return ById("ctl00_WorkAreaPlaceholder_tbLastName"); }
        }
        public IWebElement Child_DOBElement
        {
            get { return ById("ctl00_WorkAreaPlaceholder_tbBirthdate_dateInput"); }
        }
        public IWebElement Child_MaleElement
        {
            get { return ByXPath("//*[@id='ctl00_WorkAreaPlaceholder_rblGender_0']"); }
        }
        public IWebElement Child_MedicalORAllergyElement
        {
            get { return ById("ctl00_WorkAreaPlaceholder_tbMedicalInfo"); }
        }
        public IWebElement Child_SubmitKidElement
        {
            get { return ById("ctl00_WorkAreaPlaceholder_lnkSave_btnRadButton"); }
        }
        public IWebElement IAgreeElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_btnAgree_btnRadButton']"); }
        }

        public IWebElement HomeTabElement
        {
            get { return ByXPath("//*[@id='homeTab']/span/span"); }
        }
        public IWebElement Account_KidBody
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_dgKids']/tbody"); }
        }
        public IWebElement GuardianTabElement
        {
            get { return ById("GuardiansTab"); }
        }
        public IWebElement AddNewGuardianElement
        {
            get { return ById("ctl00_ContentMain_lnkAdd"); }
        }
        public IWebElement CheckInTabElement
        {
            get { return ById("CheckinTab"); }
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
        #endregion

        #region Methods
        public AccountHomePageModel ClickMyAccount()
        {
            MyAccountTabElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new AccountHomePageModel(Driver, BaseUri);
        }

        public AccountHomePageModel ClickKids()
        {
            KidsTabElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new AccountHomePageModel(Driver, BaseUri);
        }

        public AccountHomePageModel ClickAddNewKid()
        {
            AddNewChildElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new AccountHomePageModel(Driver, BaseUri);
        }
        public AccountHomePageModel FillNewKidDetails(AddNewChild _addNewChild)
        {
            Child_FirstnameElement.SendKeys(_addNewChild.Child_Firstname);
            Child_LastnameElement.SendKeys(_addNewChild.Child_Lastname);
            Child_DOBElement.SendKeys(_addNewChild.Child_DOB);
            Child_MaleElement.Click();
            Child_MedicalORAllergyElement.SendKeys(_addNewChild.Child_MedicalORAllergy);
            return new AccountHomePageModel(Driver, BaseUri);
        }

        public AccountHomePageModel SubmitNewKid()
        {
            Child_SubmitKidElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new AccountHomePageModel(Driver, BaseUri);
        }

        public AccountHomePageModel ClickIAgree()
        {
            IAgreeElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
            return new AccountHomePageModel(Driver, BaseUri);
        }

        public AccountHomePageModel ClickGuardianTab()
        {
            GuardianTabElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new AccountHomePageModel(Driver, BaseUri);
        }

        public AccountHomePageModel ClickAddNewGuardian()
        {
            AddNewGuardianElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new AccountHomePageModel(Driver, BaseUri);
        }

        public AccountHomePageModel ClickCheckin()
        {
            CheckInTabElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new AccountHomePageModel(Driver, BaseUri);
        }

        public AccountHomePageModel ClickUtitlities()
        {
            UtilitiesElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new AccountHomePageModel(Driver, BaseUri);
        }

        public AccountHomePageModel ClickRegistrationAssistantStart()
        {
            RegistrationAssistantStartElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new AccountHomePageModel(Driver, BaseUri);
        }

        public AccountHomePageModel FillRegistrationBasicInfoForNewUser(SignupDetailsModel _newUserDetails)
        {
            regNewUserDetails.Account_FirstName = _newUserDetails.Account_FirstName;
            regNewUserDetails.Account_Lastname = _newUserDetails.Account_Lastname;
            regNewUserDetails.Account_PhoneNumber = _newUserDetails.Account_PhoneNumber;
            regNewUserDetails.Account_EmailID = _newUserDetails.Account_EmailID;
            regNewUserDetails.Account_MobileNumber = _newUserDetails.Account_MobileNumber;
            regNewUserDetails.Account_MailingAddress = _newUserDetails.Account_MailingAddress;
            regNewUserDetails.Account_City = _newUserDetails.Account_City;
            regNewUserDetails.Account_PostalCode = _newUserDetails.Account_PostalCode;
            regNewUserDetails.Account_UserName = _newUserDetails.Account_UserName;
            regNewUserDetails.Account_Password = _newUserDetails.Account_Password;

            Registration_HomePhoneElement.SendKeys(regNewUserDetails.Account_PhoneNumber);
            Registration_CellPhoneElement.SendKeys(regNewUserDetails.Account_MobileNumber);
            Registration_EmailIdElement.SendKeys(regNewUserDetails.Account_EmailID);

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new AccountHomePageModel(Driver, BaseUri);
        }

        public AccountHomePageModel ClickRegNext()
        {
            Registration_NextElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new AccountHomePageModel(Driver, BaseUri);
        }

        public AccountHomePageModel FillRegistrationInfoForNewUser()
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
            return new AccountHomePageModel(Driver, BaseUri);
        }

        public AccountHomePageModel ClickPrimaryGuardianNext()
        {
            PrimaryGuardian_NextElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new AccountHomePageModel(Driver, BaseUri);
        }

        #endregion
    }
}
