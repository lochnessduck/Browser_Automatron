using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Drawing.Imaging;


namespace selnium
{
    class BetterChrome : ChromeDriver
    {

        public BetterChrome(string filename) : base(filename)
        {
            //clickIntercepter = new clickIntercept() { b = this }; // initialize ALL the chrome!
            // the big deal is, how to make sure clickIntercept is on, even when user navigates to a new webpage!
            // user must press 'RECORD' on the GUI before we set up clickIntercepter.
        }

        public void Navigate()
        {
            Console.Write("navigating...");
            base.Navigate();
            this.jquery = new jQuery() { b = this };
            this.jquery.load();
            //JQUERY LOADS FINE *harumph*
            Console.Write("loaded jquery!");
            this.clickIntercepter = new clickIntercept() { b = this };
            this.clickIntercepter.On();
            Console.Write("setup click interceptor!");
            Console.Write("NAVIGATED!");
        }


        // this fails when returning values. Otherwise it correctly executes the javascript passed in.
        // the exception is usually a Timeout exception.
        public object executeJavaScript(String js, params object[] parameters)
        {
            try
            {
                return base.ExecuteAsyncScript(js, parameters);
            }
            catch
            {
                return null;
            }
            //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)base.;
            //return jsExecutor.ExecuteScript(js, parameters);
        }

        public IWebElement FindElement(By by)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    IWebElement e = base.FindElement(by);
                    return e;
                }
                catch (StaleElementReferenceException err)
                {
                    Thread.Sleep(500);  // sleep just a little before trying again
                }
            }
            return base.FindElement(by);
        }

        public void clickElement(By by)
        {
            highlighter highlight = new highlighter() { b = this, by = by };
            highlight.On();
            FindElement(by).Click();
            highlight.Off();
        }

        public void typeIntoElement(By by, string text)
        {
            highlighter highlight = new highlighter() { b = this, by = by };
            highlight.On();
            IWebElement e = FindElement(by);
            System.Threading.Thread.Sleep(500);
            e.SendKeys(text);
            System.Threading.Thread.Sleep(100); // kinda important
            highlight.Off();
        }

        public void typeIntoElement(IWebElement e, string text)
        {
            e.SendKeys(text);
            System.Threading.Thread.Sleep(100); // kinda important
        }

        public void screenshot(String prefix = "", String suffix = null)
        {   // save a screenshot as jpg. calling this while passing nothing will result in a (generally) unique save name, based on time.
            if (suffix == null)
            {
                suffix = DateTime.Now.ToString("yyyyMMddHHmmssfff");  // string representing today up to millisecond resolution //https://stackoverflow.com/questions/3025361/c-sharp-datetime-to-yyyymmddhhmmss-format
            }
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)this;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(prefix + suffix + ".jpg", ImageFormat.Jpeg);
        }

        public class globalVariables
        {
            public void On()
            {
                b.executeJavaScript(js.setupGlobalVariables);
            }

            public BetterChrome b { get; set; }
            private String prefix = "auto_";
        }

        public class clickIntercept
        {
            public void On()
            {
                this.globalVars = new globalVariables() { b = b };
                this.globalVars.On();
                Console.Write("loaded global variables into browser!");

                // so far will only intercept clicks on text inputs, password inputs, and textarea inputs.
                b.executeJavaScript(js.setupClickIntercept);

                // init dialog boxes
                b.executeJavaScript(js.initDialogs);
            }

            public void Off()
            {
                b.executeJavaScript(js.teardownClickIntercept);
            }

            public string getTypedKeys()
            {   //fails (returns null or "" even when the browser variable is correctly set)
                return (string)b.executeJavaScript(js.getTypedKeys); // this returns nothing??
            }

            public void removeWaitDialog()
            { // call after typing into the desired element
                b.executeJavaScript(js.removeWaitDialog);
            }

            public string getClickedElementCss()
            {
                IWebElement e = (IWebElement)b.executeJavaScript(js.getClickedElement);
                return (string)b.executeJavaScript(js.getCssSelector, e);
            }

            public bool inputIsPresent()
            {
                //return b.FindElements(By.CssSelector('#' + prefix + "waitDialog")).Count() > 0;
                return b.FindElementsById(prefix + "waitDialogIsOpen").Count() > 0;
            }

            public BetterChrome b { get; set; }
            private String prefix = "auto_";
            private globalVariables globalVars { get; set; }
        }

        public class jQuery
        {
            public void load()
            {
                // http://sqa.stackexchange.com/questions/2921/webdriver-can-i-inject-a-jquery-script-for-a-page-that-isnt-using-jquery
                // give jQuery time to load asynchronously
                b.Manage().Timeouts().SetScriptTimeout(new TimeSpan(0, 0, 1));
                b.executeJavaScript(js.jQueryLoader);
                load_ui();
            }

            private void load_ui()
            {
                // need to find a better way to do this
                // might load jQueryUI into a page which already references it
                // make check if jQueryUI == undefined (like above)
                b.Manage().Timeouts().SetScriptTimeout(new TimeSpan(0, 0, 1));
                b.executeJavaScript(js.loadJQueryUI);
            }

            public BetterChrome b { get; set; }
        }

        private class highlighter
        {
            public highlighter()
            {
                this.stylesheet = new Stylesheet();
            }

            public void On()
            {
                if (String.IsNullOrEmpty(this.elementStyle))
                {
                    this.elementStyle = getElementStyle();
                }
                highlightElement();

            }

            public void Off()
            {
                unhighlightElement();
            }

            private void highlightElement()
            {
                IWebElement e = b.FindElement(by);
                b.executeJavaScript(js.highlightElement, e, stylesheet.Get(Style.HighlightYellow));
            }

            private void unhighlightElement()
            {
                IWebElement e = b.FindElement(by);
                b.executeJavaScript(js.unhighlightElement, e, elementStyle);
            }

            private string getElementStyle()
            {
                IWebElement e = b.FindElement(by);
                return (String)b.executeJavaScript(js.getElementStyle, e);
            }

            public BetterChrome b { get; set; }
            public By by { get; set; }
            private string elementStyle { get; set; }
            private Stylesheet stylesheet { get; set; }
        }

        public clickIntercept clickIntercepter { get; set; }
        public jQuery jquery { get; set; }
        public globalVariables globalVars { get; set; }
    }
}
