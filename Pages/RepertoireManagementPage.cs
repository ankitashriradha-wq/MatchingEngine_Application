using MatchingEngine_Task.Resource;
using MatchingEngine_Task.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace MatchingEngine_Task.Pages
{   
  
    class RepertoireManagementPage : BasePage
    {

        public RepertoireManagementPage(IWebDriver driver) : base(driver)
        {
        }

        readonly By ReportUsageMatch = By.XPath("//h5[contains(text(), 'Repertoire and usage matching')]");
        readonly By RelatedSolutionLabel = By.XPath("//div[@id='content']/section[6]/div/header/div/div/div/div/div/h2");
        readonly By SoftwareFeatLabel = By.XPath("//div[@id='content']/section[4]/div/header/div/div/div/div/div/h2");

        /// <summary>
        /// Finds list items on the repertoire management page.
        /// </summary>
        public void FindListItems()
        {


            IWebElement RelatedSolSection = Driver.FindElement(RelatedSolutionLabel);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(200));

            JavaScriptExecutorHelper.ScrollIntoView(Driver, RelatedSolutionLabel);



            IWebElement ReportUsageMatchLink = Driver.FindElement(ReportUsageMatch);

            Actions actions = new Actions(Driver);
            actions.MoveToElement(ReportUsageMatchLink);
            actions.Perform();



            ReportUsageMatchLink.Click();

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(200));

            JavaScriptExecutorHelper.ScrollIntoView(Driver, SoftwareFeatLabel);



            foreach (var expectedFeature in TestData.SoftwareFeatures)
            {
                IWebElement output = Driver.FindElement(By.XPath($"//h5[contains(text(), '{expectedFeature}')]"));
                string val = output.Text;
                Assert.That(val, Is.EqualTo(expectedFeature), "Strings are not matching");
                Console.WriteLine(val);
                try
                {
                    var oneLine = $"{System.DateTime.UtcNow:O} RepertoireManagementPage: {((val == null) ? "null" : val.ToString())}";
                    System.Console.WriteLine(oneLine);
                }
                catch
                {

                }
            }
        }
    }
}
