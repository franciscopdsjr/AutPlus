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
                System.Threading.Thread.Sleep(15000);
                driver.FindElement(By.XPath("/html/body/div[5]/div[1]/nav/div[1]/button[2]")).Click();
            }catch(Exception e)
            {

            }
            
            System.Threading.Thread.Sleep(15000);
            driver.FindElement(By.XPath("/html/body/div[5]/div[1]/nav/div[1]/div/button")).Click();
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.XPath("/html/body/div[5]/div[1]/nav/div[1]/div/ul/li[2]/a")).Click();
            System.Threading.Thread.Sleep(5000);
            return driver;
        }
    }
}
