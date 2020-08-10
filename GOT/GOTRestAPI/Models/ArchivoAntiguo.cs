using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTRestAPI.Models
{
    public class ArchivoAntiguo
    {
        public long idArchivoAntiguo { get; set; }
        public string nombreArchivoAntiguo { get; set; }
        public string tipoArchivoAntiguo { get; set; }
        public string dataArchivoAntiguo { get; set; }
        public int idListaCambios { get; set; }
        public int idRepositorio { get; set; }

    }
}