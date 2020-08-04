﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;

namespace Automacao
{
    [TestClass]
    public class AutomacaoComissao
    {
        [TestMethod]
        public void AutomacaoDeComissao()
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

            #region Automação de comissão
            driver.FindElement(By.CssSelector(".icon-receipt:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".logoNormal:nth-child(10) .col-xs-10")).Click();
            driver.FindElement(By.Id("comboundefined")).Click();
            driver.FindElement(By.Id("comboundefined")).SendKeys("matriz");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.CssSelector(".btn-success:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".ng-scope:nth-child(1) > td .check")).Click();
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            driver.ExecuteJavaScript("window.scrollTo(0,0)");
            driver.FindElement(By.CssSelector(".ngdialog-overlay")).Click();
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            #endregion
        }
    }
}