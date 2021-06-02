using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using System;
using TakeTestExemplo;

namespace TakeTestExemplo.ClassesNavega
{
    static class MetodosNavega
    {
        public static IWebDriver SairPlus(IWebDriver driver)
        {

            try
            {
                System.Threading.Thread.Sleep(50000);
                driver.FindElement(By.XPath("/html/body/div[5]/div[1]/nav/div[1]/button[2]")).Click();
            }
            catch (Exception e)
            {

            }

            System.Threading.Thread.Sleep(50000);
            driver.FindElement(By.XPath("/html/body/div[5]/div[1]/nav/div[1]/div/button")).Click();
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.XPath("/html/body/div[5]/div[1]/nav/div[1]/div/ul/li[2]/a")).Click();
            System.Threading.Thread.Sleep(5000);
            return driver;
        }

        public static IWebDriver NavegaScroll(IWebDriver navega, string localizador, int tipoLocalizador)
        {
            //Essa função navega até um determinado ponto da página. esse ponto é determinado pelo id passado na chamada. id = 1 xpath = 2
            IWebDriver driver = navega;
            IJavaScriptExecutor jsAbrePremios = (IJavaScriptExecutor)driver;
            IWebElement positionPremio;

            if (tipoLocalizador == 1)
            {
                positionPremio = driver.FindElement(By.Id(localizador));
            }
            else
            {
                positionPremio = driver.FindElement(By.XPath(localizador));
            }

            if (positionPremio != null)
            {
                jsAbrePremios.ExecuteScript("window.scrollBy(0, arguments[0])", positionPremio.Location.Y);
            }
            return driver;
        }
        //sobrecarga do metodo para buscar posição também por IWebElement
        public static IWebDriver NavegaScroll(IWebDriver navega, IWebElement localizador)
        {
            //Essa função navega até um determinado ponto da página. esse ponto é determinado pelo WebObject.
            IWebDriver driver = navega;
            IJavaScriptExecutor jsAbrePremios = (IJavaScriptExecutor)driver;
            IWebElement positionPremio = localizador;
            jsAbrePremios.ExecuteScript("window.scrollBy(0, arguments[0])", positionPremio.Location.Y);
            return driver;
        }

        public static string DiaDeHoje()
        {
            DateTime diaDeHoje = DateTime.Now;
            return diaDeHoje.ToString("dd/MM/yyyy");
        }

    }
}
