using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTRestAPI.Models
{
    public class Repositorio
    {
        public long idRepositorio { get; set; }

        public string nombreRepositorio { get; set; }

        public int cantCambios { get; set; }
    }
}