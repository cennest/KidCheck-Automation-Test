using OpenQA.Selenium;
using System;
using System.Threading;
using KidCheckTest.Helper;

namespace KidCheckTest.PageModel
{
    class HomePageModel : BasePageModel
    {
        #region Page Setup
        public HomePageModel(IWebDriver driver, Uri baseUri)
            : base(driver, baseUri)
        {
        }
        #endregion

        #region Elements

        public IWebElement IAgreeElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_btnAgree_btnRadButton']"); }
        }

        #endregion

        #region Methods

        public MyAccountPageModel ClickMyAccountTab()
        {
            MyAccountTabElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new MyAccountPageModel(Driver, BaseUri);
        }

        public CheckinPageModel ClickCheckinTab()
        {
            CheckInTabElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new CheckinPageModel(Driver, BaseUri);
        }

        public HomePageModel ClickIAgree()
        {
            IAgreeElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
            return new HomePageModel(Driver, BaseUri);
        }

        #endregion
    }
}
