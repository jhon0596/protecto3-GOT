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
        public IEnumerable<ArchivoAntiguo> Get()
        {
            ArchivoAntiguoPersistence aap = new ArchivoAntiguoPersistence();
            List<ArchivoAntiguo> listaArchivosAntiguos = aap.obtenerArchivosAntiguos();
            return listaArchivosAntiguos;
        }

        // GET: api/ArchivoAntiguo/5
        public ArchivoAntiguo Get(int id)
        {
            ArchivoAntiguoPersistence aap = new ArchivoAntiguoPersistence();
            ArchivoAntiguo archivoAntiguo  = aap.obtenerArchivoAntiguo(id);
            return archivoAntiguo;
        }

   





    }
}
