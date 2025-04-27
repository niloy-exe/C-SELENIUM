
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SeleniumExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize ChromeDriver
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.example.com");

            try
            {
                // Example 1: Click by ID
                IWebElement buttonById = driver.FindElement(By.Id("submitButton"));
                buttonById.Click();
                Console.WriteLine("Clicked by ID");

                // Example 2: Click by Class Name
                IWebElement buttonByClass = driver.FindElement(By.ClassName("btn-primary"));
                buttonByClass.Click();
                Console.WriteLine("Clicked by Class Name");

                // Example 3: Click by XPath
                IWebElement buttonByXPath = driver.FindElement(By.XPath("//button[@class='btn-primary']"));
                buttonByXPath.Click();
                Console.WriteLine("Clicked by XPath");

                // Example 4: Click by CSS Selector
                IWebElement buttonByCss = driver.FindElement(By.CssSelector(".btn-primary"));
                buttonByCss.Click();
                Console.WriteLine("Clicked by CSS Selector");

                // Example 5: Click All Buttons on the Page
                IEnumerable<IWebElement> buttons = driver.FindElements(By.TagName("button"));
                foreach (IWebElement button in buttons)
                {
                    button.Click();
                    Console.WriteLine("Clicked button");
                    System.Threading.Thread.Sleep(1000); // Pause between clicks
                }

                // Example 6: Click Using JavaScript
                IWebElement buttonByJs = driver.FindElement(By.Id("submitButton"));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", buttonByJs);
                Console.WriteLine("Clicked by JavaScript");

                // Example 7: Send Keys by ID
                IWebElement searchBox = driver.FindElement(By.Id("searchInput"));
                searchBox.SendKeys("Selenium WebDriver in C#");
                searchBox.Submit();
                Console.WriteLine("Sent keys to search box by ID");

                // Example 8: Send Keys by Class Name
                IWebElement usernameField = driver.FindElement(By.ClassName("username"));
                usernameField.SendKeys("myUsername");
                Console.WriteLine("Sent keys to username field by Class Name");

                // Example 9: Send Keys by XPath
                IWebElement passwordField = driver.FindElement(By.XPath("//input[@name='password']"));
                passwordField.SendKeys("myPassword");
                Console.WriteLine("Sent keys to password field by XPath");

                // Example 10: Send Keys by CSS Selector
                IWebElement emailField = driver.FindElement(By.CssSelector(".email-field"));
                emailField.SendKeys("myemail@example.com");
                Console.WriteLine("Sent keys to email field by CSS Selector");

                // Example 11: Full Example (Click and Send Keys)
                // Send Keys to a search box by ID
                IWebElement searchBoxFull = driver.FindElement(By.Id("searchInput"));
                searchBoxFull.SendKeys("Selenium WebDriver in C#");
                searchBoxFull.Submit();

                // Wait for results to load
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("search-results")));

                Console.WriteLine("Search submitted and results loaded.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
