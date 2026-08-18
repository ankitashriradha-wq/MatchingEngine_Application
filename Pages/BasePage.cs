using OpenQA.Selenium;

namespace MatchingEngine_Task.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; }

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
