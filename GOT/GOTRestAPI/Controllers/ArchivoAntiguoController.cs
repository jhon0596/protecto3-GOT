using GOTRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GOTRestAPI.Controllers
{
    public class ArchivoAntiguoController : ApiController
    {
        // GET: api/ArchivoAntiguo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ArchivoAntiguo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ArchivoAntiguo
        public long Post([FromBody] Archivo value)
        {
            ArchivoPersistence ap = new ArchivoPersistence();
            long id = ap.guardarArchivo(value);
            return id;

        }

        // PUT: api/ArchivoAntiguo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ArchivoAntiguo/5
        public void Delete(int id)
        {
        }
    }
}
