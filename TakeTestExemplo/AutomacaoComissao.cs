using com.sun.org.apache.bcel.@internal.generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using TakeTestExemplo;
using Telerik.JustMock;

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

            #region Automação de comissão
            //Seleciona Automação de comissão
            System.Threading.Thread.Sleep(4000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector(".icon-receipt:nth-child(2)")).Click();

            //Clica na cia "Bradesco"
            driver.ExecuteJavaScript("window.scroll(0,1000)");//Scroll na página
            System.Threading.Thread.Sleep(9000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div[3]/div[1]/div[2]/div/div[10]")).Click();            

            //Informa corretora
            driver.FindElement(By.Id("comboundefined")).Click();
            driver.FindElement(By.Id("comboundefined")).SendKeys("matriz");
            driver.FindElement(By.CssSelector("strong")).Click();

            //Desmarcar
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div > div:nth-child(4) > div > div.clearfix.card-header.bg-card-teal > div > spam:nth-child(2)")).Click();

            //Marcar somente um
            driver.ExecuteJavaScript("window.scroll(0,1000)");
            driver.FindElement(By.CssSelector(".ng-scope:nth-child(1) > td .check")).Click();

            //Continuar
            driver.FindElement(By.CssSelector(".btn-md")).Click();

            //Grava
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar

            int a = 20;

            int c = a;
            //ESC para fechar a tela de dados da importação
            Actions action = new Actions(driver);
            action.SendKeys(OpenQA.Selenium.Keys.Escape).Perform();

            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div > div.botoes-bottom.botoes-bottom-calcular-todas.ng-scope > div > div > button")).Click();
            #endregion

            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            //Fecha o navegador
            driver.Quit();
        }
    }
}
