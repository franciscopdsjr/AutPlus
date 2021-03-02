using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;

namespace Portal
{
    [TestClass]
    public class CadastrarPJApolice
    {
        [TestMethod]
        public void CadastraPJApolice()
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

            #region Cadastrar Apolice PJ
            //Busca do cliente
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[1]/vs-portal-consultas-directive/div/div/div/div[3]/div")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[1]/vs-portal-consultas-directive/div/div/div/div[3]/div/input")).SendKeys("monstros sa");
            
            //Clicar na busca
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div:nth-child(1) > vs-portal-consultas-directive > div > div > div > div:nth-child(3) > div > span > button")).Click();

            //Clicar em Seguros
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[1]/nav/div[3]/div/vs-menu-responsivo/div/div[2]/div/div/ul/li[2]/a")).Click();

            //Clicar em incluir
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/vs-relacao3/div/div/div/div/div/div/div[1]/button")).Click();

            //Campo Apólice
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_doc_apolice")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_doc_apolice")).SendKeys("123465");
            
            //Campo Seguradora
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_cia_codigo")).Click();
            driver.FindElement(By.LinkText("AMIL")).Click();
            
            //Campo Produto
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_ramo_codigo")).Click();
            driver.FindElement(By.LinkText("EMPRESARIAL")).Click();
            
            //Campo Origem
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_docori_codigo")).Click();
            driver.FindElement(By.LinkText("GERAL")).Click();
            
            //Campo Ponto de Venda
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_pto_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_pto_codigo")).Clear();//Deixa o campo vazio
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_pto_codigo")).SendKeys("MATRIZ");
            driver.FindElement(By.LinkText("MATRIZ")).Click();
            
            //Campo data emissão
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_doc_data_emissao")).Click();
            driver.FindElement(By.CssSelector(".today")).Click();
            
            //Campo data de entrada
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_doc_data_entrada")).Click();
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector(".today")).Click();
            
            //Salvar
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            driver.ExecuteJavaScript("window.scrollTo(0,0)");

            //Fecha o navegador
            driver.Quit();
            #endregion
        }
    }
}
