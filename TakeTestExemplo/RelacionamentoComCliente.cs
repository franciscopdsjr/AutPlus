using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace RelacionamentoCliente
{
    [TestClass]
    public class RelacionamentoComCliente
    {
        public RelacionamentoComCliente()
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

            #region Central de relacionamento
            driver.FindElement(By.Id("botaoMenu")).Click();
            driver.FindElement(By.CssSelector("div:nth-child(3) > .menu > .menu-item:nth-child(8) > .menu-span > .ng-binding")).Click();
            driver.FindElement(By.CssSelector(".menu-item:nth-child(8) > .expandida > .menu > .menu-item:nth-child(1) > .menu-span > .ng-binding")).Click();
            driver.FindElement(By.CssSelector(".menu-item:nth-child(1) .menu-item:nth-child(1) .ng-binding")).Click();
            driver.FindElement(By.Id("comboundefined")).Click();
            driver.FindElement(By.Id("comboundefined")).SendKeys("francisco");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.CssSelector(".form-group:nth-child(4) .check")).Click();
            driver.FindElement(By.Name("frmAutoFormcentralRelacClientesSelecaoundefined_edt_data1")).Click();
            driver.FindElement(By.Name("frmAutoFormcentralRelacClientesSelecaoundefined_edt_data1")).SendKeys("24/04/1994");
            driver.FindElement(By.Name("frmAutoFormcentralRelacClientesSelecaoundefined_edt_data2")).Click();
            driver.FindElement(By.Name("frmAutoFormcentralRelacClientesSelecaoundefined_edt_data2")).SendKeys("24/04/1994");
            {
                var element = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[2]/div[2]/div"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.LinkText("Dados do documento")).Click();
            driver.FindElement(By.Name("frmAutoFormcentralRelacClientesSelecaoundefined_edt_doc_apolice")).Click();
            driver.FindElement(By.Name("frmAutoFormcentralRelacClientesSelecaoundefined_edt_doc_apolice")).SendKeys("VariosItens");
            js.ExecuteScript("window.scroll(0,1000)");
            driver.FindElement(By.CssSelector(".btn-default")).Click();
            driver.FindElement(By.CssSelector(".check")).Click();
            driver.FindElement(By.CssSelector(".check")).Click();
            driver.FindElement(By.CssSelector(".check")).Click();
            driver.FindElement(By.CssSelector(".btn-default:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".col-lg-3 > .ng-pristine span")).Click();
            driver.FindElement(By.CssSelector(".modal-footer > .btn")).Click();
            driver.FindElement(By.CssSelector(".col-sm-12 > .ng-pristine .ng-valid-maxlength")).Click();
            driver.FindElement(By.CssSelector(".ng-touched")).SendKeys("teste regressivo");
            driver.FindElement(By.CssSelector(".mfb-component__main-icon--active")).Click();
            #endregion
        }
    }
}
