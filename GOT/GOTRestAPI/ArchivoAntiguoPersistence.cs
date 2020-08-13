using GOTRestAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTRestAPI
{
    public class ArchivoAntiguoPersistence
    {
        private MySqlConnection conexionDB;
        public ArchivoAntiguoPersistence()
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
        public List<string> obtenerArchivosAntiguos()
        {
            List<string> listaArchivosAntiguos = new List<string>();
            string guardarListaCambios = "SELECT * FROM archivoestadoantiguo";
            MySqlDataReader mySqlDataReader = null;
            MySqlCommand cmd1 = new MySqlCommand(guardarListaCambios, conexionDB);
            mySqlDataReader = cmd1.ExecuteReader();
            for (int i = 0; i < mySqlDataReader.FieldCount; i++)
            {

                listaArchivosAntiguos.Add(mySqlDataReader.GetString(i));


            }
            return listaArchivosAntiguos;

        }
        public List<string> obtenerArchivoAntiguo(int id)
        {
            List<string> listaArchivoAntiguo = new List<string>();
            string guardarListaCambios = "SELECT * FROM archivoestadoantiguo WHERE idarchivoEstadoAntiguo =" + id;
            MySqlDataReader mySqlDataReader = null;
            MySqlCommand cmd1 = new MySqlCommand(guardarListaCambios, conexionDB);
            mySqlDataReader = cmd1.ExecuteReader();
            for (int i = 0; i < mySqlDataReader.FieldCount; i++)
            {

                listaArchivoAntiguo.Add(mySqlDataReader.GetString(i));


            }
            return listaArchivoAntiguo;

        }
    }
}