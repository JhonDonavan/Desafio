using Desafio.model;
using Nancy;
using Nancy.ModelBinding;
using System.Data.Entity;
using System.Linq;

namespace Desafio
{
    public class PagamentoModule : NancyModule
    {
        public PagamentoModule() : base("/payments")
        {
            var _context = new Context();
            _context.Database.CreateIfNotExists();

            //Método para fazer um pagamento
            Post["/"] = _ =>
            {
                var pagamento = this.Bind<Pagamento>();

                if ((pagamento.Cliente_Id > _context.clientes.LongCount()) || (pagamento.Estabelecimento_Id > _context.estabelecimentos.LongCount()))
                {
                    return HttpStatusCode.BadRequest;
                }

                _context.pagamentos.Add(pagamento);
                _context.SaveChanges();
                return HttpStatusCode.Created;
            };

            //Método para cancelar um pagamento
            Delete["/{id:int}"] = parameters =>
           {
               Pagamento pagamento = this.Bind<Pagamento>();
               pagamento.Id = parameters.id;

               try
               {
                   _context.Entry(pagamento).State = EntityState.Deleted;
                   _context.SaveChanges();
                   return HttpStatusCode.OK;
               }
               catch (System.Exception)
               {
                   return HttpStatusCode.NoContent;
               }
           };

            //Método para listar todos os pagamentos de um estabelecimento:
            Get["/{id:int}"] = parameters =>
            {
                int id = parameters.id;
                var pagamento = _context.pagamentos.Where(x => x.Estabelecimento_Id == id);
                return Response.AsJson(pagamento);
            };
        }
    }
}