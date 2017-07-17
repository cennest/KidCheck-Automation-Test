using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace KidCheckTest.Helper
{
    class ActionHelper
    {
        public static void MouseOver(IWebDriver driver, IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
        }

        public static void WaitUntil(IWebDriver webDriver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMinutes(1));
            wait.Until(driver => element);
        }

        public static void DragDrop(IWebDriver driver, IWebElement element, IWebElement toElement, int offsetX, int offsetY)
        {
            Actions action = new Actions(driver);
            IAction dragdrop = action.ClickAndHold(element).MoveToElement(toElement, offsetX, offsetY).Release().Build();
            dragdrop.Perform();
        }

        public static IWebElement FindTableElement(IWebDriver driver, IWebElement tableElement, string textToBeMatch, string tagType)
        {
            IList<IWebElement> rows = tableElement.FindElements(By.TagName("tr"));
            IWebElement matchedRow = null;
            try
            {
                foreach (var row in rows)
                {
                    if (row.FindElements(By.XPath(string.Format("td[1]/{0}", tagType))).FirstOrDefault(cell => cell.Text.Trim().Equals(textToBeMatch)) != null)
                    {
                        matchedRow = row;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                matchedRow = null;
            }
            return matchedRow;
        }

        public static string GenerateNumber()
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < 11; i++)
            {
                r += random.Next(0, 9).ToString();
            }
            return r;
        }

        public static IWebElement WaitForElementVisibleFromList(IWebDriver webDriver, By by)
        {
            IList<IWebElement> selectElements = webDriver.FindElements(by);
            IWebElement displayedSelectElements = selectElements.Where(element => element.Displayed).SingleOrDefault();
            return displayedSelectElements;
        }
    }
}
