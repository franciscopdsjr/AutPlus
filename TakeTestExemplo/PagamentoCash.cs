﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Cash
{
    [TestClass]
    public class PagamentoCash
    {
        public PagamentoCash()
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

            #region Pagamento Cash
            driver.FindElement(By.Id("botaoMenu")).Click();
            driver.FindElement(By.LinkText("Cash Flow")).Click();
            driver.FindElement(By.CssSelector("div:nth-child(3) > .menu > .menu-item:nth-child(17) > .expandida > .menu > .menu-item:nth-child(1) .ng-binding")).Click();
            js.ExecuteScript("window.scroll(0,0)");
            driver.FindElement(By.CssSelector(".btn-raised")).Click();
            driver.FindElement(By.LinkText("VIRTUAL")).Click();
            driver.FindElement(By.Name("frmAutoFormcashFlowLancamentosFinanceirosundefined_edt_cta_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormcashFlowLancamentosFinanceirosundefined_edt_cta_codigo")).SendKeys("conta bb");
            driver.FindElement(By.LinkText("CONTA BB")).Click();
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            driver.FindElement(By.CssSelector(".card-botoes > .btn:nth-child(1)")).Click();
            driver.FindElement(By.CssSelector(".clearfix > .btn-default")).Click();
            driver.FindElement(By.CssSelector(".col-lg-6:nth-child(1) > .ng-pristine .form-control")).Click();
            driver.FindElement(By.CssSelector(".col-md-6:nth-child(1)")).Click();
            driver.FindElement(By.CssSelector(".col-md-6:nth-child(1)")).SendKeys("200");
            driver.FindElement(By.CssSelector(".col-lg-6:nth-child(3) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".col-lg-6:nth-child(3) #comboundefined")).SendKeys("agua");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.CssSelector(".col-lg-6:nth-child(4) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".col-lg-6:nth-child(4) #comboundefined")).SendKeys("francisco");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            #endregion
        }
    }
}