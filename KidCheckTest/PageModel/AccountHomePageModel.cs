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

        public CheckinPageModel ClickCheckin()
        {
            CheckInTabElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new CheckinPageModel(Driver, BaseUri);
        }

        #endregion
    }
}
