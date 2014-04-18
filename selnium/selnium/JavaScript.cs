using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;

//https://code.google.com/p/selenium/source/browse/ide/main/src/content/recorder.js
// - to look at how 
//

namespace selnium
{
    class JavaScriptFunctions
    {
        private IWebDriver driver { get; set; }
        private String prefix = "auto_";
        private Stylesheet stylesheet = new Stylesheet();

        public void SetDriver(ref IWebDriver driverByRef) {
            // to avoid initializing two drivers, this driver is passed by reference
            driver = driverByRef;
        }

        public void setupGlobalVars()
        {
            String jscript = @"window." + prefix + @"clickedElement = null;
            window." + prefix + @"clickedElementsArray = new Array();
            window." + prefix + @"randomString = 'Shmoop';
            window." + prefix + @"typedKeys = new Array();
            $('input[type=text], input[type=password], textarea').not('#idontknow').unbind('focus').focus(openPrompt);
            $(document).unbind('keydown').keydown(function(e){
                window." + prefix + @"typedKeys.push(e.keyCode);
            });
            function openPrompt() {
                var inputDialog = $('<div id=\'" + prefix + @"inputDialog\'></div>');
                inputDialog.append('<br /><input type=\'text\' id=\'idontknow\' />');
                $('body').append(inputDialog);
                $('#" + prefix + @"inputDialog').dialog({
                    modal: true,
                    buttons: {
                        StupendousButton:function() {
                            window." + prefix + @"typedKeysFull = $('#idontknow').val();
                            openWaitDialog();
                            $(this).dialog('destroy');
                        },
                        Cancel:function() {
                            $(this).dialog('destroy');
                        }
                    }
                });
            };
            function openWaitDialog() {
                var waitDialog = $('<div id=\'" + prefix + @"waitDialog\'>Please Wait...</div>');
                $('body').append(waitDialog);
                $('#" + prefix + @"waitDialog').dialog({
                    modal: true
                });
            };";

            //                $('#" + prefix + @"inputDialog').remove();

            // using the keydown event, not keypress http://stackoverflow.com/questions/4843472/javascript-listener-keypress-doesnt-detect-backspace
            // unbind keydown before binding so that it doesn't get called more than once per key press

            //if(e.keyCode == 13)
            //{
            //    alert('I am the Enter key!');
            //}
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(jscript);
        }

        // loads jquery into head element
        // ( and currently will try to hide google's logo)
        public void jQuery()
        {
            // http://sqa.stackexchange.com/questions/2921/webdriver-can-i-inject-a-jquery-script-for-a-page-that-isnt-using-jquery
            // eventually load this from a file instead. don't want to bother with it now.
            String jQueryLoader = @"(function(jqueryUrl, callback) {
                    if (typeof jqueryUrl != 'string') {
                        jqueryUrl = 'http://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js';
                    }
                    if (typeof jQuery == 'undefined') {
                        var script = document.createElement('script');
                        var head = document.getElementsByTagName('head')[0];
                        var done = false;
                        script.onload = script.onreadystatechange = (function() {
                            if (!done && (!this.readyState || this.readyState == 'loaded' 
                                    || this.readyState == 'complete')) {
                                done = true;
                                script.onload = script.onreadystatechange = null;
                                head.removeChild(script);
                                callback();
                            }
                        });
                        script.src = jqueryUrl;
                        head.appendChild(script);
                    }
                    else {
                        callback();
                    }
                })(arguments[0], arguments[arguments.length - 1]);";
            
