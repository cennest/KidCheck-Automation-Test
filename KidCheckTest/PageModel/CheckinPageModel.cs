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
        public CheckinPageModel(IWebDriver driver, Uri baseUri)
           : base(driver, baseUri)
        {
        }

        public CheckinPageModel Load()
        {
            Driver.Navigate().GoToUrl(GetAbsoluteUri("/"));
            return this;
        }

        #endregion

        #region Elements

        private IWebElement UtilitiesTabElement
        {
            get { return ById("AdminConsoleTab"); }
        }
        private IWebElement IAgreeElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_btnAgree_btnRadButton']"); }
        }
        private IWebElement TemplatesTabElement
        {
            get { return ByXPath("//*[@id='TemplateTab']"); }
        }

        #endregion

        #region Methods

        public TemplatePageModel ClickTemplatesTab()
        {
            if (!TemplatesTabElement.Selected)
            {
                TemplatesTabElement.Click();
            }

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new TemplatePageModel(Driver, BaseUri);
        }

        public UtilitiesPageModel ClickUtitlitiesTab()
        {
            UtilitiesTabElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new UtilitiesPageModel(Driver, BaseUri);
        }

        #endregion
    }
}
