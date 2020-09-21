// Desenvolvido por: Izack G. Passos Rodrigues - Setembro/2020
// O objetivo do teste é validar tentativa de login sem dados de usuário.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class Ct01AccessFailTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  public string baseUrl = "https://mantis-prova.base2.com.br/";

    [SetUp]
  public void SetUp() {

    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
    
    }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void ct01AccessFail() {
    driver.Navigate().GoToUrl(baseUrl + "/login_page.php");
    driver.Manage().Window.Maximize();
    var UserName = driver.FindElements(By.Name("username"));
    Assert.True(UserName.Count > 0);
    var UserPass = driver.FindElements(By.Name("password"));
    Assert.True(UserPass.Count > 0);
    var LoginButton = driver.FindElements(By.CssSelector(".button"));
    Assert.True(LoginButton.Count > 0);
    driver.FindElement(By.CssSelector(".button")).Click();
    Assert.That(driver.FindElement(By.CssSelector("font")).Text, Is.EqualTo("Your account may be disabled or blocked or the username/password you entered is incorrect."));

        Thread.Sleep(2000);
        driver.Quit();
  }
}
