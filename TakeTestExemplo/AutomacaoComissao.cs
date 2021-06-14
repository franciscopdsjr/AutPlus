using com.sun.org.apache.bcel.@internal.generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using TakeTestExemplo;
using Telerik.JustMock;
using TakeTestExemplo.ClassesNavega;
using NUnit.Framework;
namespace Automacao
{
    [TestFixture]
    public class AutomacaoComissao
    {
        [Test]
        public void AutomacaoDeComissao()
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
                //builder.MoveToElement(elemento).Release().Perform();
            }
            driver.FindElement(By.CssSelector(".container-fluid")).Click();
            driver.FindElement(By.CssSelector(".ng-scope > .animated")).Click();
            {
                var dropdown = driver.FindElement(By.CssSelector(".ng-scope > .animated"));
                dropdown.FindElement(By.XPath("/html/body/div[5]/div[2]/div[2]/div/div/div/div/div/div[2]/div[2]/select/option[3]")).Click();
                //driver.Quit();
            }
            Login login = new Login();

            System.Threading.Thread.Sleep(6000);

            driver.FindElement(By.CssSelector(".ng-scope > .animated")).Click();
            driver.FindElement(By.Id("usuario")).Click();
            driver.FindElement(By.Id("usuario")).SendKeys(login.RetornaUsuario());
            driver.FindElement(By.Id("senha")).SendKeys(login.RetornaSenha());
            driver.FindElement(By.CssSelector(".button-login-q")).Click();
            #endregion

            #region Automação de comissão
            //Seleciona Automação de comissão
            System.Threading.Thread.Sleep(8000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector(".icon-receipt:nth-child(2)")).Click();

            //Clica na cia "Bradesco"
            //            driver.ExecuteJavaScript("window.scroll(0,1000)");//Scroll na página
            System.Threading.Thread.Sleep(10000);//Aguardando a pagina carregar
            try
            {
                driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div[3]/div[1]/div[2]/div/div[19]")).Click();
            }
            catch
            {
                driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div[3]/div[1]/div[2]/div/div[19]/div/div[2]")).Click();
            }
            //Informa corretora
            driver.FindElement(By.Id("comboundefined")).Click();
            driver.FindElement(By.Id("comboundefined")).SendKeys("matriz");
            driver.FindElement(By.Id("comboundefined")).SendKeys(Keys.Enter);


            //Desmarcar
            System.Threading.Thread.Sleep(20000);//Aguardando a pagina carregar
            //driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div > div:nth-child(4) > div > div.clearfix.card-header.bg-card-teal > div > spam:nth-child(2)")).Click();
            //driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div[2]/div/div[2]/div[2]/div/div/div[1]/table/tbody/tr/td[1]/vs-editavel3/div/label/input")).Click();
            //Marcar somente um
            driver.ExecuteJavaScript("window.scroll(0,1000)");
            
            string semArquivos = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div[3]/div/div[2]/div/h5")).Text;

            System.Threading.Thread.Sleep(5000);

            try
            {
                string qtdArquivosBaixados = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div[4]/div/div[1]/h2")).Text;
                int qtdArqBaixados = MetodosNavega.DevolveNumeroDeUmTexto(qtdArquivosBaixados);

                if (qtdArqBaixados >= 1)
                {
                    if (qtdArqBaixados == 1)
                    {
                        driver.FindElement(By.CssSelector(".ng-scope:nth-child(1) > td .check")).Click();
                        driver.FindElement(By.CssSelector(".ng-scope:nth-child(1) > td .check")).Click();
                    }
                    else
                    {
                        try
                        {
                            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div[4]/div/div[1]/div/spam[2]")).Click();
                        }
                        catch
                        {
                            for (int i = 1; i <= qtdArqBaixados; i++)
                            {
                                driver.FindElement(By.CssSelector(".ng-scope:nth-child(" + i + ") > td .check")).Click();
                            }
                        }

                        driver.FindElement(By.CssSelector(".ng-scope:nth-child(1) > td .check")).Click();
                    }

                    System.Threading.Thread.Sleep(5000);
                    //Continuar
                    driver.FindElement(By.CssSelector(".btn-md")).Click();
                    System.Threading.Thread.Sleep(5000);
                    //Grava
                    System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
                    System.Threading.Thread.Sleep(5000);

                    //ESC para fechar a tela de dados da importação
                    System.Threading.Thread.Sleep(5000);
                    Actions action = new Actions(driver);
                    action.SendKeys(OpenQA.Selenium.Keys.Escape).Perform();
                    System.Threading.Thread.Sleep(5000);
                    driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div[5]/div/div/button")).Click();
                    System.Threading.Thread.Sleep(5000);

                    if (driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div[2]/div[2]/div/div[1]/h2")).Displayed)
                    {

                        //Definindo a categoria e conta para envio ao cashflow
                        driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div[5]/div/div/button[2]")).Click();
                        System.Threading.Thread.Sleep(6000);


                        IWebElement categoria = driver.FindElement(By.XPath("/html/body/div[12]/div[2]/div[2]/div/div/div[4]/vs-editavel3/div/input"));
                        IWebElement conta = driver.FindElement(By.XPath("/html/body/div[12]/div[2]/div[2]/div/div/div[5]/vs-editavel3/div/input"));

                        {

                            Actions actionProvider = new Actions(driver);
                            actionProvider.Click(categoria).Build().Perform();
                            actionProvider.Click(categoria).Build().Perform();
                            actionProvider.SendKeys(categoria, "COMISSÕES RECEBIDAS");
                            actionProvider.Click(categoria).Build().Perform();
                            driver.FindElement(By.XPath("/html/body/div[12]/div[2]/div[2]/div/div/div[4]/vs-editavel3/div/ul/li/a")).Click();
                        }
                        
                        {

                            Actions actionProvider2 = new Actions(driver);
                            // Perform click-and-hold action on the element
                            actionProvider2.Click(conta).Build().Perform();
                            actionProvider2.Click(conta).Build().Perform();
                            actionProvider2.SendKeys(conta, "CONTA BB").Build().Perform(); 
                            driver.FindElement(By.XPath("/html/body/div[12]/div[2]/div[2]/div/div/div[5]/vs-editavel3/div/ul/li/a")).Click();
                        }

                        //Clicando no Gravar informações.
                        driver.FindElement(By.XPath("/html/body/div[12]/div[2]/div[3]/div/button[3]")).Click();

                    }
                }
            }
            catch
            {
                IWebElement graverInformacaoes = driver.FindElement(By.XPath("/html/body/div[12]/div[2]/div[3]/div/button[3]"));
                Actions actionsProvider3 = new Actions(driver);
                actionsProvider3.Click(graverInformacaoes).Build().Perform();
            }

            #endregion

            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
                                                //Fecha o navegador
            MetodosNavega.SairPlus(driver);

            driver.Quit();
        }
    }
}
