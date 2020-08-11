using GOTRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GOTRestAPI.Controllers
{
    public class ArchivoController : ApiController
    {
        // GET: api/Archivo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Archivo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Archivo
        public long Post([FromBody]Archivo value)
        {
            ArchivoPersistence ap = new ArchivoPersistence();
            long id = ap.guardarArchivo(value);
            return id;
        }

        // PUT: api/Archivo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Archivo/5
        public void Delete(int id)
        {
        }
    }
}
