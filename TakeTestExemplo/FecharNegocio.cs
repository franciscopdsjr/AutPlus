using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TakeTestExemplo;
using TakeTestExemplo.ClassesNavega;

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
            Login login = new Login();

            driver.FindElement(By.CssSelector(".ng-scope > .animated")).Click();
            driver.FindElement(By.Id("usuario")).Click();
            driver.FindElement(By.Id("usuario")).SendKeys(login.RetornaUsuario());
            driver.FindElement(By.Id("senha")).SendKeys(login.RetornaSenha());
            driver.FindElement(By.CssSelector(".button-login-q")).Click();
            #endregion

            #region Fechar Negocio
            //Buscando negocio cadastrado hoje

            int dia = DateTime.Now.Day;
            int mes = DateTime.Now.Month;
            int ano = DateTime.Now.Year;

            string agora;

            if (dia < 9)
            {
                agora = "0" + dia.ToString();
                agora = agora + "0" + mes.ToString();
                agora = agora + ano.ToString();
            }
            else
            {
                agora =  dia.ToString();
                agora = agora + "0" + mes.ToString();
                agora = agora + ano.ToString();
            }

            

            System.Threading.Thread.Sleep(6000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector(".zmdi-case:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".col-xs-12:nth-child(1) .col-xs-4:nth-child(2) .form-control")).Click();
            driver.FindElement(By.CssSelector(".col-xs-12:nth-child(1) .col-xs-4:nth-child(2) .form-control")).SendKeys(Keys.Backspace);
            driver.FindElement(By.CssSelector(".col-xs-12:nth-child(1) .col-xs-4:nth-child(2) .form-control")).Clear();
            driver.FindElement(By.CssSelector(".col-xs-12:nth-child(1) .col-xs-4:nth-child(2) .form-control")).SendKeys(agora);
            driver.FindElement(By.CssSelector(".col-xs-12:nth-child(1) .col-xs-4:nth-child(3) .form-control")).Click();
            driver.FindElement(By.CssSelector(".col-xs-12:nth-child(1) .col-xs-4:nth-child(3) .form-control")).SendKeys(Keys.Backspace);
            driver.FindElement(By.CssSelector(".col-xs-12:nth-child(1) .col-xs-4:nth-child(3) .form-control")).Clear();
            driver.FindElement(By.CssSelector(".col-xs-12:nth-child(1) .col-xs-4:nth-child(3) .form-control")).SendKeys(agora);
            driver.FindElement(By.CssSelector(".col-xs-12:nth-child(1) .col-xs-4:nth-child(3) .form-control")).SendKeys(Keys.Tab);
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[1]/div[1]/div[2]/div/div[7]/vs-editavel3/div/input")).Clear();
            //driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div.row > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral.col-menu-vert-11 > div:nth-child(1) > div:nth-child(2) > div > div > div > button")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[1]/div[2]/div/div/div/button")).Click();
            //Clicar no negocio que sera fechado
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector("tbody > tr > td:nth-child(1) > button > i")).Click();

            //Fechar negocio

            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.LinkText("Fechar negócio")).Click();
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector("div:nth-child(73) > div.sweet-alert.show-sweet-alert.visible > button.confirm")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.Name("frmAutoFormfecharNegocioundefined_edt_cn_orc_inicio_vigencia")).Click();
            DateTime dataHoje = DateTime.Today;
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[4]/div[1]/div/form/div[2]/div/div[2]/div[1]/div[1]/div/vs-editavel3/div/input")).SendKeys(Keys.Control + "A");
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[4]/div[1]/div/form/div[2]/div/div[2]/div[1]/div[1]/div/vs-editavel3/div/input")).SendKeys(Keys.Delete);
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[4]/div[1]/div/form/div[2]/div/div[2]/div[1]/div[1]/div/vs-editavel3/div/input")).SendKeys(dataHoje.ToShortDateString());
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[4]/div[1]/div/form/div[2]/div/div[2]/div[1]/div[1]/div/vs-editavel3/div/input")).SendKeys(Keys.Tab);
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[4]/div[1]/div/form/div[2]/div/div[2]/div[1]/div[1]/div/vs-editavel3/div/input")).SendKeys(Keys.Tab);
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[4]/div[1]/div/form/div[2]/div/div[2]/div[3]/div[1]/div/vs-editavel3/div/input")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[4]/div[1]/div/form/div[2]/div/div[2]/div[3]/div[1]/div/vs-editavel3/div/input")).SendKeys(Keys.Down);
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[4]/div[1]/div/form/div[2]/div/div[2]/div[3]/div[1]/div/vs-editavel3/div/input")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[4]/div[1]/div/form/div[2]/div/div[2]/div[3]/div[1]/div/vs-editavel3/div/input")).SendKeys(Keys.Tab);

            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div.row > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral.col-menu-vert-11 > div:nth-child(5) > div.botoes-bottom.botoes-bottom-calcular-todas.ng-scope > div > div > button")).Click();
            #endregion
            //Fecha o navegador
            MetodosNavega.SairPlus(driver);

            driver.Quit();
        }
    }
}
