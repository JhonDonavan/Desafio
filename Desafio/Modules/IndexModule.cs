using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Desafio
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ =>
                {
                    return "Bem vindo ao Nancy";
                };
        }
    }
}