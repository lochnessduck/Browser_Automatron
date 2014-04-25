from __future__ import print_function
from selenium.webdriver import Chrome
from js import js  # from module js (js.py) import class js.


class BetterChrome(Chrome):

    def __init__(self, *args):
        super(BetterChrome, self).__init__(*args)

    def get(self, url):
        print('getting url:', url)
        super(BetterChrome, self).get(url)

    def load_jquery(self, filename="C:/selenium/jquery.min.js"):
        jqfile = open(filename, 'r')
        jqueryLoad = jqfile.read()
        jqfile.close()
        self.execute_script(jqueryLoad)
    


def pycallback():
    return True

if __name__ == "__main__":
    b = BetterChrome('C:/selenium/chromedriver.exe')
    b.get('http://www.google.com')
    
    #b.set_script_timeout(5)  # apparently loading jquery requires a page
                                # load timeout AND async script execution
    #b.execute_async_script(js.jQueryLoader)
    b.load_jquery()
    print(b.execute_script(js.isJQueryLoaded))  # finally says True
    #b.execute_script(js.loadJQueryIfNotLoaded)
    #print(b.execute_script(js.isJQueryLoaded))
    e = b.find_element_by_id('hplogo')
    b.execute_script(js.hideElement, e)
    css = b.execute_script(js.getCssSelector, e)
