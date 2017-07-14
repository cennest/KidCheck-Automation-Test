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


        #region Home Page Elements
        public IWebElement LoginButtonElement
        {
            get { return ByLink("Login"); }
        }

        public IWebElement SignUpButtonElement
        {
            get { return ByLink("Sign Up"); }
        }
      
        #endregion

        #region Methods
        public SignupPageModel InitiateSignUp()
        {
            SignUpButtonElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new SignupPageModel(Driver, BaseUri);
        }

        public LoginPageModel InitiateLogin()
        {
            LoginButtonElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new LoginPageModel(Driver, BaseUri);
        }      

        #endregion
    }
}
