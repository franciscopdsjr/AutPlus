﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TakeTestExemplo;
using TakeTestExemplo.ClassesNavega;

namespace Portal
{
    [TestFixture]
    public class RenovarApolice
    {
        [Test]
        public void RenovaApolice()
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

            Login login = new Login();

            driver.FindElement(By.CssSelector(".ng-scope > .animated")).Click();
            driver.FindElement(By.Id("usuario")).Click();
            driver.FindElement(By.Id("usuario")).SendKeys(login.RetornaUsuario());
            driver.FindElement(By.Id("senha")).SendKeys(login.RetornaSenha());
            driver.FindElement(By.CssSelector(".button-login-q")).Click();
            bool sucessoNoTeste = false;
            #endregion

            #region Renovar Apolice
            //Realizar a busca
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[1]/vs-portal-consultas-directive/div/div/div/div[3]/div")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[1]/vs-portal-consultas-directive/div/div/div/div[3]/div/input")).SendKeys("fausto silva");

            //Clicar no busca
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div:nth-child(1) > vs-portal-consultas-directive > div > div > div > div:nth-child(3) > div > span > button")).Click();

            //Clicar no cliente 
            System.Threading.Thread.Sleep(8000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div/div[2]/div/div/div[2]/div[1]/div/div[3]/div/div[1]/div/h3/a")).Click();

            //Clicar em seguros
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[1]/nav/div[3]/div/vs-menu-responsivo/div/div[2]/div/div/ul/li[2]/a")).Click();

            //Clica no documento
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/vs-relacao3/div/div/div/div/div/div/div[2]/div[2]/table/tbody/tr[1]/td[1]/button/i")).Click();

            //Clica em renovar
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[5]/div[1]/div/form/div/div/div[1]/button")).Click();

            //Clicar em Sim
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[7]/div[2]/button[1]")).Click();
            #endregion

            //Edita o documento após renovar.
            System.Threading.Thread.Sleep(9000);
            driver.FindElement(By.XPath("//*[@id=\"movimentacoes\"]/div/div[2]/div/div[1]/div[2]/h3")).Click();
            System.Threading.Thread.Sleep(5000);


            bool alertaNaTela = driver.FindElement(By.XPath("/html/body/div[7]/div[2]/p")).Displayed;

            if (alertaNaTela)
            {
                string alerta = driver.FindElement(By.XPath("/html/body/div[7]/div[2]/p")).Text;

                if (alerta == "Verifique o percentual de corretagem do documento.")
                {
                    driver.FindElement(By.XPath("/html/body/div[7]/div[2]/button[1]")).Click();
                }
            }

            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[5]/vs-botoes3/div/div/div[1]/button[1]")).Click();
            System.Threading.Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[5]/div[3]/div/form/div[3]/div/div[2]/div[1]/div[1]/div/vs-editavel3/div/input")).Clear();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[5]/div[3]/div/form/div[3]/div/div[2]/div[1]/div[1]/div/vs-editavel3/div/input")).SendKeys(MetodosNavega.DiaDeHoje());

            string btnSalvar = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[5]/vs-botoes3/div/div/div[2]/button[1]/span[2]")).Text;
            if (btnSalvar == "S")
            {
                driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[5]/vs-botoes3/div/div/div[2]/button[1]")).Click();
                sucessoNoTeste = true;
            }

            if (sucessoNoTeste)
            {
                MetodosNavega.SairPlus(driver);
            }

        }
    }
}
