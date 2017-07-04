using Nancy.Testing;
using NUnit.Framework;

namespace Desafio.Tests
{
    public class EstabelecimentoModuleTest
    {
        [Test]
        public void Teste_cadastrar_estabelecimento()
        {
            var browser = new Browser(c => { c.Module<EstabelecimentoModule>(); });
            var resultado = browser.Post("/establishments/", (with) =>
            {
                with.HttpsRequest();
                with.FormValue("cnpj", "27865757000102");
            });
            Assert.AreEqual(Nancy.HttpStatusCode.Created, resultado.StatusCode);
        }

		[Test]
        public void Test_listar_todosEstabelecimentos()
        {
            var browser = new Browser(c => { c.Module<EstabelecimentoModule>(); });
            var resultado = browser.Get("/establishments", (with) =>
            {
                with.HttpsRequest();
            });
            Assert.AreEqual(Nancy.HttpStatusCode.OK, resultado.StatusCode);
        }

        [Test]
        public void Test_buscar_estabelecimento_por_id()
        {
            var browser = new Browser(c => { c.Module<EstabelecimentoModule>(); });
            var resultado = browser.Get("/establishments/", (with) =>
            {
                with.HttpsRequest();
                with.FormValue("id", "1");
            });
            Assert.AreEqual(Nancy.HttpStatusCode.OK, resultado.StatusCode);
        }
		
        [Test]
        public void Teste_rota_buscar_estabelecimento_por_id()
        {
            var browser = new Browser(c => { c.Module<EstabelecimentoModule>(); });
            var resultado = browser.Get("/establishments", context =>
            {
                context.Header("Teste", "Testando busca de estabelecimento por id");
                context.HttpsRequest();
            });
            Assert.AreEqual(Nancy.HttpStatusCode.OK, resultado.StatusCode);
        }

        [Test]
        public void Test_rota_listar_todos_estabelecimentos()
        {
            var browser = new Browser(c => { c.Module<EstabelecimentoModule>(); });
            var resultado = browser.Get("/establishments", context =>
            {
                context.Header("Teste", "Testando rota de busca de todos os estabelecimentos");
                context.HttpsRequest();
            });
            Assert.AreEqual(Nancy.HttpStatusCode.OK, resultado.StatusCode);
        }
    }
}