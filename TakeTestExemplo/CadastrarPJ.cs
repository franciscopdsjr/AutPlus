using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using System;
using TakeTestExemplo;

namespace Portal
{
    /// <summary>
    /// Descrição resumida para CadastrarPJ
    /// </summary>
    [TestClass]
    public class CadastrarPJ
    {
        [TestMethod]
        public void CadastroDePJ()
        {
            #region Gera CNPJ
            string GerarCNPJ()
            {
                // Gerar 8 números aleatórios de 0 a 9 e 4 números (0001), e depois calcular eles
                // Colocar eles na maskedTextBox

                Random rnd = new Random();
                int n1 = rnd.Next(0, 10);
                int n2 = rnd.Next(0, 10);
                int n3 = rnd.Next(0, 10);
                int n4 = rnd.Next(0, 10);
                int n5 = rnd.Next(0, 10);
                int n6 = rnd.Next(0, 10);
                int n7 = rnd.Next(0, 10);
                int n8 = rnd.Next(0, 10);
                int n9 = 0;
                int n10 = 0;
                int n11 = 0;
                int n12 = 1;

                int Soma1 = n1 * 5 + n2 * 4 + n3 * 3 + n4 * 2 + n5 * 9 + n6 * 8 + n7 * 7 + n8 * 6 + n9 * 5 + n10 * 4 + n11 * 3 + n12 * 2;

                int DV1 = Soma1 % 11;

                if (DV1 < 2)
                {
                    DV1 = 0;
                }
                else
                {
                    DV1 = 11 - DV1;
                }

                int Soma2 = n1 * 6 + n2 * 5 + n3 * 4 + n4 * 3 + n5 * 2 + n6 * 9 + n7 * 8 + n8 * 7 + n9 * 6 + n10 * 5 + n11 * 4 + n12 * 3 + DV1 * 2;

                int DV2 = Soma2 % 11;

                if (DV2 < 2)
                {
                    DV2 = 0;
                }
                else
                {
                    DV2 = 11 - DV2;
                }

                return n1.ToString() + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9 + n10 + n11 + n12 + DV1 + DV2;
            }
            #endregion

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

            #region Cadastrar PJ
            System.Threading.Thread.Sleep(2000);//Aguardando a pagina carregar
            driver.FindElement(By.Id("botaoMenu")).Click();
            System.Threading.Thread.Sleep(1000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector("div:nth-child(3) > ul > li:nth-child(2) > a > span")).Click();
            System.Threading.Thread.Sleep(1000);//Aguardando a pagina carregar
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div > div > form > div.paddingCard.col-lg-7.col-md-12.col-sm-12.col-xs-12 > div > div.clearfix.card-header.bg-card-teal > button")).Click();
            //Informa Nome
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_cli_nome")).Click();
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_cli_nome")).SendKeys("MONSTROS SA");
            //Informa Tipo de Pessoa
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_cli_tipo_pessoa")).Click();
            driver.FindElement(By.LinkText("Jurídica")).Click();
            //Informa CNPJ
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_cli_cpf_cnpj")).Click();
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_cli_cpf_cnpj")).SendKeys(GerarCNPJ());
            //Data de Nascimento
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_cli_data_nascimento")).Click();
            driver.FindElement(By.CssSelector(".today")).Click();
            //Ponto de venda
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_pto_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_pto_codigo")).SendKeys("matriz");
            driver.FindElement(By.LinkText("MATRIZ")).Click();
            //Vendedor
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_vend_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_vend_codigo")).SendKeys("francisco");
            driver.FindElement(By.LinkText("FRANCISCO")).Click();
            //Origem
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_cliori_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_cliori_codigo")).SendKeys("geral");
            driver.FindElement(By.LinkText("GERAL")).Click();
            //Sroll na tela
            driver.ExecuteJavaScript("window.scroll(0,1000)");
            //Endereço
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_tpender_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_tpender_codigo")).SendKeys("residencial");
            driver.FindElement(By.LinkText("Residencial")).Click();
            driver.FindElement(By.Id("campoCep")).Click();
            driver.FindElement(By.Id("campoCep")).SendKeys("84025-350");
            //Quando digita o CEP ele carrega a tela para trazer o endereço
            {
                var element = driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_ender_numero"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).ClickAndHold().Perform();
            }
            {
                var element = driver.FindElement(By.CssSelector(".efeitoOverlay"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Release().Perform();
            }
            driver.FindElement(By.CssSelector(".container-fluid")).Click();
            driver.FindElement(By.Name("frmAutoFormclientesundefined_edt_ender_numero")).SendKeys("350");
            //Salvar
            driver.FindElement(By.CssSelector("div:nth-child(2) > .btn > span:nth-child(2)")).Click();
            #endregion
            //Fecha o navegador
            driver.Quit();
        }
    }
}
