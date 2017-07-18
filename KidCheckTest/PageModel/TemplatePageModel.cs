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
    class TemplatePageModel : BasePageModel
    {
        #region Page Setup
        public TemplatePageModel(IWebDriver driver, Uri baseUri)
           : base(driver, baseUri)
        {
        }

        public TemplatePageModel Load()
        {
            Driver.Navigate().GoToUrl(GetAbsoluteUri("/"));
            return this;
        }
        #endregion

        #region CheckinPage Elements

        private IWebElement AddNewTemplateElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_lnkAddNewTemplate']"); }
        }
        private IWebElement TemplateNameElement
        {
            get { return ById("ctl00_ContentMain_tbName"); }
        }
        private IWebElement TemplateDescriptionElement
        {
            get { return ById("ctl00_ContentMain_tbDescription"); }
        }
        private IWebElement CampusDropDownElement
        {
            get { return ByName("ctl00$ContentMain$ddCheckinSiteID"); }
        }
        private IWebElement CampusSelectedDropDownElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ddCheckinSiteID_DropDown']/div/ul/li[1]"); }
        }
        private IWebElement SubmitTemplateElement
        {
            get { return ById("ctl00_ContentMain_btnSaveItem_btnRadButton"); }
        }
        private IWebElement LocationElement
        {
            get { return ById("ctl00_ContentMain_ucChildSelector_rgAvailableLocations_ctl00__0"); }
        }

        private IWebElement SelectedLocationElement
        {
            get { return ByXPath("//*[@id='ctl00_ContentMain_ucChildSelector_rgSelectedLocations_ctl00']/tbody"); }
        }
        private IWebElement SaveTemplateLocationElement
        {
            get { return ById("ctl00_ContentMain_btnSave_View_btnRadButton"); }
        }
        #endregion


        #region Methods
       
        public void ClickAddNewTemplate()
        {
            AddNewTemplateElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void FillNewTemplateDetails(TemplateModel template)
        {
            TemplateNameElement.SendKeys(template.Name);
            TemplateDescriptionElement.SendKeys(template.Description);
            CampusDropDownElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
            CampusSelectedDropDownElement.Click();
        }

        public void SubmitNewTemplate()
        {
            SubmitTemplateElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }

        public void DragDropLocationTemplate()
        {
            ActionHelper.DragDrop(Driver, LocationElement, SelectedLocationElement);
            Thread.Sleep(AppConstant.SleepTime * 2);
        }
        public void SaveNewTemplateLocation()
        {
            SaveTemplateLocationElement.Click();
            Thread.Sleep(AppConstant.SleepTime * 2);
        }
        #endregion
    }
}
