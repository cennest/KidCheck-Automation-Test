using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using KidCheckTest.DetailModel;
using KidCheckTest.Helper;
using OpenQA.Selenium.Support.UI;

namespace KidCheckTest.PageModel
{
    class SignupPageModel : BasePageModel
    {

        #region Page Setup
        public SignupPageModel(IWebDriver driver, Uri baseUri)
           : base(driver, baseUri)
        {
        }

        public SignupPageModel Load()
        {
            Driver.Navigate().GoToUrl(GetAbsoluteUri("/"));
            return this;
        }
        #endregion

        #region SignUp Elements
        private IWebElement SignUpKidCheckElement
        {
            get { return ByClass("signup-green"); }
        }

        private IWebElement WelcomeElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucWelcome_btnGoToStep1_btnRadButton']"); }
        }

        private IWebElement Account_FirstNameElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbFirstName"); }
        }

        private IWebElement Account_LastnameElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbLastName"); }
        }

        private IWebElement Account_EmailIDElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbEmail"); }
        }

        private IWebElement Account_PasswordElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbPassword1"); }
        }

        private IWebElement Account_ConfirmPasswordElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbPassword2"); }
        }

        private IWebElement Account_PhoneNumberElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbHomePhone"); }
        }

        private IWebElement Account_MobileNumberElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbCellPhone"); }
        }

        private IWebElement ContinueToStep2Element
        {
            get { return ById("ctl00_ContentMain_ucAccount_btnRegisterAccount_btnRadButton"); }
        }

        private IWebElement ContinueUsingSameLoginElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_btnNextStep_btnRadButton"); }
        }
        private IWebElement Account_OrganizationNameElement
        {
            get { return ById("ctl00_ContentMain_ucOrganization_tbCustomerName"); }
        }

        private IWebElement Account_WebsiteElement
        {
            get { return ById("ctl00_ContentMain_ucOrganization_tbWebSite"); }
        }

        private IWebElement Account_MainPhoneNumberElement
        {
            get { return ById("ctl00_ContentMain_ucOrganization_tbPhone"); }
        }
        private IWebElement Account_MailingAddressElement
        {
            get { return ById("ctl00_ContentMain_ucOrganization_ucAddress_tbAddress"); }
        }
        private IWebElement Account_CityElement
        {
            get { return ById("ctl00_ContentMain_ucOrganization_ucAddress_tbCity"); }
        }

        private IWebElement Account_PostalCodeElement
        {
            get { return ById("ctl00_ContentMain_ucOrganization_ucAddress_tbPostalCode"); }
        }

        private IWebElement Account_OrgClassificationDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucOrganization$ddBusinessClassification"); }
        }
        private IWebElement Account_OrgClassificationSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucOrganization_ddBusinessClassification_DropDown']/div/ul/li[1]"); }
        }

        private IWebElement Account_OrgTypeDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucOrganization$ddCustomerType"); }
        }
        private IWebElement Account_OrgTypeSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucOrganization_ddCustomerType_DropDown']/div/ul/li[2]"); }
        }

        private IWebElement Account_StateDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucOrganization$ucAddress$cbStateID"); }
        }
        private IWebElement Account_StateSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucOrganization_ucAddress_cbStateID_DropDown']/div/ul/li[6]"); }
        }

        private IWebElement Account_CountryDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucOrganization$ucAddress$cbCountryID"); }
        }
        private IWebElement Account_CountrySelectedDropDownElement
        {
            // get { return ByXPath("//*[@id='ctl00_ContentMain_ucOrganization_ucAddress_cbCountryID_DropDown']/div/ul/li[14]"); }
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucOrganization_ucAddress_cbCountryID_DropDown']/div/ul/li[13]"); }
        }

        private IWebElement Account_TimeZoneDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucOrganization$ddTimeZoneID"); }
        }
        private IWebElement Account_TimeZoneSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucOrganization_ddTimeZoneID_DropDown']/div/ul/li[6]"); }
        }
        private IWebElement ContinueToStep3Element
        {
            get { return ById("ctl00_ContentMain_ucOrganization_btnNextStep_btnRadButton"); }
        }

        private IWebElement Account_ProductEditionDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucProduct$ddProductCode"); }
        }
        private IWebElement Account_ProductEditionSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucProduct_ddProductCode_DropDown']/div/ul/li[1]"); }
        }
        private IWebElement Account_StationSelectedElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucProduct_tbCheckinLicenses_SpinUpButton']"); }
        }
        private IWebElement Account_PaymentTypeDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucProduct$ddPaymentType"); }
        }
        private IWebElement Account_PaymentTypeSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucProduct_ddPaymentType_DropDown']/div/ul/li[1]"); }
        }
        private IWebElement Account_SalesRepDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucProduct$ddSalesRep"); }
        }
        private IWebElement Account_SalesRepSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucProduct_ddSalesRep_DropDown']/div/ul/li[1]"); }
        }

        private IWebElement ContinueToStep4Element
        {
            get { return ById("ctl00_ContentMain_ucProduct_btnNextStep_btnRadButton"); }
        }

        private IWebElement ContinueElement
        {
            get { return ById("ctl00_ContentMain_ucSummary_btnNextStep_btnRadButton"); }
        }
        private IWebElement Account_IDontHaveEmailElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_lnkNoEmail"); }
        }
        private IWebElement Account_UsernameElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbUsername1"); }
        }

        #endregion

        #region Methods
        public SignupPageModel InitiateKidCheckSignUP()
        {
            SignUpKidCheckElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new SignupPageModel(Driver, BaseUri);
        }

        public void ClickReadyToGo()
        {
            //WebDriverWait wait = new WebDriverWait(Driver,TimeSpan.FromSeconds(1));
            //wait.Until(ExpectedConditions.ElementIsVisible(WelcomeElement)).click();

            Thread.Sleep(AppConstant.SleepTime * 5);
            WelcomeElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void FillNewAccountDetails(SignupDetailsModel _signupDetail, bool fillUserName)
        {
            Account_FirstNameElement.SendKeys(_signupDetail.Account_FirstName);
            Account_LastnameElement.SendKeys(_signupDetail.Account_Lastname);
            Account_EmailIDElement.SendKeys(_signupDetail.Account_EmailID);

            if (fillUserName)
            {
                Account_IDontHaveEmailElement.Click();
                Account_UsernameElement.SendKeys(_signupDetail.Account_UserName);
            }

            Account_PasswordElement.SendKeys(_signupDetail.Account_Password);
            Account_ConfirmPasswordElement.SendKeys(_signupDetail.Account_ConfirmPassword);
            Account_PhoneNumberElement.SendKeys(_signupDetail.Account_PhoneNumber);
            Account_MobileNumberElement.SendKeys(_signupDetail.Account_MobileNumber);
        }

        public void ContinueToStep2()
        {
            ContinueToStep2Element.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void ContinueUsingSameLogin()
        {
            ContinueUsingSameLoginElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void FillChildCareOrgDetails(ChildcareOrganizationDetailsModel childcareOrganizationDetailsModel)
        {
            Account_OrganizationNameElement.SendKeys(childcareOrganizationDetailsModel.Childcare_OrganizationName);
            Account_OrgClassificationDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_OrgClassificationSelectedDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_OrgTypeDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_OrgTypeSelectedDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime);
            Account_WebsiteElement.SendKeys(childcareOrganizationDetailsModel.Childcare_Website);

            Thread.Sleep(AppConstant.SleepTime);
            Account_MainPhoneNumberElement.SendKeys(childcareOrganizationDetailsModel.Childcare_MainPhoneNumber);
            Account_MailingAddressElement.SendKeys(childcareOrganizationDetailsModel.Childcare_MailingAddress);
            Account_CityElement.SendKeys(childcareOrganizationDetailsModel.Childcare_City);

            Thread.Sleep(AppConstant.SleepTime);
            Account_StateDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime);
            Account_StateSelectedDropDownElement.Click();
            Account_PostalCodeElement.SendKeys(childcareOrganizationDetailsModel.Childcare_PostalCode);

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_CountryDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_CountrySelectedDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_TimeZoneDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_TimeZoneSelectedDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void ContinueToStep3()
        {
            ContinueToStep3Element.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void KidcheckProductSelection()
        {
            Account_ProductEditionDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_ProductEditionSelectedDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_StationSelectedElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_PaymentTypeDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_PaymentTypeSelectedDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_SalesRepDropDownElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            Account_SalesRepSelectedDropDownElement.Click();
        }

        public void ContinueToStep4()
        {
            ContinueToStep4Element.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void Continue()
        {
            ContinueElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        #endregion
    }
}
