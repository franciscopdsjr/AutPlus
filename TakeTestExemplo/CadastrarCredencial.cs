using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace CentralDeSenhas
{
    /// <summary>
    /// Cadastrar uma credencial na central de senhas
    /// </summary>
    [TestClass]
    public class CadastrarCredencial
    {
        [TestMethod]
        public void CadastroCredencial()
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

            #region Menu
            // Clica Menu Lateral 
            System.Threading.Thread.Sleep(2000);//Para aguardar a tela carregar
            driver.FindElement(By.Id("botaoMenu")).Click();
            // Usando o menu pesquisa
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("pesquisaMenu")).SendKeys("Senhas");
            driver.FindElement(By.CssSelector("div:nth-child(3) > ul > li > a")).Click();
            // Espera para carregar 
            System.Threading.Thread.Sleep(2000);

            driver.FindElement(By.CssSelector("div:nth-child(3) > ul > li > div > ul > li > a")).Click();
            System.Threading.Thread.Sleep(2000);
            //Armazena o ID da janela
            string originalWindow = driver.CurrentWindowHandle;
            // Verifica se tem mais janelas abertas
            Assert.AreEqual(driver.WindowHandles.Count, 1);
            // Clica em "Acessar Central de Senhas" | 
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("div:nth-child(3) > ul > li > div > ul > li > div > ul > li > a")).Click();
            #endregion

            #region Abrir a Central de Senhas
            System.Threading.Thread.Sleep(2000);
            //Loop até achar a nova guia
            foreach (string window in driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    driver.SwitchTo().Window(window);
                    break;
                }
            }
            // Seleciona Bradesco
            System.Threading.Thread.Sleep(12000);
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div[1]/div[2]/div/div[10]/div")).Click();
            // Clica em incluir
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".icone-redondo")).Click();
            // 
            driver.FindElement(By.CssSelector(".col-lg-12 > .ng-pristine .form-control")).Click();
            // Clica em descrição
            driver.FindElement(By.CssSelector("div:nth-child(2) > div:nth-child(2) > div.col-lg-8.ng-scope > div:nth-child(1) > div > div > div > div.card-body.card-padding.row > div:nth-child(1) > vs-editavel3 > div > input")).SendKeys("ROBO TESTE");
            // Clica em usuario | 
            driver.FindElement(By.CssSelector(".col-lg-6 .ng-valid-maxlength")).Click();
            // Informa o usuario | 06564836953
            driver.FindElement(By.CssSelector(".col-lg-6 .ng-valid-maxlength")).SendKeys("06564836953");
            // Clica em senha | 
            driver.FindElement(By.CssSelector(".ng-scope > .form-control-wrapper > .form-control")).Click();
            // Informa Senha | B115087F
            driver.FindElement(By.CssSelector(".ng-scope > .form-control-wrapper > .form-control")).SendKeys("B115087F");
            // Clica em situação |id=comboundefined | 
            driver.FindElement(By.Id("comboundefined")).Click();
            // Seleciona Ativo |linkText=Ativo | 
            driver.FindElement(By.LinkText("Ativo")).Click();
            // Clica em Produtor | 
            driver.FindElement(By.CssSelector(".ng-scope > .ng-pristine #comboundefined")).Click();
            // Seleciona Produtor 
            driver.FindElement(By.LinkText("Produtor")).Click();
            // 
            driver.FindElement(By.CssSelector(".ng-scope:nth-child(2) > .card-virtual .icone-redondo")).Click();
            //  
            driver.FindElement(By.CssSelector(".col-lg-5 .form-control")).Click();
            // 
            driver.FindElement(By.CssSelector(".col-lg-5 .form-control")).SendKeys("425792-643");
            // Clica Inspetoria | 
            driver.FindElement(By.CssSelector("div:nth-child(2) > div:nth-child(2) > div.col-lg-8.ng-scope > div:nth-child(2) > div > div.card-body.card-padding.row > div > vs-editavel3:nth-child(2) > div > input")).Click();
            // Informa Inspetoria 
            driver.FindElement(By.CssSelector("div:nth-child(2) > div:nth-child(2) > div.col-lg-8.ng-scope > div:nth-child(2) > div > div.card-body.card-padding.row > div > vs-editavel3:nth-child(2) > div > input")).SendKeys("018");
            // Salva 
            driver.FindElement(By.CssSelector(".btn:nth-child(1) > .visible-lg")).Click();
            #endregion
        }
    }
}