            // give jQuery time to load asynchronously
            driver.Manage().Timeouts().SetScriptTimeout(new TimeSpan(0, 0, 10));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteAsyncScript(jQueryLoader);
        }

        public void jQueryUI()
        {
            // need to find a better way to do this
            // might load jQueryUI into a page which already references it
            // make check if jQueryUI == undefined (like above)
            String jscript = @"var scriptElt = document.createElement('script');
            scriptElt.type = 'text/javascript';
            scriptElt.src = 'http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/jquery-ui.min.js';
            var head = document.getElementsByTagName('head')[0];
            head.appendChild(scriptElt);
            head.innerHTML = head.innerHTML + '<link rel=\'stylesheet\' href=\'http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/themes/smoothness/jquery-ui.css\' />';";

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(jscript);
        }


        public bool userHasClicked()
        {
            return true;
            // repurpose to check new variable
            String jscript = @"return window." + prefix + "clickedElementsArray != undefined && window." + prefix + @"clickedElementsArray != null && window." + prefix + @"clickedElementsArray.length == 0;";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;// When you navigate to a new page unexpectedly, (and global variables are not setup) this jscript will throw an error.
            return !((bool)js.ExecuteScript(jscript)); //unknown error: Cannot read property 'length' of undefined
        }

        public List<IWebElement> getStoredClickedElements()   // for each of these methods, we'll need to check for == undefined, 
        {                                                     // and return an empty array (or other acceptable response) if True
            return null;
            // repurpose to get element from jquery dialog box
            List<IWebElement> temp = new List<IWebElement>();

            String jscript = @"if (window." + prefix + @"clickedElementsArray == undefined) {
                    return new Array();
                    }
                return window." + prefix + @"clickedElementsArray";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var response = js.ExecuteScript(jscript);

            foreach (IWebElement element in (IEnumerable)response)
            {
                temp.Add(element);
            }

            return temp;
        }


        //https://stackoverflow.com/questions/2068272/getting-a-jquery-selector-for-an-element
        //http://paste.blixt.org/297640
        public string getCssSelector(IWebElement e)
        {  // i have arguments[0] in place of this
            string jscript = @"jQuery.fn.getPath = function () {
                if (this.length != 1) throw 'Requires one element.';

                var path, node = this;
                while (node.length) {
                    var realNode = node[0], name = realNode.localName;
                    if (!name) break;

                    name = name.toLowerCase();
                    if (realNode.id) {
                        // As soon as an id is found, there's no need to specify more.
                        return name + '#' + realNode.id + (path ? '>' + path : '');
                    } else if (realNode.className) {
                        name += '.' + realNode.className.split(/\s+/).join('.');
                    }

                    var parent = node.parent(), siblings = parent.children(name);
                    if (siblings.length > 1) name += ':nth-of-type(' + (siblings.index(node) + 1) + ')';
                    path = name + (path ? '>' + path : '');

                    node = parent;
                }

                return path;
            };
            return $(arguments[0]).getPath();";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return (string)js.ExecuteScript(jscript, e);
        }

        public string getTextTyped()
        {
            return "";
        }

        //if trying to highlight by id, just use #id
        public string highlightElementByCss(string selector)
        {
            IWebElement e = driver.FindElement(By.CssSelector(selector)); //this appears to fail on radio buttons (maybe more)
            // html>body>form>p:eq(1)>input:eq(1)     -> looks right, but is it valid?
            string jscript = "var o = $(arguments[0]);"
                + "var pastStyle = o.attr('style');"
                + "o.addClass('element-highlight');"
                + "o.attr('style', arguments[1]);"
                + "return pastStyle;";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string styles = (String)js.ExecuteScript(jscript, e, stylesheet.Get(Style.HighlightYellow));
            return styles;
        }

        public void removeElementHighlightingByCss(string css, string past)
        {
            IWebElement e = driver.FindElement(By.CssSelector(css));
            //'BODY/FORM[1]/P[1]/INPUT[1]'
            //string jscript = "var o = $document.evaluate(\"" + xpath + "\", document, null, 0, null);"
            //    + "o.attr('style', arguments[0]);";
            string jscript = "var o = $(arguments[0]);"
                + "o.attr('style', arguments[1]);";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(jscript, e, past);
        }

        //return true if checkbox or radiobutton is "checked"
        public bool buttonIsChecked(IWebElement e)
        {
            return e.Selected;
        }
    }
}
