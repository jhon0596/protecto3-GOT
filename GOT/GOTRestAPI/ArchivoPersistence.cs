using GOTRestAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTRestAPI
{
    public class ArchivoPersistence
    {

        private MySqlConnection conexionDB;
        public ArchivoPersistence()
        {

            try
            {
                conexionDB = new MySqlConnection("server=127.0.0.1;uid=root;pwd=12345;database=GOTdb");
                conexionDB.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error a conectar");
            }

        }

        public long guardarArchivo(Archivo archivo)
        {
            string guardarListaCambios = "INSERT INTO listacambios (nombreListaCambios) VALUES('" + "listaCambios" + archivo.nombreArchivo + "')";
            MySqlCommand cmd1 = new MySqlCommand(guardarListaCambios, conexionDB);
            cmd1.ExecuteNonQuery();
            long idListaCambios = cmd1.LastInsertedId;


            string guardarArchivo = "INSERT INTO archivo (nombreArchivo, tipoArchivo, Data ,ListaCambios_idListaCambios,repositorio_idrepositorio ) VALUES('" + archivo.nombreArchivo + "','" + archivo.tipoArchivo + "','" + archivo.dataArchivo + "','" + idListaCambios + "','" + archivo.idRepositorio + "')";
            MySqlCommand cmd = new MySqlCommand(guardarArchivo, conexionDB);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return id;
        }

        public long guardarArchivoAntiguo(Archivo archivo)
        {
            string guardarListaCambios = "INSERT INTO listacambios (nombreListaCambios) VALUES('" + "listaCambios" + archivo.nombreArchivo + "')";
            MySqlCommand cmd1 = new MySqlCommand(guardarListaCambios, conexionDB);
            cmd1.ExecuteNonQuery();
            long idListaCambios = cmd1.LastInsertedId;


            string guardarArchivo = "INSERT INTO archivo (nombreArchivo, tipoArchivo, Data ,ListaCambios_idListaCambios,repositorio_idrepositorio ) VALUES('" + archivo.nombreArchivo + "','" + archivo.tipoArchivo + "','" + archivo.dataArchivo + "','" + idListaCambios + "','" + archivo.idRepositorio + "')";
            MySqlCommand cmd = new MySqlCommand(guardarArchivo, conexionDB);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return id;
        }
    }
}
