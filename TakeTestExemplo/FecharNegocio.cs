using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace CentralDeNegocios
{
    /// <summary>
    /// Descrição resumida para FecharNegocio
    /// </summary>
    [TestClass]
    public class FecharNegocio
    {
        public FecharNegocio()
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

            #region Fechar Negocio
            driver.FindElement(By.CssSelector(".zmdi-case:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".col-xs-12:nth-child(1) .col-xs-4:nth-child(2) .form-control")).Click();
            driver.FindElement(By.CssSelector(".today")).Click();
            driver.FindElement(By.CssSelector(".col-xs-4:nth-child(7) .ng-valid-maxlength")).Click();
            driver.FindElement(By.CssSelector(".col-xs-4:nth-child(7) .ng-valid-maxlength")).Click();
            driver.FindElement(By.CssSelector(".col-xs-4:nth-child(7) .ng-valid-maxlength")).Click();
            driver.FindElement(By.CssSelector(".col-xs-4:nth-child(7) .ng-valid-maxlength")).SendKeys(Keys.Up);
            driver.FindElement(By.CssSelector(".col-xs-4:nth-child(7) .ng-valid-maxlength")).SendKeys(Keys.Up);
            driver.FindElement(By.CssSelector(".col-xs-4:nth-child(7) .ng-valid-maxlength")).SendKeys(Keys.Up);
            driver.FindElement(By.CssSelector(".col-xs-4:nth-child(7) .ng-valid-maxlength")).SendKeys(Keys.Up);
            driver.FindElement(By.CssSelector(".col-xs-4:nth-child(7) .ng-valid-maxlength")).SendKeys(Keys.Up);
            driver.FindElement(By.CssSelector(".col-xs-4:nth-child(7) .ng-valid-maxlength")).SendKeys(Keys.Tab);
            driver.FindElement(By.CssSelector(".btn-flat")).Click();
            driver.FindElement(By.CssSelector(".zmdi-search-in-page")).Click();
            driver.FindElement(By.LinkText("Fechar negócio")).Click();
            driver.FindElement(By.CssSelector(".confirm")).Click();
            driver.FindElement(By.CssSelector(".btn-flat")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".btn-flat"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            {
                var element = driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            driver.FindElement(By.CssSelector(".confirm")).Click();
            driver.FindElement(By.Name("frmAutoFormfecharNegocioundefined_edt_cn_orc_inicio_vigencia")).Click();
            driver.FindElement(By.CssSelector(".today")).Click();
            driver.FindElement(By.CssSelector(".paddingCard:nth-child(2)")).Click();
            driver.FindElement(By.Name("frmAutoFormfecharNegocioundefined_edt_cia_codigo")).Click();
            driver.FindElement(By.LinkText("ALFA")).Click();
            driver.FindElement(By.CssSelector(".paddingCard:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".btn-flat")).Click();
            driver.FindElement(By.CssSelector(".btn-raised")).Click();
            driver.FindElement(By.CssSelector(".btn-raised")).Click();
            #endregion
        }
    }
}
