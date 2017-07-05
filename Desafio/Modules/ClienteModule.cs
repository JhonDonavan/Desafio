using Nancy;
using Nancy.ModelBinding;
using System.Linq;


namespace Desafio
{
    public class ClienteModule : NancyModule
    {
        public ClienteModule() : base("/clients")
        {
            var _context = new Context();
            _context.Database.CreateIfNotExists();

            //Método para retornar lista de todos os clientes
            Get["/"] = _ =>
           {
               var clientes = _context.clientes.ToList();
               return Response.AsJson(clientes);
           };

            //Método para cadastrar um cliente
            Post["/"] = _ =>
            {
                var cliente = this.Bind<Cliente>();
                _context.clientes.Add(cliente);
                _context.SaveChanges();
                return HttpStatusCode.Created;
            };

            //Método para reotornar um cliente passando um id por parametro
            Get["/{id:int}"] = parameters =>
            {
                int id = parameters.id;

                if (id > _context.clientes.LongCount()) {
                    return "Não há cliente cadastrado com este ID";
                }

                var cliente = _context.clientes.FirstOrDefault(x => x.Cliente_Id == id);
                return Response.AsJson(cliente);
            };
        }
    }
}