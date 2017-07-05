using Nancy.Testing;
using NUnit.Framework;


namespace Desafio.Tests
{
    public class ClienteModuleTest
    {
        [Test]
        public void Teste_cadastrar_cliente()
        {
            var browser = new Browser(c => { c.Module<ClienteModule>(); });
            var resultado = browser.Post("/clients", (with) =>
            {
                with.HttpsRequest();
                with.FormValue("id", "1");
                with.FormValue("nome", "jhon oliveira");
                with.FormValue("cpf", "14493423158");
                with.FormValue("dataNascimento", "11/06/1991");
                with.FormValue("numCartao", "2568752254123985");
            });
            Assert.AreEqual(Nancy.HttpStatusCode.Created, resultado.StatusCode);
        }

        [Test]
        public void Teste_buscar_cliente_por_id()
        {
            var browser = new Browser(c => { c.Module<ClienteModule>(); });
            var resultado = browser.Get("/clients", (with) =>
            {
                with.HttpsRequest();
                with.FormValue("id", "1");
            });
            Assert.AreEqual(Nancy.HttpStatusCode.OK, resultado.StatusCode);
        }

        [Test]
        public void Teste_listar_todos_clientes()
        {
            var browser = new Browser(c => { c.Module<ClienteModule>(); });
            var resultado = browser.Get("/clients", (with) =>
            {
                with.HttpsRequest();
            });
            Assert.AreEqual(Nancy.HttpStatusCode.OK, resultado.StatusCode);
        }

        [Test]
        public void Teste_rota_cadastrar_cliente()
        {
            var browser = new Browser(c => { c.Module<ClienteModule>(); });
            var resultado = browser.Post("/clients", context =>
           {
               context.Header("Teste", "Testando rota cadastro de cliente");
               context.HttpsRequest();
           });
            Assert.AreEqual(Nancy.HttpStatusCode.Created, resultado.StatusCode);
        }

        [Test]
        public void Teste_rota_listar_todos_clientes()
        {
            var browser = new Browser(c => { c.Module<ClienteModule>(); });
            var resultado = browser.Get("/clients", context =>
            {
                context.Header("Teste", "Testando rota buscar todos clientes");
                context.HttpsRequest();
            });
            Assert.AreEqual(Nancy.HttpStatusCode.OK, resultado.StatusCode);
        }

        [Test]
        public void Teste_rota_buscar_cliente_id()
        {
            var browser = new Browser(c => { c.Module<ClienteModule>(); });
            var resultado = browser.Get("/clients/1", context =>
            {
                context.Header("Teste", "Testando rota busca de cliente por id");
                context.HttpsRequest();
            });
            Assert.AreEqual(Nancy.HttpStatusCode.OK, resultado.StatusCode);
        }
    }
}