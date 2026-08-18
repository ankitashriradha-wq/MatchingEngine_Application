using System;
using OpenQA.Selenium;

namespace MatchingEngine_Task.Utilities
{
    /// <summary>
    /// Helper methods for scrolling elements into view using IJavaScriptExecutor.
    /// </summary>
    public static class JavaScriptExecutorHelper
    {
        /// <summary>
        /// Gets the IJavaScriptExecutor from a driver instance.
        /// </summary>
        public static IJavaScriptExecutor Js(this IWebDriver driver)
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            if (!(driver is IJavaScriptExecutor js))
                throw new NotSupportedException("The provided IWebDriver does not support JavaScript execution.");

            return js;
        }

        /// <summary>
        /// Scrolls the provided element into view using the driver's IJavaScriptExecutor.
        /// </summary>
        /// <param name="js">The IJavaScriptExecutor instance.</param>
        /// <param name="element">The element to scroll into view.</param>
        public static void ScrollIntoView(this IJavaScriptExecutor js, IWebElement element)
        {
            if (js == null) throw new ArgumentNullException(nameof(js));
            if (element == null) throw new ArgumentNullException(nameof(element));

            js.ExecuteScript("arguments[0].scrollIntoView(arguments[1]);", element);
        }

        /// <summary>
        /// Convenience overload that accepts IWebDriver and an element.
        /// </summary>
        public static void ScrollIntoView(this IWebDriver driver, IWebElement element)
        {
            driver.Js().ScrollIntoView(element);
        }

        /// <summary>
        /// Convenience overload that accepts IWebDriver and a By locator. Finds the element and scrolls it into view.
        /// Throws if element isn't found.
        /// </summary>
        public static void ScrollIntoView(this IWebDriver driver, By by)
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            if (by == null) throw new ArgumentNullException(nameof(by));

            var element = driver.FindElement(by);
            driver.ScrollIntoView(element);
        }
    }
}
