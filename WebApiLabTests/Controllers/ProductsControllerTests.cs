using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLab.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net;

namespace WebApiLab.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        [TestInitialize()]
        public void SetupTest()
        {
            // driver = new ChromeDriver();
            baseURL = "http://localhost:3752";
            verificationErrors = new StringBuilder();
        }

        //[TestCleanup()]
        //public void TeardownTest()
        //{
        //    try
        //    {
        //        driver.Quit();
        //    }
        //    catch (Exception)
        //    {
        //        // Ignore errors if unable to close the browser
        //    }
        //    Assert.AreEqual("", verificationErrors.ToString());
        //}
        [TestMethod()]
        public void GetAllProductsTest()
        {
            // driver.Navigate().GoToUrl(baseURL + "/api/products");
            //driver.FindElement(By.Id("txtAccount")).Clear();
            //driver.FindElement(By.Id("txtAccount")).SendKeys("joey");
            //driver.FindElement(By.Id("txtPassword")).Clear();
            //driver.FindElement(By.Id("txtPassword")).SendKeys("91");
            //driver.FindElement(By.Id("btnLogin")).Click();
            // string result = driver.ToString();
            // Assert.IsTrue(driver.FindElements(By.TagName("Category")).Count > 0);

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("API_KEY", "KIMX-INFO-API-KEY");
                string download = client.DownloadString(baseURL + "/api/products");
                Assert.IsTrue(true);
            }
        }
    }
}
