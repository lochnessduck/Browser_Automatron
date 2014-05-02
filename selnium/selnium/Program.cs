using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections;
using System.Windows.Forms;


namespace selnium
{

    /* TODO
     * LANCE: change all functions that return window variables to return default values if window.variable == undefined
     * LANCE - finish cleaning up code so that keystrokes are gathered and "please wait..." window is 
     * removed after the user has entered some input
     * LANCE  - get b.executeJavaScript to work (it fails when trying to return a value (aside from null)) (maybe asyncscript doesn't work)
     */

    class Program
    {
        
        BetterChrome driver = new BetterChrome(@"C:\selenium\");  //ChromeDriver(@"C:\selenium\");
        JavaScriptFunctions JavaScript = new JavaScriptFunctions();
        GUI form = new GUI();
        Stylesheet stylesheet = new Stylesheet();
        List<IWebElement> toBeClicked = new List<IWebElement>();
        List<UserInput> timeOrderedUserInput = new List<UserInput>(); // records set of strings typed into browser, in order of typing.
        List<UserInput> previouslyPlayedUserActions = new List<UserInput>();

        static void Main(string[] args)
        {
            Program p = new Program();
            p.TestMain();
        }

        public void ThreadProc()
        {
            Application.Run(new GUI());
        }

        public void TestMain()
        {
            //Application.Run(form);  // seems to block parallel application execution
            ////form.SetDriver(driver);
            //form.Show();

            driver.Url = "file:///C:/selenium/theform.html";
            //driver.Navigate();
            driver.navigateAndLoadJquery();
            string prefix  ="auto_";
            while (false)
            {
                if (driver.clickIntercepter.inputIsPresent())
                {
                    // when global variables are setup, js.setupClickIntercept sets up where clickedElement will be recorded,
                    // and js.initDialogs sets up where user-typed input from the popup UI will be recorded
                    string text = driver.clickIntercepter.getTypedKeys();
                    string css = driver.clickIntercepter.getClickedElementCss();
                    UserInput input = new UserInput() {css=css, text=text};
                    timeOrderedUserInput.Add(input);
                    Console.Write("someone type: " + input.text);
                    driver.clickIntercepter.Off(); // may be unnecessary
                    driver.typeIntoElement(By.CssSelector(input.css), input.text);
                    driver.clickIntercepter.removeWaitDialog();
                    Thread.Sleep(10);
                    driver.clickIntercepter.On();
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.Write("nope    ");
                }
            }
            //driver.executeJavaScript("$('textarea').hide()");   //THIS SEEMS TO WORK ... but then it also causes an error saying '$' not found in the system (or something like that)
            //System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
            //t.Start();
            //Thread.Sleep(100000000);
            
            

            //while (true)
            //{
            //    List<Int64> typed = JavaScript.getKeysTyped();
            //    JavaScript.clearKeysTyped();  // so if user types before having clicked anything, this will auto-clear until user has clicked something first before typing.
            //    //if (typed.Any() && lastClickedElementID != null)
            //    if (typed.Any() && lastClickedElementCss != null)
            //    {
            //        Tuple<List<Int64>, String> couple = new Tuple<List<Int64>, String>(typed, lastClickedElementCss);
            //        allActions.Add(couple);
            //    }
            //    if (JavaScript.userHasClicked()) {
            //        Console.WriteLine("something has been clicked!");
            //        toBeClicked = JavaScript.getStoredClickedElements();
            //        JavaScript.resetClickedArray();
                    
            //        if (toBeClicked.Count() > 0)
            //        {
            //            foreach (IWebElement element in toBeClicked)
            //            {
            //                Console.Write("3.. ");
            //                Thread.Sleep(500);
            //                Console.Write("2.. ");
            //                Thread.Sleep(500);
            //                Console.WriteLine("1..");
            //                Thread.Sleep(500);
            //                comprehensiveClick(element);
            //                Console.WriteLine("something has been clicked!");
            //            }
            //        }
            //    }
            
        }

        //highlights element, clicks, and then removes highlighting. Then sets up global variable
        //and click intercept
        //public void comprehensiveClick(IWebElement element)
        //{
        //    JavaScript.removeClickIntercept();
        //    String id = element.GetAttribute("id");
        //    //String xpath = JavaScript.getXPath(element);
        //    string css = JavaScript.getCssSelector(element);  // this works! From now on we should just use the Css Selector
        //    lastClickedElementID = id;
        //    lastClickedElementCss = css;
        //    allActions.Add(css);
        //    //string past = JavaScript.highlightElementById(id);
        //    string past = JavaScript.highlightElementByCss(css);
        //    //take_screenshot();
        //    JavaScript.clickViaJS(element); //element.Click();  // change to click via xpath
        //    //JavaScript.removeElementHighlighting(id, past);
        //    JavaScript.removeElementHighlightingByCss(css, past);
        //    JavaScript.resetClickedArray();
        //    JavaScript.setupGlobalVars();
        //    //JavaScript.setupClickIntercept();
        //}

        // searches google for "strings galore!"
        //public void search_google()
        //{
        //    IWebElement e = driver.FindElement(By.Name("q"));
        //    e.SendKeys("strings galore!");
        //    e.SendKeys(OpenQA.Selenium.Keys.Enter);
        //}

        // NOT IMPLEMENTED
        //public void load_jquery()  //https://sqa.stackexchange.com/questions/2921/webdriver-can-i-inject-a-jquery-script-for-a-page-that-isnt-using-jquery
        //{
        //    driver.Url = "filename to jquery";
        //    driver.Navigate();
        //}

        // uses a CSS selector to grab and element, and types text (t) into it.
        // if searching by id, pass '#id'
        //public void typeIntoBoxById(String selector, String t)
        //{
        //    IWebElement e = driver.FindElement(By.CssSelector(selector));
        //    String id = e.GetAttribute("id");
        //    String pastStyle = JavaScript.highlightElementById(id);
        //    System.Threading.Thread.Sleep(500);
        //    driver.FindElement(By.CssSelector(selector)).SendKeys(t);
        //    System.Threading.Thread.Sleep(100);
        //    JavaScript.removeElementHighlighting(id, pastStyle);
        //}

        public void Playback(int pauseBetweenActions)
        {
            //foreach (UserInput input in timeOrderedUserInput)
            while (timeOrderedUserInput.Count > 0)
            {
                UserInput input = timeOrderedUserInput.ElementAt(0);
                timeOrderedUserInput.RemoveAt(0);
                previouslyPlayedUserActions.Add(input);
                driver.typeIntoElement(By.CssSelector(input.css), input.text);
                System.Threading.Thread.Sleep(pauseBetweenActions);  // in milliseconds
                // check for pause condition here. if so, break
            }
        }

        public void reloadUserActionsListFromBeginning()
        {
            timeOrderedUserInput = (List<UserInput>)previouslyPlayedUserActions.Concat(timeOrderedUserInput);
            previouslyPlayedUserActions.Clear();
        }
    }

    class UserInput
    {
        public string css { get; set; }
        public string text { get; set; }
    }
}