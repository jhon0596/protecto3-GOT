using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GOTRestAPI.Controllers
{
    public class ListaArchivosAntiguosController : ApiController
    {
        // GET: api/ListaArchivosAntiguos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListaArchivosAntiguos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ListaArchivosAntiguos
        public void Post([FromBody]string value)
        {
        }

        
        
    }
}
