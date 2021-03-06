﻿using GOTRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GOTRestAPI.Controllers
{
    public class RepositorioController : ApiController
    {
        // GET: api/Repositorio
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Repositorio/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Repositorio
        public long Post([FromBody]Repositorio value)
        {
            RepositorioPersistence ap = new RepositorioPersistence();
            long id = ap.guardarRepositorio(value);
            return id;
        }

        // PUT: api/Repositorio/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Repositorio/5
        public void Delete(int id)
        {
        }
    }
}
