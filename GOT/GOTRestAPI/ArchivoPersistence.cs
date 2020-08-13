using GOTRestAPI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GOTRestAPI
{
    public class ArchivoPersistence
    {
        long cantArchivo = 1; 
        long cantArchivoAntiguo = 1;
        long cantLista = 1;

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
            
            string nombreLista = "listaCambios" + archivo.nombreArchivo;
            string guardarListaCambios = "INSERT INTO listacambios (idListaCambios,nombreListaCambios) VALUES('" + cantLista + "','" + nombreLista + "')";
            MySqlCommand cmd1 = new MySqlCommand(guardarListaCambios, conexionDB);
            cmd1.ExecuteNonQuery();
            cantLista++;

            byte[] originalData = Encoding.Default.GetBytes(archivo.dataArchivo);
            uint originalDataSize = (uint)archivo.dataArchivo.Length;
            byte[] compressedData = new byte[originalDataSize * (101 / 100) + 320];
            int compressedDataSize = Huffman.Compress(originalData, compressedData, originalDataSize);
            
            string guardarArchivo = "INSERT INTO archivo (idarchivo,nombreArchivo, tipoArchivo, Data ,ListaCambios_idListaCambios,repositorio_idrepositorio ) VALUES('" + cantArchivo + "', '" + archivo.nombreArchivo + "','" + archivo.tipoArchivo + "','" + compressedData + "','" + (cantLista-1)+ "','" + archivo.idRepositorio + "')";
            MySqlCommand cmd = new MySqlCommand(guardarArchivo, conexionDB);
            cmd.ExecuteNonQuery();
            cantArchivo++;
            return cantArchivo-1;
        }
        public void guardarArchivoEditado(Archivo archivo)
        {
            ArchivoAntiguo archivoAntiguo = new ArchivoAntiguo();
            string guardarListaCambios = "SELECT * FROM archivo WHERE nombreArchivo = '" + archivo.nombreArchivo + "'"  ;
            MySqlDataReader mySqlDataReader = null;
            MySqlCommand cmd1 = new MySqlCommand(guardarListaCambios, conexionDB);
            mySqlDataReader = cmd1.ExecuteReader();
            if (mySqlDataReader.Read()) {

                archivoAntiguo.nombreArchivoAntiguo = mySqlDataReader.GetString(1);
                archivoAntiguo.tipoArchivoAntiguo = mySqlDataReader.GetString(2);
                archivoAntiguo.dataArchivoAntiguo = mySqlDataReader.GetString(3);
                archivoAntiguo.idListaCambios = mySqlDataReader.GetInt32(4);
            }
            mySqlDataReader.Close();

            
            string guardarArchivoAntiguo = "INSERT INTO archivoestadoantiguo (idarchivoEstadoAntiguo,NombreArchivoEstadoAntiguocol, tipoArchivoEstadoAntiguo, Data ,ListaCambios_idListaCambios) VALUES('" +cantArchivoAntiguo + "','" + archivoAntiguo.nombreArchivoAntiguo + "','" + archivoAntiguo.tipoArchivoAntiguo + "','" + archivoAntiguo.dataArchivoAntiguo + "','" + archivoAntiguo.idListaCambios + "')";
            MySqlCommand cmd2 = new MySqlCommand(guardarArchivoAntiguo, conexionDB);
            cmd2.ExecuteNonQuery();
            cantArchivoAntiguo++;

            byte[] originalData = Encoding.Default.GetBytes(archivo.dataArchivo);
            uint originalDataSize = (uint)archivo.dataArchivo.Length;
            byte[] compressedData = new byte[originalDataSize * (101 / 100) + 320];
            int compressedDataSize = Huffman.Compress(originalData, compressedData, originalDataSize);
            string guardarArchivo = "UPDATE archivo SET Data = '" + compressedDataSize + "' WHERE nombreArchivo ='" + archivo.nombreArchivo + "' ";
            MySqlCommand cmd = new MySqlCommand(guardarArchivo, conexionDB);
            cmd.ExecuteNonQuery();
            
            
            
        }

        public List<Archivo> obtenerArchivos()
        {
            List<Archivo> listaArchivos = new List<Archivo>();
            string guardarListaCambios = "SELECT * FROM archivo";
            MySqlDataReader mySqlDataReader = null;
            MySqlCommand cmd1 = new MySqlCommand(guardarListaCambios, conexionDB);
            mySqlDataReader = cmd1.ExecuteReader();
            while(mySqlDataReader.Read())
            {
                Archivo archivo = new Archivo();
                archivo.idArchivo = mySqlDataReader.GetUInt32(0);
                archivo.nombreArchivo = mySqlDataReader.GetString(1);
                archivo.tipoArchivo = mySqlDataReader.GetString(2);
                archivo.dataArchivo = mySqlDataReader.GetString(3);
                archivo.idListaCambios = mySqlDataReader.GetInt32(4);
                archivo.idRepositorio = mySqlDataReader.GetInt32(5);
                listaArchivos.Add(archivo);
            }
            mySqlDataReader.Close();
            return listaArchivos;

        }
        public Archivo obtenerArchivo(int id)
        {
            Archivo archivo = new Archivo();
            string guardarListaCambios = "SELECT * FROM archivo WHERE idarchivo =" + id;
            MySqlDataReader mySqlDataReader = null;
            MySqlCommand cmd1 = new MySqlCommand(guardarListaCambios, conexionDB);
            mySqlDataReader = cmd1.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                
                archivo.idArchivo = mySqlDataReader.GetUInt32(0);
                archivo.nombreArchivo = mySqlDataReader.GetString(1);
                archivo.tipoArchivo = mySqlDataReader.GetString(2);
                archivo.dataArchivo = mySqlDataReader.GetString(3);
                archivo.idListaCambios = mySqlDataReader.GetInt32(4);
                archivo.idRepositorio = mySqlDataReader.GetInt32(5);
                
            }
            return archivo;

        }
        public void eliminarArchivo(int id)
        {

            string eliminarArchivo = "DELETE FROM  archivo WHERE idarchivo =" + id;
            MySqlCommand cmd = new MySqlCommand(eliminarArchivo, conexionDB);
            cmd.ExecuteNonQuery();

        }


    }
}
