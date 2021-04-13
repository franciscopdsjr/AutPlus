﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using System;
using TakeTestExemplo;

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
            }
            Login login = new Login();

            driver.FindElement(By.CssSelector(".ng-scope > .animated")).Click();
            driver.FindElement(By.Id("usuario")).Click();
            driver.FindElement(By.Id("usuario")).SendKeys(login.RetornaUsuario());
            driver.FindElement(By.Id("senha")).SendKeys(login.RetornaSenha());
            driver.FindElement(By.CssSelector(".button-login-q")).Click();
            #endregion

            #region Automacao de Proposta
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            //Seleciona Automação
            driver.FindElement(By.CssSelector(".icon-file-empty:nth-child(2)")).Click();

            //Seleciona a Cia
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector("div:nth-child(8) > div > div.col-xs-10")).Click();

            //Desmarcar
            try
            {
                System.Threading.Thread.Sleep(6000);//Aguardando a pagina carregar
                driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div[4]/div/div[2]/div/div[2]/table/tbody/tr[1]/td[1]/vs-editavel3/div/label")).Click();
                //driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div > div:nth-child(4) > div > div.clearfix.card-header.bg-card-teal > div > spam:nth-child(2)")).Click();
            }
            catch (Exception ex)//Caso não tenha o botão desmarcar o sistema irá avisar
            {
                throw new Exception("Não há arquivos baixados pelo feeder" + Environment.NewLine + ex.Message + (ex.InnerException != null ? ex.InnerException.ToString() : String.Empty));
            }
            driver.ExecuteJavaScript("window.scrollTo(0,1000)");

            //Marcar somente um
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div > div:nth-child(4) > div > div.card-body.card-padding.row.scroll-arquivos > div > div:nth-child(2) > table > tbody > tr:nth-child(1) > td:nth-child(1) > vs-editavel3 > div > label > span")).Click();

            //Continuar
            driver.FindElement(By.CssSelector(".btn-md")).Click();

            //Clique para sair mensagem
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            Actions action = new Actions(driver);
            action.SendKeys(Keys.Escape).Perform();

            //Gravar
            System.Threading.Thread.Sleep(7000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("//*[@id=\"ngdialog1\"]/div[1]")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div[5]/div/div/button")).Click();

            //Editar (lápis)
            System.Threading.Thread.Sleep(6000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[3]/div[1]/div[2]/table/tbody/tr[1]/td[6]/div[1]/span[1]")).Click();

            //Ponto de venda
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(2) > .col-lg-3:nth-child(3) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(2) > .col-lg-3:nth-child(3) #comboundefined")).Clear();
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(2) > .col-lg-3:nth-child(3) #comboundefined")).SendKeys("matriz");
            driver.FindElement(By.CssSelector("strong")).Click();

            //Origem
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(4) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(4) #comboundefined")).Clear();
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

            //Fecha o Navegador
            driver.Quit();
        }
    }
}
