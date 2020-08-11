using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Calendly_TicTacToe
{
    [TestFixture]
    public class CalendlyFirstTest
    {
        private IWebDriver driver;
        public string homeURL;

        [Test(Description = "Open Tic Tac Toe site, write placeholder text to console")]
        public void ticTacToe_test()
        {
            homeURL = "https://codepen.io/CalendlyQA/full/KKPQLmV";
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver,
                System.TimeSpan.FromSeconds(15));
            driver.SwitchTo().Frame(0);
            driver.FindElement(By.XPath("//input[@id='number']"));

            var placeholderText = driver.FindElement(By.XPath("//input[@id='number']")).GetAttribute("placeholder");
            Console.WriteLine("The value in the box is: " + placeholderText);


        }

        [Test(Description = "Enter number to generate board and click start.  Play game - X wins")]
        public void startGame_test()
        {
            homeURL = "https://codepen.io/CalendlyQA/full/KKPQLmV";
            driver.Navigate().GoToUrl(homeURL);
            driver.SwitchTo().Frame(0).FindElement(By.XPath("//input[@id='number']"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//input[@id='number']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//input[@id='number']")).SendKeys("3");
            var gridSize = driver.FindElement(By.XPath("//input[@id='number']")).GetAttribute("value");
            Console.WriteLine("The grid size for the game is: " + gridSize + " by " + gridSize);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.CssSelector("#start")).Click();
            driver.FindElement(By.XPath("//tr[1]/td[1]")).Click();
            driver.FindElement(By.XPath("//tr[1]/td[2]")).Click();
            driver.FindElement(By.XPath("//tr[2]/td[1]")).Click();
            driver.FindElement(By.XPath("//tr[2]/td[2]")).Click();
            driver.FindElement(By.XPath("//tr[3]/td[1]")).Click();
            
            
            
        }

        [Test(Description = "Play 3 x 3 game and have X win, message will say O though, Start second game with 4 x 4 grid")]
        public void playGame_test()
        {
            homeURL = "https://codepen.io/CalendlyQA/full/KKPQLmV";
            driver.Navigate().GoToUrl(homeURL);
            driver.SwitchTo().Frame(0).FindElement(By.XPath("//input[@id='number']"));
            
            driver.FindElement(By.XPath("//input[@id='number']")).Click();
            driver.FindElement(By.XPath("//input[@id='number']")).SendKeys("3");
            var gridSizeGameOne = driver.FindElement(By.XPath("//input[@id='number']")).GetAttribute("value");
            Console.WriteLine("The grid size for the game is: " + gridSizeGameOne + " by " + gridSizeGameOne);
            driver.FindElement(By.CssSelector("#start")).Click();
            driver.FindElement(By.XPath("//tr[1]/td[1]")).Click();
            driver.FindElement(By.XPath("//tr[1]/td[2]")).Click();
            driver.FindElement(By.XPath("//tr[2]/td[1]")).Click();
            driver.FindElement(By.XPath("//tr[2]/td[2]")).Click();
            driver.FindElement(By.XPath("//tr[3]/td[1]")).Click();
            driver.FindElement(By.XPath("//div[@id='endgame']")).GetAttribute("innertext");
            
            Console.WriteLine("The winner is identified incorrectly!");
            driver.Navigate().Refresh();
            driver.SwitchTo().Frame(0);
            driver.FindElement(By.XPath("//input[@id='number']")).Click();
            driver.FindElement(By.XPath("//input[@id='number']")).SendKeys("4");
            var gridSizeGameTwo = driver.FindElement(By.XPath("//input[@id='number']")).GetAttribute("value");
            Console.WriteLine("The grid size for the game is: " + gridSizeGameTwo + " by " + gridSizeGameTwo);
            driver.FindElement(By.CssSelector("#start")).Click();
            
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }

        [SetUp]
        public void SetupTest()
        {
            homeURL = "https://codepen.io/CalendlyQA/full/KKPQLmV";
            driver = new ChromeDriver();
        }
    }
}
