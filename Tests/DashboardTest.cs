using MatchingEngine_Task.Hooks;

namespace MatchingEngine_Task.AutomationTests
{
    public class DashboardTest : Base
    {
        // Use the protected 'driver' from Base

        [Test, Category("MachineEngine Dashboard")]
        public void NavigationTest()
        {

            var page1 = new Pages.DashboardPage(driver!);
            // Example usage (adjust selectors and URL to your AUT)
            driver!.Navigate().GoToUrl(Utilities.Config.BaseUrl);


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);

            page1.HandleCookies("allowall");

            page1.SolutionsLink();
            var page2 = new Pages.RepertoireManagementPage(driver!);
            page2.FindListItems();



        }
    }
}
