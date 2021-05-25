using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using TakeTestExemplo;
using TakeTestExemplo.ClassesNavega;
namespace Portal
{
    [TestFixture]
    public class CadastrarSinistro
    {
        [Test]
        public void CadastraSinistro()
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

            #region Cadastrar Sinistro
            //Seleciona o campo de busca
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[1]/vs-portal-consultas-directive/div/div/div/div[3]/div")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[1]/vs-portal-consultas-directive/div/div/div/div[3]/div/input")).SendKeys("fausto silva");
            
            //Clicar no busca
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div:nth-child(1) > vs-portal-consultas-directive > div > div > div > div:nth-child(3) > div > span > button")).Click();

            //Seleciona o cliente na lista
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div > div > div.col-sm-12.col-lg-9 > div > div > div:nth-child(2) > div.col-lg-12.col-md-12.col-sm-12 > div > div.card-body.card-padding.ng-scope > div > div:nth-child(1) > div > h3 > a")).Click();
            
            //Clicar em seguros
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[1]/nav/div[3]/div/vs-menu-responsivo/div/div[2]/div/div/ul/li[2]/a")).Click();

            //Acessar um documento
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("tbody > tr.odd > td:nth-child(1) > button")).Click();

            //Clicar em sinistros
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("div.col-xs-10.col-sm-10.col-lg-10.tab-menu-topo > div > vs-menu-responsivo > div > div.scrtabs-tabs-fixed-container > div > div > ul > li:nth-child(2) > a")).Click();

            //Clicar em incluir
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(".btn-raised")).Click();
            driver.ExecuteJavaScript("window.scroll(0,100)");

            //Clicar em data do sinistro
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.Name("frmAutoFormdocumentosSinistrosundefined_edt_sin_data_sinistro")).Click();
            driver.FindElement(By.CssSelector(".today")).Click();

            //Gravar
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            #endregion
            MetodosNavega.SairPlus(driver);

            driver.Quit();
        }

    }
}
