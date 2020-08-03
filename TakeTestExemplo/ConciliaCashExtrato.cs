using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;

namespace Cash
{
    /// <summary>
    /// Descrição resumida para ConciliaCashExtrato
    /// </summary>
    [TestClass]
    public class ConciliaCashExtrato
    {
        [TestMethod]
        public void ConciliarCashExtrato()
        {
            #region Abrir o Chrome
            //inicializando o chrome
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://main.safety8.local/#/login?cnpj=72.408.271%2F0001-91");
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(3000);
            #endregion

            #region Login
            var cnpj = driver.FindElement(By.Id("cnpj"));
            cnpj.SendKeys("72408271000191");
            {
                var elemento = driver.FindElement(By.CssSelector(".logo-login-q"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(elemento).ClickAndHold().Perform();
            }
            {
                var elemento = driver.FindElement(By.CssSelector(".efeitoOverlay"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(elemento).Release().Perform();
            }
            driver.FindElement(By.CssSelector(".container-fluid")).Click();
            driver.FindElement(By.CssSelector(".ng-scope > .animated")).Click();
            {
                var dropdown = driver.FindElement(By.CssSelector(".ng-scope > .animated"));
                dropdown.FindElement(By.XPath("/html/body/div[5]/div[2]/div[2]/div/div/div/div/div/div[2]/div[2]/select/option[3]")).Click();
                //driver.Quit();
            }

            driver.FindElement(By.CssSelector(".ng-scope > .animated")).Click();
            driver.FindElement(By.Id("usuario")).Click();
            driver.FindElement(By.Id("usuario")).SendKeys("francisco");
            driver.FindElement(By.Id("senha")).SendKeys("F123456");
            driver.FindElement(By.CssSelector(".button-login-q")).Click();
            #endregion

            #region Cociliação de extrato
            driver.FindElement(By.Id("botaoMenu")).Click();
            driver.FindElement(By.CssSelector("div:nth-child(3) > .menu > .menu-item:nth-child(17) > .menu-span > .zmdi-caret-down")).Click();
            driver.FindElement(By.LinkText("Lançamentos")).Click();
            {
                var element = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[2]/div[2]/div"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.CssSelector(".var_nav:nth-child(2) span")).Click();
            driver.FindElement(By.CssSelector(".ng-isolate-scope:nth-child(1) > .radioCard > span")).Click();
            driver.FindElement(By.Id("comboundefined")).Click();
            driver.FindElement(By.Id("comboundefined")).SendKeys("bradesc");
            driver.FindElement(By.LinkText("BRADESCO")).Click();
            driver.FindElement(By.CssSelector(".btn-flat")).Click();
            driver.FindElement(By.CssSelector(".ng-scope:nth-child(1) > .noPadding .check")).Click();
            driver.FindElement(By.Id("comboundefined")).Click();
            driver.FindElement(By.Id("comboundefined")).SendKeys("conta bb");
            driver.FindElement(By.LinkText("CONTA BB")).Click();
            driver.ExecuteJavaScript("window.scroll(0,1000)");
            driver.FindElement(By.CssSelector(".card-body > .btn")).Click();
            driver.FindElement(By.CssSelector(".btn-flat:nth-child(1)")).Click();
            #endregion
        }
    }
}
