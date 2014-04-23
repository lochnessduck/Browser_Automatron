
class js:
    prefix = "auto_"

    #http://ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js
    jQueryLoader = """(function(jqueryUrl, callback) {
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
                            callback();  // these calls to callback supposedly are correct for finishing the async call...
                        }
                    })(arguments[0], arguments[arguments.length - 1]);
                    return true;
                    """
					
    bruteForceLoadJQuery = """
                            """
                    
    isJQueryLoaded = """if (typeof jQuery == 'undefined') {  
                        return false; // jQuery is not loaded
                    } else {
                        return true;  // jQuery is loaded
                    }"""
                    
    loadJQueryIfNotLoaded = """if (!window.jQuery) {
                              var jq = document.createElement('script'); jq.type = 'text/javascript';
                              // Path to jquery.js file, eg. Google hosted version
                              jq.src = 'file://c:/selenium/jquery.min.js';
                              document.getElementsByTagName('head')[0].appendChild(jq);
                            }"""
                    
    hideElement = "$(arguments[0]).hide()"

    loadJQueryUI = """var scriptElt = document.createElement('script');
                    scriptElt.type = 'text/javascript';
                    scriptElt.src = 'http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/jquery-ui.min.js';
                    var head = document.getElementsByTagName('head')[0];
                    head.appendChild(scriptElt);
                    head.innerHTML = head.innerHTML + '<link rel=\'stylesheet\' href=\'http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/themes/smoothness/jquery-ui.css\' />';";
                    """

    setupClickIntercept = ("""$('input[type=text], input[type=password], textarea').not('#idontknow').unbind('focus').focus(function() {
                                window.""" + prefix + """clickedElement = $(this);
                                $(this).blur(); // super important to remove the focus from the input, otherwise focus will be returned to the input once the dialog is closed and the click intercepted again
                                openPrompt();
                            });
                            function openPrompt() {
                                $('#""" + prefix + """inputDialog').dialog('open');
                            };
                            """)

    teardownClickIntercept = "$('input[type=text], input[type=password], textarea').unbind('focus');"

    setupGlobalVariables = ("window." + prefix + "clickedElement = null;"
                            + "window." + prefix + "clickedElement = null;"
                            + "window." + prefix + "randomString = 'Shmoop';"
                            + "window." + prefix + "typedKeys = '';")

    getTypedKeys = "return window." + prefix + "typedKeys;"

    removeWaitDialog = "$('#" + prefix + "waitDialog').dialog('close');"

    getClickedElement = "return window." + prefix + "clickedElement;"

    highlightElement = ("var o = $(arguments[0]);"
                        + "o.addClass('element-highlight');"
                        + "o.attr('style', arguments[1]);")

    unhighlightElement = ("var o = $(arguments[0]);"
                                            + "o.attr('style', arguments[1]);")

    getElementStyle = ("var o = $(arguments[0]);"
                        + "var pastStyle = o.attr('style');"
                        + "return pastStyle;")

    initDialogs = ("var inputDialog = $('<div id=\'" + prefix + """inputDialog\'></div>');
                    inputDialog.append('<br /><input type=\'text\' id=\'idontknow\' />');
                    $('body').append(inputDialog);
                    $('#""" + prefix + """inputDialog').dialog({
                        modal: true,
                        autoOpen: false,
                        buttons: {
                            StupendousButton:function() {
                                window.""" + prefix + """typedKeys = $('#idontknow').val();
                                console.log(window.""" + prefix + """typedKeys);
                                $(this).dialog('close');
                                $('#""" + prefix + """waitDialog').dialog('open');
                                $('#""" + prefix + """waitDialog').append('<div id=\'""" + prefix + """waitDialogIsOpen\'></div>');
                            },
                            Cancel:function() {
                                $(this).dialog('close');
                            }
                        },
                        open:function() {
                            $('.ui-widget-overlay').css('background-image', 'none');
                        }
                    });

                    var waitDialog = $('<div id=\'""" + prefix + """waitDialog\'>Please Wait...</div>');
                    $('body').append(waitDialog);
                    $('#""" + prefix + """waitDialog').dialog({
                        modal: true,
                        autoOpen: false,
                        open:function() {
                            $('.ui-widget-overlay').css('background-image', 'none');
                        },
                        close:function() {
                            $('#""" + prefix + """waitDialogIsOpen').remove();
                        }
                    });""")

    getCssSelector = """jQuery.fn.getPath = function () {
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
                    return $(arguments[0]).getPath();"""
					
