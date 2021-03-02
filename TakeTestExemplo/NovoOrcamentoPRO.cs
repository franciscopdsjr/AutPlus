using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using java.util.function;
using com.sun.org.apache.xml.@internal.resolver.helpers;
using sun.security.jgss;

namespace VendasPro
{
    [TestClass]
    public class NovoOrcamentoPRO
    {
        [TestMethod]
        public void Login()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://quiverprohomolog.quiver.net.br/HOMOLOGVERSAO/default.aspx");


            #region Login

            driver.FindElement(By.Id("Corretor")).SendKeys("COLWEB");
            driver.FindElement(By.Id("Usuario")).SendKeys("FLAVIA");
            driver.FindElement(By.Id("Senha")).SendKeys("230118");
            driver.FindElement(By.Id("btnEntrar")).Click();
            #endregion
            System.Threading.Thread.Sleep(5000);//tempo de espera
            driver.FindElement(By.XPath("/html/body/form/div[12]/div[1]/header/div[1]/div[1]/div[1]/i")).Click();
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.XPath("/html/body/form/div[11]/div[4]/a")).Click();
            System.Threading.Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("SelecionaModuloJQuery('', 'NOVOORCAMENTO', 'AcompanhamentoVendas|Professional', 'NOVOORCAMENTO', 'Novo orçamento'); ");

        }
    }
}
