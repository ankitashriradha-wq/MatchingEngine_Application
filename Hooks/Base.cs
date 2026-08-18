using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchingEngine_Task.Hooks
{
    public class Base
    {
        protected IWebDriver? driver;
        /// <summary>
        /// Initializes the WebDriver instance before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            driver = Utilities.DriverFactory.CreateDriver();
        }

        /// <summary>
        /// Cleans up resources and closes the WebDriver after each test
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            if (driver is not null)
            {
                try
                {
                    driver.Quit();
                    driver.Dispose();
                }
                catch
                {
                    // ignore cleanup errors
                }
            }

            driver = null;
        }
    }
}
