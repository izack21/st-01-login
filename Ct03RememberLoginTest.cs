// Desenvolvido por: Izack G. Passos Rodrigues - Setembro/2020
// O objetivo do teste é validar o funcionamento do check-box para 
// gravação dos dados de login do usuário.


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
public class Ct03RememberLoginTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
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
  public void ct03RememberLogin() {
    driver.Navigate().GoToUrl("https://mantis-prova.base2.com.br/login_page.php");
    driver.Manage().Window.Size = new System.Drawing.Size(1382, 754);
    driver.FindElement(By.Name("username")).Click();
    driver.FindElement(By.Name("username")).SendKeys("izack.rodrigues");
    driver.FindElement(By.Name("password")).Click();
    driver.FindElement(By.Name("password")).SendKeys("Teste@19");
    driver.FindElement(By.Name("perm_login")).Click();
    driver.FindElement(By.CssSelector(".button")).Click();
    driver.FindElement(By.LinkText("Logout")).Click();
    {
      string value = driver.FindElement(By.Name("username")).GetAttribute("value");
      Assert.That(value, Is.EqualTo("izack.rodrigues"));
    }
    {
      string value = driver.FindElement(By.Name("password")).GetAttribute("value");
      Assert.That(value, Is.EqualTo("Biscoitos19"));
    }
  }
}
