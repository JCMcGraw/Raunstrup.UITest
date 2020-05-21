using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xceed.Wpf.Toolkit;
using Xunit;

namespace Raunstrup.UITest
{
    public class AutomatedUITests :IDisposable
    {
        private readonly IWebDriver _driver;
        public AutomatedUITests()
        {
            _driver = new ChromeDriver();
        }
        [Fact]
        public void Test1()
        {
            _driver.Navigate()
        .GoToUrl("https://localhost:44347/");

            Assert.Equal("Home Page - Raunstrup", _driver.Title);
        }

        [Fact]
        public void Test2()
        {
            _driver.Navigate()
        .GoToUrl("https://localhost:44347/Identity/Account/Login");

            _driver.FindElement(By.Id("Input_UserName"))
        .SendKeys("8");

            _driver.FindElement(By.Id("Input_Password"))
                .SendKeys("bruger8");

            _driver.FindElement(By.Id("loginbutton"))
                .Click();

            var result = _driver.FindElement(By.Id("loginhello")).Text;

            Assert.Equal("Hello 8!", result);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
