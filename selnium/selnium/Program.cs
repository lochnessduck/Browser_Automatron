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
     * monitor for change in URL w/o any click
     * load jquery from c:\monkeydo\
     * call JavaScript.scroll_into_view(), looks like it wasn't being called before
     * LANCE: Look at available Selenium IDE plugins, find a way to make Selenium IDE export current browser activity (as a way to use the IDE for recording actions, rather than rolling our own solution)
     * LANCE: finish making xpath work - use xpath in getting elements from browser.
     * ANGELA: Research keypress vs keydown. Need to log all keys, but need to get case sensitivity. Also fix problem with some key presses not getting logged by javascript. http://www.mkyong.com/jquery/jquery-keyboard-events-example/ http://stackoverflow.com/questions/8071415/how-to-efficiently-record-user-typing-using-javascript Answer #2 has a good point... user can click to move cursor and keep typing...
     * ANGELA: GUI
     * Lance: make Css selectors work (or troubleshoot why css generator fails) - note that it worked when sending keys to the input  DONE :D
     * LANCE: alter the rules and pray it is not altered further
     * Lance: change all functions that return window variables to return default values if window.variable == undefined
     * I really like the idea of having the user type what they want in the browser in a separate pop-up that we supply.
     *     -prevents us from having to capture keystrokes
     * LANCE - finish cleaning up code so that keystrokes are gathered and "please wait..." window is 
     * removed after the user has entered some input
     * SPRING CLEANING!!! ( setup click intercept in BetterChrome )
     * LANCE  - get b.executeJavaScript to work (it fails when trying to return a value (aside from null))
     * ANGELA - Fix the dialog closing bug
     */

    class Program
    {
        
        BetterChrome driver = new BetterChrome(@"C:\selenium\");  //ChromeDriver(@"C:\selenium\");
        JavaScriptFunctions JavaScript = new JavaScriptFunctions();
        GUI form = new GUI();
        Stylesheet stylesheet = new Stylesheet();
        List<IWebElement> toBeClicked = new List<IWebElement>();
        String lastClickedElementID = null;
        String lastClickedElementCss = null;
        List<object> allActions = new List<object>(); // a list to keep order of elements clicked and elements typed into

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
            driver.Url = "file:///C:/selenium/theform.html";
            driver.Navigate();
            string prefix  ="auto_";
            while (true)
            {
                if (driver.clickIntercepter.inputIsPresent())
                {
                    string keys = driver.clickIntercepter.getTypedKeys();
                    Console.Write("someone type: " + keys);
                    driver.typeIntoElement(driver.clickIntercepter.getClickedElement(), keys);
                    driver.clickIntercepter.removeWaitDialog();
                    Thread.Sleep(1000);
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
            //Application.Run(form);  // seems to block parallel application execution
            //form.Show();
            

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
    }
}