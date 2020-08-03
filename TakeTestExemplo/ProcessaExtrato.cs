using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Comissoes
{
    [TestClass]
    public class ProcessaExtrato
    {
        public ProcessaExtrato()
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

            #region Processar Extrato
            driver.FindElement(By.Id("botaoMenu")).Click();
            driver.FindElement(By.CssSelector("div:nth-child(3) > .menu > .menu-item:nth-child(9) > .menu-span > .ng-binding")).Click();
            driver.FindElement(By.CssSelector(".menu-item:nth-child(9) > .expandida > .menu > .menu-item:nth-child(3) > .menu-span > .ng-binding")).Click();
            driver.FindElement(By.CssSelector(".menu-item:nth-child(3) .menu-item:nth-child(3) .ng-binding")).Click();
            driver.FindElement(By.Id("comboundefined")).Click();
            driver.FindElement(By.Id("comboundefined")).SendKeys("bradesco");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.Name("frmAutoFormbaixaExtratoProcessamentoundefined_edt_corretora")).Click();
            driver.FindElement(By.Name("frmAutoFormbaixaExtratoProcessamentoundefined_edt_corretora")).SendKeys("matriz");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.CssSelector(".btn-default")).Click();
            {
                var element = driver.FindElement(By.XPath("/html/body/div[7]/div[2]/button[1]"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.CssSelector(".confirm")).Click();
            driver.FindElement(By.CssSelector(".btn-default:nth-child(1)")).Click();
            #endregion
        }
    }
}
