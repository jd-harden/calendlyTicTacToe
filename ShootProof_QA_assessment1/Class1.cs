using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ShootProof_QA_assessment1
{
    [TestFixture]
    public class Chrome_test
    {
        //private const string XpathToFind = "//button[contains(text(), 'Get Started')]";
        private IWebDriver driver;
        public string homeURL;

        [Test(Description = "Find and click first Get Started button on ShootProof")]
        public void Get_started_is_on_home_page()
        {


            homeURL = "https://www.shootproof.com";
            driver.Navigate().GoToUrl(homeURL);
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
                                  
            //Clicks on Get Started button at top of page
            driver.FindElement(By.CssSelector("#navbar-button-trigger > a.btn.btn-shootproof.google-ads-signup-tracking")).Click();
            
                                                                 

        }

        [Test(Description = "Find and click second Get Started button on ShootProof")]
        public void Get_started_is_at_bottom_home_page()
        {


            homeURL = "https://www.shootproof.com";
            driver.Navigate().GoToUrl(homeURL);
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));

            //Clicks on Get Started button at bottom of page

            driver.FindElement(By.CssSelector("#try-free > div > p:nth-child(3) > a")).Click();



        }



        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }


        [SetUp]
        public void SetupTest()
        {
            homeURL = "http://shootproof.com";
            driver = new ChromeDriver();

        }


    }


}

