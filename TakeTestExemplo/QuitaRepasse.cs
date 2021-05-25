using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TakeTestExemplo;
using TakeTestExemplo.ClassesNavega;
namespace Comissoes
{
    [TestFixture]
    public class QuitaRepasse
    {
        [Test]
        public void QuitarRepasse()
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

            #region Quitar Repasses
            System.Threading.Thread.Sleep(6000);//Aguardando a pagina carregar 
            driver.FindElement(By.Id("botaoMenu")).Click();
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector("div:nth-child(3) > .menu > .menu-item:nth-child(9) > .menu-span > .ng-binding")).Click();
            System.Threading.Thread.Sleep(4000);//Aguardando a pagina carregar
            IWebElement btnQuitaRep = driver.FindElement(By.XPath("/html/body/div[5]/nav/div[3]/ul/li[18]/a"));
            MetodosNavega.NavegaScroll(driver, btnQuitaRep);
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".menu-item:nth-child(9) > .expandida > .menu > .menu-item:nth-child(4) > .menu-span > .ng-binding")).Click();
            System.Threading.Thread.Sleep(4000);//Aguardando a pagina carregar

            System.Threading.Thread.Sleep(4000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("//*[@id=\"menuEsquerda\"]/div[3]/ul/li[9]/div/ul/li[4]/div/ul/li[2]/a")).Click();
            System.Threading.Thread.Sleep(4000);//Aguardando a pagina carregar
    
            System.Threading.Thread.Sleep(1500);
            driver.FindElement(By.Id("comboundefined")).Click();
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar 
            driver.FindElement(By.Id("comboundefined")).SendKeys("francisco");
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar 
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[1]/div/form/div[3]/div/div[2]/div[1]/div[1]/div/vs-editavel3/div/ul/li[6]/a")).Click();
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".btn-default:nth-child(2)")).Click();
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".btn:nth-child(3)")).Click();
            {
                System.Threading.Thread.Sleep(6000);//Aguardando a pagina carregar 
                var element = driver.FindElement(By.XPath("/html/body/div[7]/div[2]/button[1]"));
                System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
                Actions builder = new Actions(driver);
                System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar 
                builder.MoveToElement(element).Perform();
            }
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar 
            driver.FindElement(By.CssSelector(".confirm")).Click();
            #endregion

            MetodosNavega.SairPlus(driver);

            driver.Quit();
        }
    }
}
