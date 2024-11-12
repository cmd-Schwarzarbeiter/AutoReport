using static System.Net.Mime.MediaTypeNames;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

//Infos: https://www.toolsqa.com/selenium-c-sharp/


/*
IWebDriver EdgeDriver = new EdgeDriver();

EdgeDriver.Url = "https://de.wikipedia.org";
EdgeDriver.Manage().Window.Maximize();
//EdgeDriver.Manage().Timeouts().ImplicitWait(TimeSpan.FromSeconds(10));
Thread.Sleep(1000);

//try!!!!!
EdgeDriver.FindElement(By.Name("search")).SendKeys("Bitcoin" + OpenQA.Selenium.Keys.Enter);
//EdgeDriver.FindElement(By.Name("search")).SendKeys("Bitcoin" + Keys.Enter);
Thread.Sleep(1000);
//EdgeDriver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div/div/div/div/div[1]/div/span/a/h3")).Click();
Thread.Sleep(1000);
*/








/*
(By.Id("submit")
(By.Name("firstname")
(By.TagName("button"))
(By.XPath("Element XPATHEXPRESSION"))



IWebElement parentElement = driver.FindElement(By.ClassName("button"));
	IWebElement childElement = parentElement.FindElement(By.Id("submit"));
	childElement.Submit();



IWebElement element = driver.FindElement(By.LinkText("Partial Link Test"));
	element.Clear();

	//Or can be identified as 
	IWebElement element = driver.FindElement(By.PartialLinkText("Partial");
	element.Clear();



    Console.WriteLine("Succsess!");
//EdgeDriver.FindElement(By.XPath"//*[@data-tab-key").Click();

Thread.Sleep(10000);
//Console.ReadLine();
EdgeDriver.Quit();
    */