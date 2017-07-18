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
        public IWebElement SignUpKidCheckElement
        {
            get { return ByClass("signup-green"); }
        }

        public IWebElement WelcomeElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucWelcome_btnGoToStep1_btnRadButton']"); }
        }

        public IWebElement Account_FirstNameElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbFirstName"); }
        }

        public IWebElement Account_LastnameElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbLastName"); }
        }

        public IWebElement Account_EmailIDElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbEmail"); }
        }

        public IWebElement Account_PasswordElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbPassword1"); }
        }

        public IWebElement Account_ConfirmPasswordElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbPassword2"); }
        }

        public IWebElement Account_PhoneNumberElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbHomePhone"); }
        }

        public IWebElement Account_MobileNumberElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_tbCellPhone"); }
        }

        public IWebElement ContinueToStep2Element
        {
            get { return ById("ctl00_ContentMain_ucAccount_btnRegisterAccount_btnRadButton"); }
        }

        public IWebElement ContinueUsingSameLoginElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_btnNextStep_btnRadButton"); }
        }
        public IWebElement Account_OrganizationNameElement
        {
            get { return ById("ctl00_ContentMain_ucOrganization_tbCustomerName"); }
        }

        public IWebElement Account_WebsiteElement
        {
            get { return ById("ctl00_ContentMain_ucOrganization_tbWebSite"); }
        }

        public IWebElement Account_MainPhoneNumberElement
        {
            get { return ById("ctl00_ContentMain_ucOrganization_tbPhone"); }
        }
        public IWebElement Account_MailingAddressElement
        {
            get { return ById("ctl00_ContentMain_ucOrganization_ucAddress_tbAddress"); }
        }
        public IWebElement Account_CityElement
        {
            get { return ById("ctl00_ContentMain_ucOrganization_ucAddress_tbCity"); }
        }

        public IWebElement Account_PostalCodeElement
        {
            get { return ById("ctl00_ContentMain_ucOrganization_ucAddress_tbPostalCode"); }
        }

        public IWebElement Account_OrgClassificationDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucOrganization$ddBusinessClassification"); }
        }
        public IWebElement Account_OrgClassificationSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucOrganization_ddBusinessClassification_DropDown']/div/ul/li[1]"); }
        }

        public IWebElement Account_OrgTypeDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucOrganization$ddCustomerType"); }
        }
        public IWebElement Account_OrgTypeSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucOrganization_ddCustomerType_DropDown']/div/ul/li[2]"); }
        }

        public IWebElement Account_StateDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucOrganization$ucAddress$cbStateID"); }
        }
        public IWebElement Account_StateSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucOrganization_ucAddress_cbStateID_DropDown']/div/ul/li[6]"); }
        }

        public IWebElement Account_CountryDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucOrganization$ucAddress$cbCountryID"); }
        }
        public IWebElement Account_CountrySelectedDropDownElement
        {
            // get { return ByXPath("//*[@id='ctl00_ContentMain_ucOrganization_ucAddress_cbCountryID_DropDown']/div/ul/li[14]"); }
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucOrganization_ucAddress_cbCountryID_DropDown']/div/ul/li[13]"); }
        }

        public IWebElement Account_TimeZoneDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucOrganization$ddTimeZoneID"); }
        }
        public IWebElement Account_TimeZoneSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucOrganization_ddTimeZoneID_DropDown']/div/ul/li[6]"); }
        }
        public IWebElement ContinueToStep3Element
        {
            get { return ById("ctl00_ContentMain_ucOrganization_btnNextStep_btnRadButton"); }
        }

        public IWebElement Account_ProductEditionDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucProduct$ddProductCode"); }
        }
        public IWebElement Account_ProductEditionSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucProduct_ddProductCode_DropDown']/div/ul/li[1]"); }
        }
        public IWebElement Account_StationSelectedElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucProduct_tbCheckinLicenses_SpinUpButton']"); }
        }
        public IWebElement Account_PaymentTypeDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucProduct$ddPaymentType"); }
        }
        public IWebElement Account_PaymentTypeSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucProduct_ddPaymentType_DropDown']/div/ul/li[1]"); }
        }
        public IWebElement Account_SalesRepDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ucProduct$ddSalesRep"); }
        }
        public IWebElement Account_SalesRepSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucProduct_ddSalesRep_DropDown']/div/ul/li[1]"); }
        }

        public IWebElement ContinueToStep4Element
        {
            get { return ById("ctl00_ContentMain_ucProduct_btnNextStep_btnRadButton"); }
        }

        public IWebElement ContinueElement
        {
            get { return ById("ctl00_ContentMain_ucSummary_btnNextStep_btnRadButton"); }
        }
        public IWebElement Account_IDontHaveEmailElement
        {
            get { return ById("ctl00_ContentMain_ucAccount_lnkNoEmail"); }
        }
        public IWebElement Account_UsernameElement
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

        public SignupPageModel WelcomePage()
        {
            //WebDriverWait wait = new WebDriverWait(Driver,TimeSpan.FromSeconds(1));
            //wait.Until(ExpectedConditions.ElementIsVisible(WelcomeElement)).click();

            Thread.Sleep(AppConstant.SleepTime * 5);
            WelcomeElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new SignupPageModel(Driver, BaseUri);
        }

        public SignupPageModel FillNewAccountDetailsWithEmail(SignupDetailsModel _signupDetail)
        {
            Account_FirstNameElement.SendKeys(_signupDetail.Account_FirstName);
            Account_LastnameElement.SendKeys(_signupDetail.Account_Lastname);
            Account_EmailIDElement.SendKeys(_signupDetail.Account_EmailID);
            Account_PasswordElement.SendKeys(_signupDetail.Account_Password);
            Account_ConfirmPasswordElement.SendKeys(_signupDetail.Account_ConfirmPassword);
            Account_PhoneNumberElement.SendKeys(_signupDetail.Account_PhoneNumber);
            Account_MobileNumberElement.SendKeys(_signupDetail.Account_MobileNumber);
            return new SignupPageModel(Driver, BaseUri);
        }

        public SignupPageModel FillNewAccountDetailsWithUser(SignupDetailsModel _signupDetail)
        {
            Account_FirstNameElement.SendKeys(_signupDetail.Account_FirstName);
            Account_LastnameElement.SendKeys(_signupDetail.Account_Lastname);
            Account_IDontHaveEmailElement.Click();
            Account_UsernameElement.SendKeys(_signupDetail.Account_UserName);
            Account_PasswordElement.SendKeys(_signupDetail.Account_Password);
            Account_ConfirmPasswordElement.SendKeys(_signupDetail.Account_ConfirmPassword);
            Account_PhoneNumberElement.SendKeys(_signupDetail.Account_PhoneNumber);
            Account_MobileNumberElement.SendKeys(_signupDetail.Account_MobileNumber);
            return new SignupPageModel(Driver, BaseUri);
        }

        public SignupPageModel ContinueToStep2()
        {
            ContinueToStep2Element.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new SignupPageModel(Driver, BaseUri);
        }

        public SignupPageModel ContinueUsingSameLogin()
        {
            ContinueUsingSameLoginElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new SignupPageModel(Driver, BaseUri);
        }

        public SignupPageModel FillChildCareOrgDetails(ChildcareOrganizationDetailsModel childcareOrganizationDetailsModel)
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
            return new SignupPageModel(Driver, BaseUri);
        }

        public SignupPageModel ContinueToStep3()
        {
            ContinueToStep3Element.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new SignupPageModel(Driver, BaseUri);
        }

        public SignupPageModel KidcheckProductSelection()
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
            return new SignupPageModel(Driver, BaseUri);
        }

        public SignupPageModel ContinueToStep4()
        {
            ContinueToStep4Element.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new SignupPageModel(Driver, BaseUri);
        }

        public SignupPageModel Continue()
        {
            ContinueElement.Click();

            Thread.Sleep(AppConstant.SleepTime * 2);
            return new SignupPageModel(Driver, BaseUri);
        }

        #endregion
    }
}
