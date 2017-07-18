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
    class MyAccountPageModel : BasePageModel
    {
        #region Page Setup
        public SignupDetailsModel regNewUserDetails;
        public MyAccountPageModel(IWebDriver driver, Uri baseUri)
           : base(driver, baseUri)
        {
            regNewUserDetails = new SignupDetailsModel();
        }

        public MyAccountPageModel Load()
        {
            Driver.Navigate().GoToUrl(GetAbsoluteUri("/"));
            return this;
        }

        #endregion

        #region AccountHomePage Element
        
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
        public IWebElement Account_KidBody
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_dgKids']/tbody"); }
        }
        public IWebElement AddNewGuardianElement
        {
            get { return ById("ctl00_ContentMain_lnkAdd"); }
        }
        #endregion

        #region Methods
        

        public MyAccountPageModel ClickKidsTab()
        {
            KidsTabElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new MyAccountPageModel(Driver, BaseUri);
        }

        public MyAccountPageModel ClickAddNewKidLink()
        {
            AddNewChildElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new MyAccountPageModel(Driver, BaseUri);
        }

        public MyAccountPageModel FillNewKidDetails(AddNewChild _addNewChild)
        {
            Child_FirstnameElement.SendKeys(_addNewChild.Child_Firstname);
            Child_LastnameElement.SendKeys(_addNewChild.Child_Lastname);
            Child_DOBElement.SendKeys(_addNewChild.Child_DOB);
            Child_MaleElement.Click();
            Child_MedicalORAllergyElement.SendKeys(_addNewChild.Child_MedicalORAllergy);
            return new MyAccountPageModel(Driver, BaseUri);
        }

        public MyAccountPageModel SubmitNewKid()
        {
            Child_SubmitKidElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new MyAccountPageModel(Driver, BaseUri);
        }

        public MyAccountPageModel ClickGuardianTab()
        {
            GuardianTabElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new MyAccountPageModel(Driver, BaseUri);
        }

        public MyAccountPageModel ClickAddNewGuardianLink()
        {
            AddNewGuardianElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new MyAccountPageModel(Driver, BaseUri);
        }        
        
        #endregion
    }
}
