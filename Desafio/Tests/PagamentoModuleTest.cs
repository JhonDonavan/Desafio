using Nancy.Testing;
using NUnit.Framework;


namespace Desafio.Tests
{
    public class PagamentoModuleTest
    {
        [Test]
        public void Teste_cadastrar_pagamento()
        {
            var browser = new Browser(c => { c.Module<PagamentoModule>(); });
            var resultado = browser.Post("/payments", (with) =>
            {
                with.HttpsRequest();
                with.FormValue("id", "1");
                with.FormValue("valor", "10,50");
                with.FormValue("data", "04/07/2017");
                with.FormValue("cliente_id", "1");
                with.FormValue("estabelecimento_id", "1");
            });
            Assert.AreEqual(Nancy.HttpStatusCode.Created, resultado.StatusCode);
        }

        [Test]
        public void Teste_listar_pagamentos_de_um_estabelecimento()
        {
            var browser = new Browser(c => { c.Module<PagamentoModule>(); });
            var resultado = browser.Get("/payments/", (with) =>
            {
                with.HttpsRequest();
                with.FormValue("pagamento_id", "1");
            });
            Assert.AreEqual(Nancy.HttpStatusCode.OK, resultado.StatusCode);
        }

        [Test]
        public void Teste_cancelar_pagamento()
        {
            var browser = new Browser(c => { c.Module<PagamentoModule>(); });
            var resultado = browser.Delete("/payments/2", (with) =>
            {
                with.HttpsRequest();
                with.FormValue("pagamento_id", "2");
                
            });
            Assert.AreEqual(Nancy.HttpStatusCode.OK, resultado.StatusCode);
        }
    }
}