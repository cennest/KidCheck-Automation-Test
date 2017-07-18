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
    class UtilitiesPageModel : BasePageModel
    {
        #region Page Setup
        public SignupModel regNewUserDetails;
        public UtilitiesPageModel(IWebDriver driver, Uri baseUri) : base(driver, baseUri)
        {
            regNewUserDetails = new SignupModel();
        }

        public UtilitiesPageModel Load()
        {
            Driver.Navigate().GoToUrl(GetAbsoluteUri("/"));
            return this;
        }
        #endregion

        #region
        public IWebElement RegistrationAssistantStartElement
        {
            get { return ById("ctl00_ContentMain_btnPreCheckin_btnRadButton"); }
        }
        #endregion

        #region Methods

        public PreCheckinPageModel ClickRegistrationAssistantStartButton()
        {
            RegistrationAssistantStartElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new PreCheckinPageModel(Driver, BaseUri);
        }

        #endregion
    }
}
