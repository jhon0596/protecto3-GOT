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
        public void guardarArchivoEditado(Archivo archivo)
        {
            ArchivoAntiguo archivoAntiguo = new ArchivoAntiguo();
            string guardarListaCambios = "SELECT * FROM archivo WHERE nombreArchivo =" + archivo.nombreArchivo;
            MySqlDataReader mySqlDataReader = null;
            MySqlCommand cmd1 = new MySqlCommand(guardarListaCambios, conexionDB);
            mySqlDataReader = cmd1.ExecuteReader();
            if (mySqlDataReader.Read()) {

                archivoAntiguo.nombreArchivoAntiguo = mySqlDataReader.GetString(1);
                archivoAntiguo.tipoArchivoAntiguo = mySqlDataReader.GetString(2);
                archivoAntiguo.dataArchivoAntiguo = mySqlDataReader.GetString(3);
                archivoAntiguo.idListaCambios = mySqlDataReader.GetInt32(4);
            }


            string guardarArchivoAntiguo = "INSERT INTO archivoestadoantiguo (NombreArchivoEstadoAntiguocol, tipoArchivoEstadoAntiguo, Data ,ListaCambios_idListaCambios) VALUES('" + archivoAntiguo.nombreArchivoAntiguo + "','" + archivoAntiguo.tipoArchivoAntiguo + "','" + archivoAntiguo.dataArchivoAntiguo + "','" + archivoAntiguo.idListaCambios + "')";
            MySqlCommand cmd2 = new MySqlCommand(guardarArchivoAntiguo, conexionDB);
            cmd2.ExecuteNonQuery();
            long idArchivoAntiguo = cmd2.LastInsertedId;


            string guardarArchivo = "UPDATE archivo SET Data = '" + archivo.dataArchivo + "' WHERE nombreArchivo ='" + archivo.nombreArchivo + "' ";
            MySqlCommand cmd = new MySqlCommand(guardarArchivo, conexionDB);
            cmd.ExecuteNonQuery();
            
            
            
        }

        public List<string> obtenerArchivos()
        {
            List<string> listaArchivos = new List<string>();
            string guardarListaCambios = "SELECT * FROM archivo";
            MySqlDataReader mySqlDataReader = null;
            MySqlCommand cmd1 = new MySqlCommand(guardarListaCambios, conexionDB);
            mySqlDataReader = cmd1.ExecuteReader();
            for (int i = 0; i< mySqlDataReader.FieldCount; i++)
            {

                listaArchivos.Add(mySqlDataReader.GetString(i));
                

            }
            return listaArchivos;

        }
        public List<string> obtenerArchivo(int id)
        {
            List<string> listaArchivo = new List<string>();
            string guardarListaCambios = "SELECT * FROM archivo WHERE idarchivo =" + id;
            MySqlDataReader mySqlDataReader = null;
            MySqlCommand cmd1 = new MySqlCommand(guardarListaCambios, conexionDB);
            mySqlDataReader = cmd1.ExecuteReader();
            for (int i = 0; i < mySqlDataReader.FieldCount; i++)
            {

                listaArchivo.Add(mySqlDataReader.GetString(i));


            }
            return listaArchivo;

        }
        public void eliminarArchivo(int id)
        {

            string eliminarArchivo = "DELETE FROM  archivo WHERE idarchivo =" + id;
            MySqlCommand cmd = new MySqlCommand(eliminarArchivo, conexionDB);
            cmd.ExecuteNonQuery();

        }


    }
}
