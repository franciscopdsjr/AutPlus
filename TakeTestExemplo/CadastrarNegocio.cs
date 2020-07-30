using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;

namespace CentralDeNegocios
{
    [TestClass]
    public class CadastrarNegocio
    {
        [TestMethod]
        public void CadastraNegocio()
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

            #region Cadastro do Negócio
            //Central de Negocios
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[2]/div/a[1]/div/div")).Click();
            driver.FindElement(By.CssSelector(".btn-success")).Click();
            driver.FindElement(By.CssSelector(".col-lg-3:nth-child(2) .ng-valid-mask")).Click();
            driver.FindElement(By.CssSelector(".col-lg-3:nth-child(2) .ng-valid-mask")).SendKeys("300.300.300-30");
            driver.FindElement(By.CssSelector(".col-lg-3:nth-child(3) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".col-lg-8:nth-child(1) .card-body")).Click();           
            driver.ExecuteJavaScript("window.scroll(0,1000)");
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(2) > .col-lg-6 #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(2) > .col-lg-6 #comboundefined")).SendKeys("aero");
            driver.FindElement(By.LinkText("AERONAUTICO")).Click();
            driver.FindElement(By.CssSelector(".col-lg-3:nth-child(3) .empty")).Click();
            driver.FindElement(By.CssSelector(".today")).Click();
            driver.FindElement(By.CssSelector(".col-lg-12 #combopontos")).Click();
            //driver.ExecuteScript("document.getElementById("combopontos").select()");
            driver.FindElement(By.CssSelector(".col-lg-12 #combopontos")).SendKeys("m");
            driver.FindElement(By.CssSelector(".col-lg-12 #combopontos")).SendKeys("a");
            driver.FindElement(By.CssSelector(".col-lg-12 #combopontos")).SendKeys("t");
            driver.FindElement(By.CssSelector(".col-lg-12 #combopontos")).SendKeys("r");
            driver.FindElement(By.CssSelector(".col-lg-12 #combopontos")).SendKeys("i");
            driver.FindElement(By.CssSelector(".col-lg-12 #combopontos")).SendKeys("z");
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.LinkText("MATRIZ")).Click();
            driver.FindElement(By.Id("combovendedor")).Click();
            driver.FindElement(By.Id("combovendedor")).SendKeys("F");
            driver.FindElement(By.Id("combovendedor")).SendKeys("R");
            driver.FindElement(By.Id("combovendedor")).SendKeys("A");
            driver.FindElement(By.Id("combovendedor")).SendKeys("N");
            driver.FindElement(By.Id("combovendedor")).SendKeys("C");
            driver.FindElement(By.Id("combovendedor")).SendKeys("I");
            driver.FindElement(By.Id("combovendedor")).SendKeys("S");
            driver.FindElement(By.Id("combovendedor")).SendKeys("C");
            driver.FindElement(By.Id("combovendedor")).SendKeys("O");
            //driver.FindElement(By.Id("combovendedor")).Click();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.LinkText("FRANCISCO")).Click();
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            //js.ExecuteScript("window.scrollTo(0,574)");
            #endregion
        }
    }
}