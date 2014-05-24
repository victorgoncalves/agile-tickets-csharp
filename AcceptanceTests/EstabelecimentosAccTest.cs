using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium;

namespace AcceptanceTests
{
    [TestFixture]
    public class EstabelecimentosAccTest : BaseDosTestesDeAceitacao
    {        
        [Test]
        public void DeveAdicionarUmEstabelecimento()
        {
            browser.Open("/Estabelecimentos");
            browser.Type("estabelecimento.nome", "Estabelecimento X");
            browser.Type("estabelecimento.endereco", "Rua Y");
            browser.Click("adicionar");
            browser.WaitForPageToLoad("3000");

            Assert.IsTrue(browser.IsTextPresent("Estabelecimento X"));
            Assert.IsTrue(browser.IsTextPresent("Rua Y"));
        }

        [Test]
        public void NaoDeveAdicionarUmEstabelecimentoComTodosOsCamposEmBranco()
        {
            browser.Open("/Estabelecimentos");
            browser.Type("estabelecimento.nome", "");
            browser.Type("estabelecimento.endereco", "");
            browser.Click("adicionar");
            browser.WaitForPageToLoad("3000");

            Assert.IsTrue(browser.IsTextPresent("Nao inserido"));
            Assert.IsTrue(browser.IsTextPresent("verifque os dados e tente novamente."));
        }
    }
}
