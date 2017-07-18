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
    class CheckinPageModel : BasePageModel
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

        #region Methods

        public UtilitiesPageModel ClickUtitlitiesTab()
        {
            UtilitiesTabElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new UtilitiesPageModel(Driver, BaseUri);
        }

        #endregion
    }
}
