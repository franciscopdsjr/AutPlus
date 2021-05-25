using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using TakeTestExemplo;
using TakeTestExemplo.ClassesNavega;

namespace Cash
{
    [TestFixture]
    public class RecebimentoCash
    {
        [Test]
        public void RecebimentosCash()
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

            #region Recebimento Cash
            //Botao Menu
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.Id("botaoMenu")).Click();

            //Seleciona o Cash
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/nav/div[2]/div/input")).SendKeys("CASH");
            driver.FindElement(By.XPath("/html/body/div[5]/nav/div[3]/ul/li/a/span")).Click();

            //Seleciona Lançamentos
            driver.FindElement(By.LinkText("Lançamentos")).Click();

            //Incluir
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[3]/div[2]/div/div/vs-relacao3/div/div/div/div/div/div/div[1]/button")).Click();

            //Empresa
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.Name("frmAutoFormcashFlowLancamentosFinanceirosundefined_edt_emp_codigo")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[3]/div[1]/form/div[1]/div/div[2]/div[1]/div/div/vs-editavel3/div/ul/li[1]/a")).Click();

            //Seleciona Recebimento
            driver.FindElement(By.Name("frmAutoFormcashFlowLancamentosFinanceirosundefined_edt_lb_tipo")).Click();
            driver.FindElement(By.LinkText("Recebimentos")).Click();

            //Vencimento
            driver.FindElement(By.Name("frmAutoFormcashFlowLancamentosFinanceirosundefined_edt_lb_data")).Click();
            driver.FindElement(By.CssSelector(".today")).Click();

            //Conta
            driver.FindElement(By.Name("frmAutoFormcashFlowLancamentosFinanceirosundefined_edt_cta_codigo")).SendKeys("conta bb");
            driver.FindElement(By.LinkText("CONTA BB")).Click();

            //Salvar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[3]/vs-botoes3/div/div/div[2]/button[1]")).Click();

            //Edita
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[3]/vs-botoes3/div/div/div[1]/button[1]")).Click();

            //Clicar em incluir detalhes
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[3]/div[2]/div/div[1]/button")).Click();

            //Clicar em Valor
            System.Threading.Thread.Sleep(3000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[3]/div[2]/div/div[2]/div[2]/div/table/tbody/tr/td/div[1]/vs-editavel3/div/input")).SendKeys("125,00");

            //Clicar em categoria
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[3]/div[2]/div/div[2]/div[2]/div/table/tbody/tr/td/div[3]/vs-editavel3/div/input")).SendKeys("AGUA");
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[3]/div[2]/div/div[2]/div[2]/div/table/tbody/tr/td/div[3]/vs-editavel3/div/ul/li/a")).Click();

            //Clicar em Pessoa
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[3]/div[2]/div/div[2]/div[2]/div/table/tbody/tr/td/div[4]/vs-editavel3/div/input")).SendKeys("FRANCISCO");
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[3]/div[2]/div/div[2]/div[2]/div/table/tbody/tr/td/div[4]/vs-editavel3/div/ul/li/a")).Click();

            //Salvar
            driver.FindElement(By.CssSelector("body > div:nth-child(5) > div.container-fluid > div.row > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral.col-menu-vert-11 > div:nth-child(3) > vs-botoes3 > div > div > div:nth-child(2) > button.btn.btn-flat.btn-default.botoes-bottom-verde")).Click();

            #endregion

            MetodosNavega.SairPlus(driver);

            driver.Quit();
        }
    }
}
