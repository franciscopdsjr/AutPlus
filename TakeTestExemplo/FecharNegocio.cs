﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace CentralDeNegocios
{
    [TestClass]
    public class FecharNegocio
    {
        [TestMethod]
        public void FechaNegocio()
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
                //builder.MoveToElement(elemento).Release().Perform();
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
            //Buscando negocio cadastrado hoje
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector(".zmdi-case:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".col-xs-12:nth-child(1) .col-xs-4:nth-child(2) .form-control")).Click();
            driver.FindElement(By.CssSelector(".today")).Click();
            driver.FindElement(By.CssSelector(".col-xs-12:nth-child(1) .col-xs-4:nth-child(3) .form-control")).Click();
            driver.FindElement(By.CssSelector(".today")).Click();
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div.row > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral.col-menu-vert-11 > div:nth-child(1) > div:nth-child(2) > div > div > div > button")).Click();
            //Clicar no negocio que sera fechado
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector("tbody > tr > td:nth-child(1) > button > i")).Click();
            
            //Fechar negocio
            driver.FindElement(By.LinkText("Fechar negócio")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector("div:nth-child(73) > div.sweet-alert.show-sweet-alert.visible > button.confirm")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.Name("frmAutoFormfecharNegocioundefined_edt_cn_orc_inicio_vigencia")).Click();
            driver.FindElement(By.CssSelector(".today")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            
            driver.FindElement(By.Name("frmAutoFormfecharNegocioundefined_edt_cia_codigo")).Click();
            driver.FindElement(By.LinkText("ALFA")).Click();

            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div.row > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral.col-menu-vert-11 > div:nth-child(5) > div.botoes-bottom.botoes-bottom-calcular-todas.ng-scope > div > div > button")).Click();
            #endregion
            //Fecha o navegador
            driver.Quit();
        }
    }
}
