using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using KidCheckTest.Helper;

namespace KidCheckTest.PageModel
{
    public class BasePageModel
    {
        protected Uri BaseUri;
        protected IWebDriver Driver;

        #region Page Setup
        public BasePageModel(IWebDriver driver, Uri baseUri)
        {
            Driver = driver;
            BaseUri = baseUri;
        }

        public Uri GetAbsoluteUri(string relativePath)
        {
            var ub = new UriBuilder(BaseUri);
           // ub.Path = relativePath; // to add in production site i.e www.kidcheck.com 
            return ub.Uri;
        }
        #endregion

        #region Identifiers
        protected IWebElement ById(string id)
        {
            try
            {
                Thread.Sleep(1000);
                return Driver.FindElement(By.Id(id));
            }
            catch (Exception)
            {
                throw new Exception("Element is missing");
            }
        }

        protected IWebElement ByName(string name)
        {
            Thread.Sleep(1000);
            try
            {
                return Driver.FindElement(By.Name(name));
            }
            catch (Exception)
            {
                throw new Exception("Element is missing");
            }
        }

        protected IWebElement ByClass(string className)
        {
            Thread.Sleep(1000);
            try
            {
                return Driver.FindElement(By.ClassName(className));
            }
            catch (NoSuchElementException)
            {
                throw new Exception("Element is missing");
            }
        }

        protected IWebElement ByCssSelector(string cssSelector)
        {
            Thread.Sleep(1000);
            try
            {
                return Driver.FindElement(By.CssSelector(cssSelector));
            }
            catch (Exception)
            {
                throw new Exception("Element is missing");
            }
        }

        protected IWebElement ByXPath(string xPath)
        {
            Thread.Sleep(1000);
            try
            {
                return Driver.FindElement(By.XPath(xPath));
            }
            catch (Exception)
            {
                throw new Exception("Element is missing");
            }
        }

        protected IWebElement ByLink(string link)
        {
            Thread.Sleep(1000);
            try
            {
                return Driver.FindElement(By.LinkText(link));
            }
            catch (Exception)
            {
                throw new Exception("Element is missing");
            }
        }

        protected IWebElement byTagName(string tagName)
        {
            Thread.Sleep(1000);
            try
            {
                return Driver.FindElement(By.TagName(tagName));
            }
            catch (Exception)
            {
                throw new Exception("Element is missing");
            }
        }

        public bool TryFindElement(By by, out IWebElement element)
        {
            try
            {
                element = Driver.FindElement(by);
            }
            catch (Exception)
            {
                element = null;
                return false;
            }
            return true;
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        #endregion

        #region Tab Elements
        public IWebElement HomeTabElement
        {
            get { return ByXPath("//*[@id='homeTab']/span/span"); }
        }

        public IWebElement MyAccountTabElement
        {
            get { return ByXPath("//*[@id='MyAccountTab']/span/span/span"); }
        }

        public IWebElement KidsTabElement
        {
            get { return ByXPath("//*[@id='KidsTab']/span/span"); }
        }

        public IWebElement GuardianTabElement
        {
            get { return ById("GuardiansTab"); }
        }

        public IWebElement CheckInTabElement
        {
            get { return ById("CheckinTab"); }
        }
        public IWebElement UtilitiesTabElement
        {
            get { return ById("AdminConsoleTab"); }
        }


        #endregion

        #region Methods 
        public void ReloadPage()
        {
            Driver.Navigate().Refresh();
        }

        public string CheckElementInDropDownList(IWebElement dropDownElement, string[] ElementNames)
        {
            dropDownElement.Click();
            List<string> elementNameList = ElementNames.ToList();
            int expectedCount = elementNameList.Count;
            var actualElementInDD = new SelectElement(dropDownElement);
            int actualCount = actualElementInDD.Options.Count;

            if (actualCount == expectedCount)
            {
                if (IsElementPresentInDropDoownList(elementNameList, actualElementInDD))
                {
                    return null;
                }
                else
                {
                    return "The Element in drop down does not match";
                }
            }
            else if (actualCount > expectedCount)
            {
                return "The element count in drop down is greater";
            }
            else
            {
                return "The element count in drop down is less";
            }
        }

        public bool IsElementPresentInDropDoownList(List<string> elementNameList, SelectElement actualElementInDD)
        {
            for (int index = 0; index < actualElementInDD.Options.Count; index++)
            {
                IWebElement element = actualElementInDD.Options[index];
                string countryName = element.Text;
                for (int j = 0; j < elementNameList.Count; j++)
                {
                    if (countryName == elementNameList[j])
                    {
                        elementNameList.Remove(countryName);
                        break;
                    }
                }
            }
            if (elementNameList.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        public int GetAttributeValueCountFromLList(IList<IWebElement> elementList, string attribute, string attributeValue)
        {
            int count = 0;
            foreach (IWebElement category in elementList)
            {
                if (category.GetAttribute(attribute).Contains(attributeValue))
                {
                    count++;
                }
            }

            return count;
        }
        #endregion

    }
}
