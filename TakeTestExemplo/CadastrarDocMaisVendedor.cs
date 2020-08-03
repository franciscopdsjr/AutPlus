using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;

namespace Portal
{
    [TestClass]
    public class CadastrarDocMaisVendedor
    {
        public CadastrarDocMaisVendedor()
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

            #region Cadastrar Documento com mais de um vendedor
            driver.FindElement(By.CssSelector(".col-lg-4:nth-child(3) > div")).Click();
            driver.FindElement(By.CssSelector(".ng-touched")).Click();
            driver.FindElement(By.CssSelector(".ng-touched")).SendKeys("fausto silva");
            driver.FindElement(By.CssSelector(".zmdi-search")).Click();
            driver.FindElement(By.CssSelector(".list-virtual:nth-child(1) h3 > .ng-binding")).Click();
            driver.FindElement(By.LinkText("Seguros")).Click();
            js.ExecuteScript("window.scroll(0,0)");
            driver.FindElement(By.CssSelector(".btn-success")).Click();
            js.ExecuteScript("window.scrollTo(0,0)");
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_cia_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_cia_codigo")).SendKeys("porto");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_ramo_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_ramo_codigo")).SendKeys("AERO");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_docori_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_docori_codigo")).SendKeys("geral");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_pto_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_pto_codigo")).SendKeys("matriz");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.CssSelector(".container-fluid > .row")).Click();
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            js.ExecuteScript("window.scrollTo(0,0)");
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_pto_codigo")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".var_nav:nth-child(6) span"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Release().Perform();
            }
            {
                var element = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[4]/div[2]/div"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.LinkText("Valores")).Click();
            driver.FindElement(By.CssSelector(".card-botoes > .btn:nth-child(1)")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosValoresundefined_edt_doc_qtd_parcelas")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosValoresundefined_edt_doc_qtd_parcelas")).SendKeys("5");
            driver.FindElement(By.Name("frmAutoFormdocumentosValoresundefined_edt_doc_perc_comissao_total")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosValoresundefined_edt_doc_perc_comissao_total")).SendKeys("20");
            js.ExecuteScript("window.scroll(0,1000)");
            driver.FindElement(By.Name("frmAutoFormdocumentosValoresundefined_edt_doc_premio_liquido")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosValoresundefined_edt_doc_premio_liquido")).SendKeys("2000");
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            {
                var element = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[6]/div[2]/div"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.LinkText("Repasses")).Click();
            driver.FindElement(By.CssSelector(".confirm")).Click();
            driver.FindElement(By.CssSelector(".btn-raised")).Click();
            driver.FindElement(By.Id("comboundefined")).Click();
            driver.FindElement(By.Id("comboundefined")).SendKeys("francisco teste");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosRepasseundefined_edt_rep_percentual")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosRepasseundefined_edt_rep_percentual")).SendKeys("50");
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            {
                var element = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[6]/div[2]/div"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            {
                var element = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[6]/div[2]/div"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.LinkText("Repasses")).Click();
            js.ExecuteScript("window.scroll(0,75)");
            driver.FindElement(By.CssSelector(".btn-raised")).Click();
            driver.FindElement(By.Id("comboundefined")).SendKeys("francisco");
            driver.FindElement(By.LinkText("FRANCISCO")).Click();
            driver.FindElement(By.CssSelector("div:nth-child(1) > .col-md-6")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosRepasseundefined_edt_rep_percentual")).SendKeys("50");
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            {
                var element = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[6]/div[2]/div"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            #endregion

        }
    }
}
