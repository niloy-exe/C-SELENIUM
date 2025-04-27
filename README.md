# Required Namespaces:
```csharp
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
```

These namespaces provide access to WebDriver functionalities (`Selenium`), the Chrome driver (`ChromeDriver`), and utilities like `WebDriverWait` for waiting (`Support.UI`).

## Example 1: Click Elements

### 1. Click by ID
```csharp
IWebElement button = driver.FindElement(By.Id("submitButton"));
button.Click();
```

### 2. Click by Class Name
```csharp
IWebElement button = driver.FindElement(By.ClassName("btn-primary"));
button.Click();
```

### 3. Click by XPath
```csharp
IWebElement button = driver.FindElement(By.XPath("//button[@class='btn-primary']"));
button.Click();
```

### 4. Click by CSS Selector
```csharp
IWebElement button = driver.FindElement(By.CssSelector(".btn-primary"));
button.Click();
```

### 5. Click All Buttons on the Page
```csharp
IEnumerable<IWebElement> buttons = driver.FindElements(By.TagName("button"));
foreach (IWebElement button in buttons)
{
    button.Click();
    System.Threading.Thread.Sleep(1000); // Pause between clicks
}
```

### 6. Click Using JavaScript (Alternative)
```csharp
IWebElement button = driver.FindElement(By.Id("submitButton"));
IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
js.ExecuteScript("arguments[0].click();", button);
```

## Example 2: Send Keys (Typing Text into Input Fields)

### 1. Send Keys by ID
```csharp
IWebElement searchBox = driver.FindElement(By.Id("searchInput"));
searchBox.SendKeys("Selenium WebDriver in C#");
searchBox.Submit(); // Optional: Submit the form after entering the text
```

### 2. Send Keys by Class Name
```csharp
IWebElement usernameField = driver.FindElement(By.ClassName("username"));
usernameField.SendKeys("myUsername");
```

### 3. Send Keys by XPath
```csharp
IWebElement passwordField = driver.FindElement(By.XPath("//input[@name='password']"));
passwordField.SendKeys("myPassword");
```

### 4. Send Keys by CSS Selector
```csharp
IWebElement emailField = driver.FindElement(By.CssSelector(".email-field"));
emailField.SendKeys("myemail@example.com");
```

## Example 3: Full Example (Click and Send Keys)

```csharp
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.example.com");

            try
            {
                // Send Keys to a search box by ID
                IWebElement searchBox = driver.FindElement(By.Id("searchInput"));
                searchBox.SendKeys("Selenium WebDriver in C#");

                // Submit the search
                searchBox.Submit();
                
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
```
