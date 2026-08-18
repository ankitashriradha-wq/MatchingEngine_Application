using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Xml.Linq;

namespace MatchingEngine_Task.Pages
{

    public class DashboardPage : BasePage
    {
        WebDriverWait wait;

        public DashboardPage(IWebDriver driver) : base(driver)
        {

        }

        readonly By Allowall_element = By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll");
        readonly By AllowSelect_element = By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowallSelection");
        readonly By Deny_element = By.Id("CybotCookiebotDialogBodyButtonDecline");
        readonly By Solutions_Link = By.CssSelector("span#nav-toggle-solutions.MainNavLink_linkEl__ZECPn");
        readonly By RepertoireManagementModule = By.XPath("//div[@class='BrandNavSubMenu_children__zRQnS']/div[1]/a/span[contains(text(), 'Repertoire management')]");



        // Consolidated cookie actions into a single method using a switch-case.
        // action values (case-insensitive): "allowall", "allowselection", "deny"
        public void HandleCookies(string action)
        {
            if (string.IsNullOrWhiteSpace(action))
                throw new ArgumentException("action must be provided", nameof(action));

            switch (action.Trim().ToLowerInvariant())
            {
                case "allowall":
                    var ck_allowAll = Driver.FindElement(Allowall_element);
                    ck_allowAll.Click();

                    break;

                case "allowselection":
                    var ck_allowSelect = Driver.FindElement(AllowSelect_element);
                    ck_allowSelect.Click();
                    break;

                case "deny":
                    var ck_Deny = Driver.FindElement(Deny_element);
                    ck_Deny.Click();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, "Unknown cookie action");
            }
        }

        public void SolutionsLink()
        {
            var clk_SolLink = Driver.FindElement(Solutions_Link);
            clk_SolLink.Click();

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(200));
            wait.Until(ExpectedConditions.ElementIsVisible(RepertoireManagementModule));

            var RepertoireManagement = Driver.FindElement(RepertoireManagementModule);
            RepertoireManagement.Click();
        }
    }
}
