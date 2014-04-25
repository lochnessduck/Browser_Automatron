from selenium import webdriver
from selenium.common.exceptions import NoSuchElementException, StaleElementReferenceException
from selenium.webdriver.common.keys import Keys

b = webdriver.Chrome('C:/selenium/chromedriver.exe')
b.get('http://www.google.com')
jsfile = open('C:/selenium/jquery.min.js')
jqueryLoad = jsfile.read()
jsfile.close()
b.execute_script(jqueryLoad)

def jquery_is_loaded():
    return not b.execute_script("return (typeof jQuery == 'undefined');")

print(jquery_is_loaded())

elements = b.execute_script('return $("#hplogo");')
elements[0].click()
