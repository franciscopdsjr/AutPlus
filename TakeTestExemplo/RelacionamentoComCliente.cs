using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using TakeTestExemplo;
using TakeTestExemplo.ClassesNavega;

namespace RelacionamentoCliente
{
    [TestFixture]
    public class RelacionamentoComCliente
    {
        [Test]
        public void RelacionamentosComCliente()
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

          

            #region Central de relacionamento
            System.Threading.Thread.Sleep(6000);//Aguardando a pagina carregar 
            driver.FindElement(By.Id("botaoMenu")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector("div:nth-child(3) > .menu > .menu-item:nth-child(8) > .menu-span > .ng-binding")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".menu-item:nth-child(8) > .expandida > .menu > .menu-item:nth-child(1) > .menu-span > .ng-binding")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".menu-item:nth-child(1) .menu-item:nth-child(1) .ng-binding")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.Id("comboundefined")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.Id("comboundefined")).SendKeys("francisco");
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector("strong")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".form-group:nth-child(4) .check")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.Name("frmAutoFormcentralRelacClientesSelecaoundefined_edt_data1")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.Name("frmAutoFormcentralRelacClientesSelecaoundefined_edt_data1")).SendKeys("24/04/1994");
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.Name("frmAutoFormcentralRelacClientesSelecaoundefined_edt_data2")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.Name("frmAutoFormcentralRelacClientesSelecaoundefined_edt_data2")).SendKeys("24/04/1994");
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            {
                System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
                var element = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[2]/div[2]/div"));
                System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
                Actions builder = new Actions(driver);
                System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
                builder.MoveToElement(element).Perform();
            }
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.LinkText("Dados do documento")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.Name("frmAutoFormcentralRelacClientesSelecaoundefined_edt_doc_apolice")).Click();
            driver.FindElement(By.Name("frmAutoFormcentralRelacClientesSelecaoundefined_edt_doc_apolice")).Clear();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
           // driver.FindElement(By.Name("frmAutoFormcentralRelacClientesSelecaoundefined_edt_doc_apolice")).SendKeys("VariosItens");
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.ExecuteJavaScript("window.scroll(0,1000)");
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".btn-default")).Click();
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".check")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".check")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".check")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".btn-default:nth-child(2)")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".col-lg-3 > .ng-pristine span")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".modal-footer > .btn")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".col-sm-12 > .ng-pristine .ng-valid-maxlength")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/email/div/div/div[3]/div/div/div[2]/div[6]/vs-editavel3/div/input")).SendKeys("teste regressivo");
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".mfb-component__main-icon--active")).Click();
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(By.XPath("/html/body/div[7]/div[2]/button[1]")).Click();
            #endregion

            MetodosNavega.SairPlus(driver);
           
            driver.Quit();
        }
    }
}
