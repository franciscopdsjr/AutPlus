using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
namespace Automacao
{
    [TestClass]
    public class AutomacaoEmissao
    {
        [TestMethod]
        public void AutomacaoDeEmissao()
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
            }

            driver.FindElement(By.CssSelector(".ng-scope > .animated")).Click();
            driver.FindElement(By.Id("usuario")).Click();
            driver.FindElement(By.Id("usuario")).SendKeys("francisco");
            driver.FindElement(By.Id("senha")).SendKeys("F123456");
            driver.FindElement(By.CssSelector(".button-login-q")).Click();
            #endregion

            #region Automação de emissão
            //Clica em Automação de emissão
            System.Threading.Thread.Sleep(4000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector("a:nth-child(4)")).Click();

            //Seleciona a cia
            System.Threading.Thread.Sleep(4000);//Aguardando a pagina carregar
            driver.ExecuteJavaScript("window.scroll(0,1000)");//Scroll na tela
            driver.FindElement(By.CssSelector("div:nth-child(9) > div > div.col-xs-10")).Click();

            //Desmarca
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div[4]/div/div[1]/div/spam[2]")).Click();
           

            //Marcar somente um
            driver.ExecuteJavaScript("window.scrollTo(0,1000)");
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div > div:nth-child(4) > div > div.card-body.card-padding.row.scroll-arquivos > div > div:nth-child(2) > table > tbody > tr:nth-child(1) > td:nth-child(1) > vs-editavel3 > div > label > span")).Click();

            //Continuar
            driver.FindElement(By.CssSelector(".btn-md")).Click();

            //Clica para sair da mensagem
            System.Threading.Thread.Sleep(9000);//Aguardando a pagina carregar
            //ESC para fechar a tela de dados da importação
            Actions action = new Actions(driver);
            action.SendKeys(Keys.Escape).Perform();
            //driver.FindElement(By.CssSelector("div.ngdialog-overlay")).Click();

            //Gravar
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector(".btn-md")).Click();

            //Editar (Lápis)
            System.Threading.Thread.Sleep(7000);//Aguardando a pagina carregar
            driver.FindElement(By.ClassName("ajustarIndividual(docto)")).Click();

            //Ponto de venda
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(2) > .col-lg-3:nth-child(3) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(2) > .col-lg-3:nth-child(3) #comboundefined")).SendKeys("matriz");
            driver.FindElement(By.CssSelector("strong")).Click();

            //Origem
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(4) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(4) #comboundefined")).SendKeys("geral");
            driver.FindElement(By.CssSelector("strong")).Click();

            //Comissao
            driver.FindElement(By.CssSelector(".ng-invalid .form-control")).Click();
            driver.FindElement(By.CssSelector(".ng-invalid .form-control")).SendKeys("20");

            //Vendedor
            driver.ExecuteJavaScript("window.scroll(0,2000)");
            driver.FindElement(By.CssSelector(".row:nth-child(10) > .col-lg-12:nth-child(1) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".row:nth-child(10) > .col-lg-12:nth-child(1) #comboundefined")).SendKeys("francisco");
            driver.FindElement(By.CssSelector("strong")).Click();

            //Salvar
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(8) > .pull-right:nth-child(1)")).Click();
            #endregion

            //Fecha o navegador
            driver.Quit();
        }
    }
}
