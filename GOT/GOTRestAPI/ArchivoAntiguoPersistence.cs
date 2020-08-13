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
        public List<ArchivoAntiguo> obtenerArchivosAntiguos()
        {
            List<ArchivoAntiguo> listaArchivosAntiguos = new List<ArchivoAntiguo>();
            string guardarListaCambios = "SELECT * FROM archivoestadoantiguo";
            MySqlDataReader mySqlDataReader = null;
            MySqlCommand cmd1 = new MySqlCommand(guardarListaCambios, conexionDB);
            mySqlDataReader = cmd1.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                ArchivoAntiguo archivo = new ArchivoAntiguo();
                archivo.idArchivoAntiguo = mySqlDataReader.GetUInt32(0);
                archivo.nombreArchivoAntiguo = mySqlDataReader.GetString(1);
                archivo.tipoArchivoAntiguo = mySqlDataReader.GetString(2);
                archivo.dataArchivoAntiguo = mySqlDataReader.GetString(3);
                archivo.idListaCambios = mySqlDataReader.GetInt32(4);
                archivo.idRepositorio = mySqlDataReader.GetInt32(5);

                listaArchivosAntiguos.Add(archivo);
            }
            mySqlDataReader.Close();
            return listaArchivosAntiguos;

        }
        public ArchivoAntiguo obtenerArchivoAntiguo(int id)
        {
            ArchivoAntiguo archivoAntiguo = new ArchivoAntiguo();
            string guardarListaCambios = "SELECT * FROM archivoestadoantiguo WHERE idarchivoEstadoAntiguo =" + id;
            MySqlDataReader mySqlDataReader = null;
            MySqlCommand cmd1 = new MySqlCommand(guardarListaCambios, conexionDB);
            mySqlDataReader = cmd1.ExecuteReader();
            while (mySqlDataReader.Read())
            {

                archivoAntiguo.idArchivoAntiguo = mySqlDataReader.GetUInt32(0);
                archivoAntiguo.nombreArchivoAntiguo = mySqlDataReader.GetString(1);
                archivoAntiguo.tipoArchivoAntiguo = mySqlDataReader.GetString(2);
                archivoAntiguo.dataArchivoAntiguo = mySqlDataReader.GetString(3);
                archivoAntiguo.idListaCambios = mySqlDataReader.GetInt32(4);
                archivoAntiguo.idRepositorio = mySqlDataReader.GetInt32(5);


            }
            return archivoAntiguo;

        }
    }
}