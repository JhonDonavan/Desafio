using Desafio.model;
using Nancy;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace Desafio
{

    public class EstabelecimentoModule : NancyModule
    {
        public EstabelecimentoModule() : base("/establishments")
        {
            var _context = new Context();
            _context.Database.CreateIfNotExists();

            //Método para retornar lista de todos os estabelecimentos
            Get["/"] = _ =>
            {
                var estabelecimentos = _context.estabelecimentos.ToList();
                return Response.AsJson(estabelecimentos);
            };

            //Método para cadastrar um estabelecimento
            Post["/"] = _ =>
            {
                string cnpj = Request.Form["cnpj"];

                var requisicaoCnpj = WebRequest.CreateHttp("https://www.receitaws.com.br/v1/cnpj/" + cnpj);
                requisicaoCnpj.Method = "GET";
                requisicaoCnpj.UserAgent = "Requisição de CNPJ";

                try
                {
                    using (var resposta = requisicaoCnpj.GetResponse())
                    {
                        var streamDados = resposta.GetResponseStream();
                        StreamReader reader = new StreamReader(streamDados);
                        object objResponse = reader.ReadToEnd();
                        var estabelecimento = JsonConvert.DeserializeObject<Estabelecimento>(objResponse.ToString());

                        if (estabelecimento.Cnpj == null)
                        {
                            return Nancy.HttpStatusCode.BadRequest;
                        }

                        streamDados.Close();
                        resposta.Close();

                        _context.estabelecimentos.Add(estabelecimento);
                        _context.SaveChanges();
                        return Nancy.HttpStatusCode.Created;
                    };
                }
                catch (Exception)
                {
                    return Nancy.HttpStatusCode.GatewayTimeout;
                }
            };

            //Método para retornar um estabelecimento por id
            Get["/{id:int}"] = parameters =>
            {
                int id = parameters.id;

                if (id > _context.estabelecimentos.LongCount()) {
                    return "Não há estabelecimentos cadastrados com este ID";
                }

                var estabelecimento = _context.estabelecimentos.FirstOrDefault(x => x.Estabelecimento_Id == id);
                return Response.AsJson(estabelecimento);
            };
        }
    }
}

