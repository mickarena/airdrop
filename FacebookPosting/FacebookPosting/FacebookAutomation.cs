using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OtpNet;
using System.Buffers.Text;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace FacebookPosting
{
    public class FacebookAutomation
    {
        private readonly IWebDriver webDriver;

        public FacebookAutomation(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void Login(string username, string password)
        {
            // Navigate to Facebook
            webDriver.Url = "https://www.facebook.com/";

            // Find the username field (Facebook calls it "email") and enter value
            var input = webDriver.FindElement(By.Id("email"));
            input.SendKeys(username);

            // Find the password field and enter value
            input = webDriver.FindElement(By.Id("pass"));
            input.SendKeys(password);

            // Click on the login button
            ClickAndWaitForPageToLoad(webDriver, By.Id("u_0_b"));

            // At this point, Facebook will launch a post-login "wizard" that will 
            // keep asking unknown amount of questions (it thinks it's the first time 
            // you logged in using this computer). We'll just click on the "continue" 
            // button until they give up and redirect us to our "wall".
            try
            {
                while (webDriver.FindElement(By.Id("checkpointSubmitButton")) != null)
                {
                    // Clicking "continue" until we're done
                    ClickAndWaitForPageToLoad(webDriver, By.Id("checkpointSubmitButton"));
                }
            }
            catch
            {
                // We will try to click on the next button until it's not there or we fail.
                // Facebook is unexpected as to what will happen, but this approach seems 
                // to be pretty reliable
            }
        }

        public void Post(string text)
        {


            var postBoxtext = By.XPath("//*[text() = 'Hoang ơi, bạn đang nghĩ gì thế?']/parent::*");
            ActionClickDiv(webDriver, postBoxtext);

            var postBoxtextInsert = webDriver.FindElement(By.XPath("//*[text() = 'Bạn viết gì đi...']/parent::div/parent::div/child::div/child::div/child::div/child::div//child::div/child::span"));


            //var postBoxtextInsert = webDriver.FindElement(By.XPath("//*[text() = 'Bạn viết gì đi...']/parent/parent/child/child/child/child/child/child::span"));
            postBoxtextInsert.SendKeys(text);

            ////Let's find the post textbox
            //var postBox = webDriver.FindElement(By.XPath("//*[@name='xhpc_message_text']"));
            ////Type in the text
            //postBox.SendKeys(text);

            // Post button selector

            var postButtonSelector = By.XPath("//div[@aria-label='Đăng']");

           // var postButtonSelector = By.CssSelector("button[data-testid='react-composer-post-button']");

            // Let's wait for the form to complete input validation and enable the button
            WaitUntil(webDriver, () => webDriver.FindElement(postButtonSelector).Enabled);

            // Click the "Post" button and wait for the submission process to complete befor moving on
            ClickAndWaitForPageToLoad(webDriver, postButtonSelector);
        }

        public static void WaitUntil(IWebDriver driver, Func<bool> predicate, int timeout = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(d =>
                {
                    try
                    {
                        return predicate();
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                });
            }
            catch (NoSuchElementException)
            {
                throw;
            }
        }

        private void ClickAndWaitForPageToLoad(IWebDriver driver,
            By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var elements = driver.FindElements(elementLocator);
                if (elements.Count == 0)
                {
                    throw new NoSuchElementException(
                        "No elements " + elementLocator + " ClickAndWaitForPageToLoad");
                }
                var element = elements.FirstOrDefault(e => e.Displayed);
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine(
                    "Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }

        private void ActionClickDiv(IWebDriver driver,
            By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var elements = driver.FindElements(elementLocator);
                if (elements.Count == 0)
                {
                    throw new NoSuchElementException(
                        "No elements " + elementLocator + " ActionClickDiv");
                }
                var element = elements.FirstOrDefault(e => e.Displayed);


                Actions actions = new Actions(driver);
                actions.MoveToElement(element).Click().Perform();

                //element.Click();
               // wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine(
                    "Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }
    }

}
