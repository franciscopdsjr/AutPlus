using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using com.sun.tools.@internal.xjc;
using java.util.concurrent;
using System;
using java.lang;
using String = System.String;
using TakeTestExemplo;
using TakeTestExemplo.ClassesNavega;

namespace Portal
{
    [TestClass]
    public class CadastrarDocMaisVendedor
    {
        [TestMethod]
        public void CadastraDocMaisVendedor()
        {

            #region Abrir o Chrome
            //inicializando o chrome
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://main.safety8.local/#/login?cnpj=72.408.271%2F0001-91");
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(5000);
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

            driver.FindElement(By.CssSelector(".ng-scope > .animated")).Click();
            driver.FindElement(By.Id("usuario")).Click();
            driver.FindElement(By.Id("usuario")).SendKeys(login.RetornaUsuario());
            driver.FindElement(By.Id("senha")).SendKeys(login.RetornaSenha());
            driver.FindElement(By.CssSelector(".button-login-q")).Click();
            #endregion

            #region Cadastrar Documento com mais de um vendedor
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            //Busca o cliente
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[1]/vs-portal-consultas-directive/div/div/div/div[3]/div")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[1]/vs-portal-consultas-directive/div/div/div/div[3]/div/input")).SendKeys("fausto silva");
            //Clica na busca
            driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div:nth-child(1) > vs-portal-consultas-directive > div > div > div > div:nth-child(3) > div > span > button")).Click();

            //Selecionar o cliente buscado
            System.Threading.Thread.Sleep(6000);//Aguardando a pagina carregar
                                                // driver.FindElement(By.CssSelector("div:nth-child(5) > div.container-fluid > div:nth-child(3) > div.index-conteudo.ng-scope.animated.fadeIn.conteudo-geral > div > div > div.col-sm-12.col-lg-9 > div > div > div:nth-child(2) > div.col-lg-12.col-md-12.col-sm-12 > div > div.card-body.card-padding.ng-scope > div > div:nth-child(1) > div > h3 > a")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/div/div[2]/div/div/div[2]/div[1]/div/div[3]/div/div[1]/div/h3/a")).Click();
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            //Clicar em Seguros
            driver.FindElement(By.XPath("/html/body/div[5]/div[1]/nav/div[3]/div/vs-menu-responsivo/div/div[2]/div/div/ul/li[2]/a")).Click();

            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            //Clicar em Incluir
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div/vs-relacao3/div/div/div/div/div/div/div[1]/button")).Click();

            //Seleciona a cia
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_cia_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_cia_codigo")).SendKeys("porto");
            driver.FindElement(By.CssSelector("strong")).Click();

            //Seleciona o Produto
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_ramo_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_ramo_codigo")).SendKeys("AERO");
            driver.FindElement(By.CssSelector("strong")).Click();

            //Seleciona Origem
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_docori_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_docori_codigo")).SendKeys("geral");
            driver.FindElement(By.CssSelector("strong")).Click();

            //Seleciona Ponto de Venda
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_pto_codigo")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_pto_codigo")).Clear();//Limpar o Campo
            driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_pto_codigo")).SendKeys("matriz");
            driver.FindElement(By.CssSelector("strong")).Click();

            //Salvar
            driver.FindElement(By.CssSelector(".container-fluid > .row")).Click();
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();

            //MouseOver pra selecionar o Botão valores
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(3);//Aguardando a pagina carregar
            System.Threading.Thread.Sleep(60000);//Aguardando a pagina carregar
           //  driver.FindElement(By.Name("frmAutoFormdocumentosundefined_edt_pto_codigo")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[4]/div[2]/div")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".var_nav:nth-child(6) span"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Release().Perform();
            }
            {
                var element = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[4]/div[2]/div"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }

            //Valores
            System.Threading.Thread.Sleep(4000);
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[4]/div[2]/a")).Click();

            //Clicar no Editar
            System.Threading.Thread.Sleep(4000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[5]/div[3]/div[2]/div/div/vs-botoes3/div/div/div[1]/button[1]")).Click();

            //Parcelas
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.Name("frmAutoFormdocumentosValoresundefined_edt_doc_qtd_parcelas")).SendKeys("5,0");

            //Comissão Total
            driver.ExecuteJavaScript("window.scroll(0,1000)");//Scroll na página
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.Name("frmAutoFormdocumentosValoresundefined_edt_doc_perc_comissao_total")).Clear();
            driver.FindElement(By.Name("frmAutoFormdocumentosValoresundefined_edt_doc_perc_comissao_total")).SendKeys("20,00");
            driver.FindElement(By.Name("frmAutoFormdocumentosValoresundefined_edt_doc_perc_comissao")).Clear();
            driver.FindElement(By.Name("frmAutoFormdocumentosValoresundefined_edt_doc_perc_comissao")).SendKeys("20,00");

            //Premio
            //driver.ExecuteJavaScript("window.scroll(0,1000)");
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.Name("frmAutoFormdocumentosValoresundefined_edt_doc_premio_liquido")).SendKeys("2.000");
            driver.FindElement(By.Name("frmAutoFormdocumentosValoresundefined_edt_doc_premio_total")).SendKeys("2.147,60");

            //Salvar
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            {
                var element = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[6]/div[2]/div"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            //Repasses
            //driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[5]/div[2]/div")).Click();
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[6]/div[2]/a")).Click();
            System.Threading.Thread.Sleep(1500);
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[6]/div[2]/a/span")).Click();
            driver.FindElement(By.CssSelector(".confirm")).Click();

            //Incluir
            driver.FindElement(By.CssSelector(".btn-raised")).Click();
            driver.FindElement(By.Id("comboundefined")).Click();
            driver.FindElement(By.Id("comboundefined")).SendKeys("francisco teste");
            driver.FindElement(By.CssSelector("strong")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosRepasseundefined_edt_rep_percentual")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosRepasseundefined_edt_rep_percentual")).SendKeys("50");
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            {
                var element = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[6]/div[2]/div"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            {
                var element = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[6]/div[2]/div"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }

            //Cadastrando segundo vendedor
            driver.FindElement(By.LinkText("Repasses")).Click();
            System.Threading.Thread.Sleep(5000);//Aguardando a pagina carregar
            driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[4]/div[5]/div[2]/vs-relacao3/div/div/div/div/div/div/div[1]/button")).Click();
            driver.FindElement(By.Id("comboundefined")).SendKeys("f");
            driver.FindElement(By.Id("comboundefined")).SendKeys("r");
            driver.FindElement(By.Id("comboundefined")).SendKeys("a");
            driver.FindElement(By.Id("comboundefined")).SendKeys("n");
            driver.FindElement(By.Id("comboundefined")).SendKeys("c");
            driver.FindElement(By.LinkText("FRANCISCO")).Click();
            driver.FindElement(By.CssSelector("div:nth-child(1) > .col-md-6")).Click();
            driver.FindElement(By.Name("frmAutoFormdocumentosRepasseundefined_edt_rep_percentual")).SendKeys("50");
            driver.FindElement(By.CssSelector("div:nth-child(2) > .botoes-bottom-verde")).Click();
            {
                var element = driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div[3]/div[1]/div/ul/li[6]/div[2]/div"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            #endregion
            driver.FindElement(By.XPath("//*[@id=\"menuTopo\"]/div[1]/a")).Click();
            System.Threading.Thread.Sleep(2000);
            //Fecha o navegador
            // MetodosNavega.SairPlus(driver);

            driver.Quit();
        }
    }
}
