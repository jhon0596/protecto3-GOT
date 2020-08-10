using GOTRestAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOTRestAPI
{
    public class RepositorioPersistence
    {
        private MySqlConnection conexionDB;

        public RepositorioPersistence()
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

        public long guardarRepositorio(Repositorio repositorio)
        {
            string guardarRepositorio = "INSERT INTO repositorio (nombreRepositorio, cantCommit) VALUES('" + repositorio.nombreRepositorio + "','" + repositorio.cantCambios + "')";
            MySqlCommand cmd = new MySqlCommand(guardarRepositorio, conexionDB);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return id;
        }
    }
}
