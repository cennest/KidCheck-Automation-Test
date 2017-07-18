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
        public MyAccountPageModel(IWebDriver driver, Uri baseUri)
           : base(driver, baseUri)
        {
        }

        public MyAccountPageModel Load()
        {
            Driver.Navigate().GoToUrl(GetAbsoluteUri("/"));
            return this;
        }

        #endregion

        #region AccountHomePage Element

        private IWebElement AddNewChildElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_lnkAdd_Kids']"); }
        }
        private IWebElement Child_FirstnameElement
        {
            get { return ById("ctl00_WorkAreaPlaceholder_tbFirstName"); }
        }
        private IWebElement Child_LastnameElement
        {
            get { return ById("ctl00_WorkAreaPlaceholder_tbLastName"); }
        }
        private IWebElement Child_DOBElement
        {
            get { return ById("ctl00_WorkAreaPlaceholder_tbBirthdate_dateInput"); }
        }
        private IWebElement Child_MaleElement
        {
            get { return ByXPath("//*[@id='ctl00_WorkAreaPlaceholder_rblGender_0']"); }
        }
        private IWebElement Child_MedicalORAllergyElement
        {
            get { return ById("ctl00_WorkAreaPlaceholder_tbMedicalInfo"); }
        }
        private IWebElement Child_SubmitKidElement
        {
            get { return ById("ctl00_WorkAreaPlaceholder_lnkSave_btnRadButton"); }
        }
        private IWebElement Account_KidBody
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_dgKids']/tbody"); }
        }
        private IWebElement AddNewGuardianElement
        {
            get { return ById("ctl00_ContentMain_lnkAdd"); }
        }
        #endregion

        #region Methods


        public void ClickKidsTab()
        {
            KidsTabElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void ClickAddNewKidLink()
        {
            AddNewChildElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void FillNewKidDetails(ChildModel child)
        {
            Child_FirstnameElement.SendKeys(child.Firstname);
            Child_LastnameElement.SendKeys(child.Lastname);
            Child_DOBElement.SendKeys(child.DateOfBirth);
            Child_MaleElement.Click();
            Child_MedicalORAllergyElement.SendKeys(child.MedicalAllergy);
        }

        public void SubmitNewKid()
        {
            Child_SubmitKidElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void ClickGuardianTab()
        {
            GuardianTabElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void ClickAddNewGuardianLink()
        {
            AddNewGuardianElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        #endregion
    }
}
