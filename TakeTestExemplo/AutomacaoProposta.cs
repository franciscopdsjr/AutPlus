﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;

namespace Automacao
{
    [TestClass]
    public class AutomacaoProposta
    {
        [TestMethod]
        public void AutomacaoDeProposta()
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

            #region Automacao de Proposta
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            //Seleciona Automação
            driver.FindElement(By.CssSelector(".icon-file-empty:nth-child(2)")).Click();
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            //Seleciona a Cia
            driver.FindElement(By.CssSelector("div:nth-child(4) > div > div.col-xs-10")).Click();
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            //Desmarcar
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div > div:nth-child(4) > div > div.clearfix.card-header.bg-card-teal > div > spam:nth-child(2)")).Click();
            driver.ExecuteJavaScript("window.scrollTo(0,1000)");
            //Marcar somente um
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div > div:nth-child(4) > div > div.card-body.card-padding.row.scroll-arquivos > div > div:nth-child(2) > table > tbody > tr:nth-child(1) > td:nth-child(1) > vs-editavel3 > div > label > span")).Click();
            //Continuar
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            //Clique para sair mensagem
            driver.FindElement(By.CssSelector("div.ngdialog-overlay")).Click();
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            //Gravar
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            System.Threading.Thread.Sleep(4000);//Aguardando a pagina carregar
            //Editar (lápis)
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div.row > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral.col-menu-vert-11 > div:nth-child(3) > div.card-virtual > div.card-body.card-padding > table > tbody > tr > td:nth-child(7) > div:nth-child(1) > span:nth-child(1)")).Click();
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            //Ponto de venda
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(2) > .col-lg-3:nth-child(3) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(2) > .col-lg-3:nth-child(3) #comboundefined")).SendKeys("matriz");
            driver.FindElement(By.CssSelector("strong")).Click();
            //Origem
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(4) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(4) #comboundefined")).SendKeys("geral");
            driver.FindElement(By.CssSelector("strong")).Click();
            //Vendedor
            driver.ExecuteJavaScript("window.scroll(0,1000)");//Scroll na tela
            driver.FindElement(By.CssSelector(".row:nth-child(10) > .col-lg-12:nth-child(1) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".row:nth-child(10) > .col-lg-12:nth-child(1) #comboundefined")).SendKeys("francisco");            
            driver.FindElement(By.CssSelector("strong")).Click();
            //Gravar documento
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(8) > .pull-right:nth-child(1)")).Click();
            #endregion
        }
    }
}