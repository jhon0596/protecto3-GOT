using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTRestAPI.Models
{
    public class Archivo
    {
        public long idArchivo { get; set; }
        public string nombreArchivo { get; set; }
        public string tipoArchivo { get; set; }
        public string dataArchivo { get; set; }
        public int idListaCambios { get; set; }
        public int idRepositorio { get; set; }
    }
}