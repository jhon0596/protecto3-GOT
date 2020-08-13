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
            ArchivoPersistence ap = new ArchivoPersistence();
            List<string> listaArchivos = ap.obtenerArchivos();
            return listaArchivos;


        }

        // GET: api/Archivo/5
        public IEnumerable<string> Get(int id)
        {
            ArchivoPersistence ap = new ArchivoPersistence();
            List<string> listaArchivo = ap.obtenerArchivo(id);
            return listaArchivo;
        }

        // POST: api/Archivo
        public long Post([FromBody]Archivo value)
        {
            ArchivoPersistence ap = new ArchivoPersistence();
            long id = ap.guardarArchivo(value);
            return id;
        }

        // PUT: api/Archivo/5
        public void Put(int id, [FromBody]Archivo value)
        {
            
            ArchivoPersistence ap = new ArchivoPersistence();
            ap.guardarArchivoEditado(value);

        }

        // DELETE: api/Archivo/5
        public void Delete(int id)
        {
            ArchivoPersistence ap = new ArchivoPersistence();
            ap.guardarArchivoEditado(value);
        }
    }
}
