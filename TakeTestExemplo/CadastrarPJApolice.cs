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
            driver.FindElement(By.CssSelector(".col-lg-4:nth-child(3) > div")).Click();
            driver.FindElement(By.CssSelector(".ng-touched")).Click();
            driver.FindElement(By.CssSelector(".ng-touched")).SendKeys("monstros sa");
            driver.FindElement(By.CssSelector(".zmdi-search")).Click();
            driver.FindElement(By.LinkText("Seguros")).Click();
            driver.FindElement(By.CssSelector("#vsRelacao1_gridRelacao_wrapper > div")).Click();
            driver.ExecuteJavaScript("window.scrollTo(0,47)");
            driver.FindElement(By.CssSelector(".btn-success")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_doc_apolice")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_doc_apolice")).SendKeys("123465");
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_cia_codigo")).Click();
            driver.FindElement(By.LinkText("AMIL")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_ramo_codigo")).Click();
            driver.FindElement(By.LinkText("EMPRESARIAL")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_docori_codigo")).Click();
            driver.FindElement(By.LinkText("GERAL")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_doc_data_emissao")).Click();
            driver.FindElement(By.CssSelector(".today")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_doc_data_entrada")).Click();
            driver.FindElement(By.CssSelector(".today")).Click();
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            driver.ExecuteJavaScript("window.scrollTo(0,0)");
            #endregion
        }
    }
}
