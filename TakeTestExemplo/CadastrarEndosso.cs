using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using System;
using TakeTestExemplo;
using TakeTestExemplo.ClassesNavega;

namespace Portal
{
    [TestFixture]
    public class CadastrarEndosso
    {
        [Test]
        public void CadastraEndosso()
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
            #endregion

            #region Cadastrar Endosso
            //Informa o nome do cliente a ser pesquisado
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[1]/vs-portal-consultas-directive/div/div/div/div[3]/div/input")).SendKeys("fausto silva");
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div:nth-child(1) > vs-portal-consultas-directive > div > div > div > div:nth-child(3) > div > span > button")).Click();

            //Seleciona o resultado
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div/div[2]/div/div/div[2]/div[1]/div/div[3]/div/div[1]/div/h3/a")).Click();

            //inicia cadastro de documento
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.LinkText("Seguros")).Click();

            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector(".btn-success")).Click();

            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_cia_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_cia_codigo")).SendKeys("AIG");
            driver.FindElement(By.LinkText("AIG")).Click();

            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_ramo_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_ramo_codigo")).SendKeys("automoveis");
            driver.FindElement(By.CssSelector("strong")).Click();

            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_docori_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_docori_codigo")).SendKeys("geral");
            driver.FindElement(By.CssSelector("strong")).Click();

            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_pto_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_pto_codigo")).Clear();//Deixa o campo vazio
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_pto_codigo")).SendKeys("MATRIZ");
            driver.FindElement(By.LinkText("MATRIZ")).Click();

            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();

            //aba seguro
            System.Threading.Thread.Sleep(15000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[1]/nav/div[3]/div/vs-menu-responsivo/div/div[2]/div/div/ul/li[1]/a")).Click();

            //Novo endosso
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[5]/div[2]/div/div[1]/button")).Click();

            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_tpmov_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_tpmov_codigo")).SendKeys("substituicao");
            driver.FindElement(By.LinkText("SUBSTITUICAO DE ITEM")).Click();

            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            driver.ExecuteJavaScript("window.scrollTo(0,123)");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);//Aguardando a pagina carregar
            System.Threading.Thread.Sleep(9000);//Aguardando a pagina carregar
            driver.FindElement(By.LinkText("Seguro")).Click();
            #endregion
            //Fecha o navegador
            MetodosNavega.SairPlus(driver);

            driver.Quit();
        }
    }
}
