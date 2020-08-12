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
            return new ArchivoAntiguo[] { };
        }

        // GET: api/ArchivoAntiguo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ArchivoAntiguo





    }
}
