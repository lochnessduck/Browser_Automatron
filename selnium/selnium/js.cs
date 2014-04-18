using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace selnium
{
    class js
    {
        static string prefix = "auto_";

        //http://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js
        public static string jQueryLoader = @"(function(jqueryUrl, callback) {
                                                if (typeof jqueryUrl != 'string') {
                                                    jqueryUrl = 'file:///C:/selenium/jquery.min.js';
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

        public static string loadJQueryUI = @"var scriptElt = document.createElement('script');
                                            scriptElt.type = 'text/javascript';
                                            scriptElt.src = 'http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/jquery-ui.min.js';
                                            var head = document.getElementsByTagName('head')[0];
                                            head.appendChild(scriptElt);
                                            head.innerHTML = head.innerHTML + '<link rel=\'stylesheet\' href=\'http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/themes/smoothness/jquery-ui.css\' />';";

        public static string setupClickIntercept = @"$('input[type=text], input[type=password], textarea').not('#idontknow').unbind('focus').focus(function() {
                                                        window." + prefix + @"clickedElement = $(this);
                                                        $(this).blur(); // super important to remove the focus from the input, otherwise focus will be returned to the input once the dialog is closed and the click intercepted again
                                                        openPrompt();
                                                    });
                                                    function openPrompt() {
                                                        $('#" + prefix + @"inputDialog').dialog('open');
                                                    };";

        public static string teardownClickIntercept = @"$('input[type=text], input[type=password], textarea').unbind('focus');";

        public static string setupGlobalVariables = @"window." + prefix + @"clickedElement = null;
                                                    window." + prefix + @"clickedElement = null;
                                                    window." + prefix + @"randomString = 'Shmoop';
                                                    window." + prefix + @"typedKeys = '';";

        public static string getTypedKeys = "return window." + prefix + @"typedKeys;";

        public static string removeWaitDialog = "$('#" + prefix + @"waitDialog').dialog('close');";

        public static string getClickedElement = "return window." + prefix + "clickedElement;";

        public static string highlightElement = "var o = $(arguments[0]);"
                                                + "o.addClass('element-highlight');"
                                                + "o.attr('style', arguments[1]);";

        public static string unhighlightElement = "var o = $(arguments[0]);"
                                                + "o.attr('style', arguments[1]);";

        public static string getElementStyle = "var o = $(arguments[0]);"
                                                + "var pastStyle = o.attr('style');"
                                                + "return pastStyle;";

        public static string initDialogs = @"var inputDialog = $('<div id=\'" + prefix + @"inputDialog\'></div>');
                                            inputDialog.append('<br /><input type=\'text\' id=\'idontknow\' />');
                                            $('body').append(inputDialog);
                                            $('#" + prefix + @"inputDialog').dialog({
                                                modal: true,
                                                autoOpen: false,
                                                buttons: {
                                                    StupendousButton:function() {
                                                        window." + prefix + @"typedKeys = $('#idontknow').val();
                                                        console.log(window." + prefix + @"typedKeys);
                                                        $(this).dialog('close');
                                                        $('#" + prefix + @"waitDialog').dialog('open');
                                                        $('#" + prefix + @"waitDialog').append('<div id=\'" + prefix + @"waitDialogIsOpen\'></div>');
                                                    },
                                                    Cancel:function() {
                                                        $(this).dialog('close');
                                                    }
                                                },
                                                open:function() {
                                                    $('.ui-widget-overlay').css('background-image', 'none');
                                                }
                                            });

                                            var waitDialog = $('<div id=\'" + prefix + @"waitDialog\'>Please Wait...</div>');
                                            $('body').append(waitDialog);
                                            $('#" + prefix + @"waitDialog').dialog({
                                                modal: true,
                                                autoOpen: false,
                                                open:function() {
                                                    $('.ui-widget-overlay').css('background-image', 'none');
                                                },
                                                close:function() {
                                                    $('#" + prefix + @"waitDialogIsOpen').remove();
                                                }
                                            });";
    }
}
