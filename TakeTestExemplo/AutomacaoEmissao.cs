using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Automacao
{
    [TestClass]
    public class AutomacaoEmissao
    {
        public AutomacaoEmissao()
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

            #region Automação de emissão
            driver.FindElement(By.CssSelector(".icon-newsletters:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".logoNormal:nth-child(5) .col-xs-10")).Click();
            driver.FindElement(By.CssSelector(".btn-success:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".ng-scope:nth-child(1) > td .check")).Click();
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            js.ExecuteScript("window.scrollTo(0,0)");
            driver.FindElement(By.CssSelector(".ngdialog-overlay")).Click();
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            driver.FindElement(By.CssSelector(".zmdi-edit")).Click();
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(2) > .col-lg-3:nth-child(3) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(2) > .col-lg-3:nth-child(3) #comboundefined")).SendKeys("matriz");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(4) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(4) #comboundefined")).SendKeys("geral");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.CssSelector(".ng-invalid .form-control")).Click();
            driver.FindElement(By.CssSelector(".ng-invalid .form-control")).SendKeys("20");
            js.ExecuteScript("window.scroll(0,2000)");
            driver.FindElement(By.CssSelector(".row:nth-child(10) > .col-lg-12:nth-child(1) #comboundefined")).Click();
            driver.FindElement(By.CssSelector(".row:nth-child(10) > .col-lg-12:nth-child(1) #comboundefined")).SendKeys("francisco");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.CssSelector(".col-lg-12:nth-child(8) > .pull-right:nth-child(1)")).Click();
            #endregion

        }
    }
}
