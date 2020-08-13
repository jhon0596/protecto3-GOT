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
            ArchivoAntiguoPersistence aap = new ArchivoAntiguoPersistence();
            List<string> listaArchivosAntiguos = aap.obtenerArchivosAntiguos();
            return listaArchivosAntiguos;
        }

        // GET: api/ArchivoAntiguo/5
        public IEnumerable<string> Get(int id)
        {
            ArchivoAntiguoPersistence aap = new ArchivoAntiguoPersistence();
            List<string> listaArchivosAntiguo = aap.obtenerArchivoAntiguo(id);
            return listaArchivosAntiguo;
        }

   





    }
}
