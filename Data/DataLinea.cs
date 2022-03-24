using Final_ApiAmano.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Final_ApiAmano.Data
{
    public class DataLinea
    {
        public Conexion cnn = new Conexion();

        public void Get(out List<Linea> lineas) 
        {
            lineas = new List<Linea>();
            cnn.Conectar();
            const string query = "Select * from lineas";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Linea linea = new Linea
                {
                    linea_id = Convert.ToInt32(reader["linea_id"]),
                    linea_numero = Convert.ToInt32(reader["linea_numero"])
                };
                lineas.Add(linea);
            }
            cnn.Desconectar();
        }

        public void Get(out Linea linea, int id) 
        {
            linea = new Linea();
            cnn.Conectar();
            const string query = "Select * from lineas where linea_id = @id";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Linea linea1 = new Linea
                {
                    linea_id = Convert.ToInt32(reader["linea_id"]),
                    linea_numero = Convert.ToInt32(reader["linea_numero"]),
                };
                linea=linea1;
            }
            cnn.Desconectar();
        }

        public void Post(out Linea linea, Linea linea1) 
        {
            linea=linea1;
            cnn.Conectar();
            const string query = "Insert into lineas values (@linea_numero)";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("@linea_numero", linea.linea_numero);
            cmd.ExecuteNonQuery();
            cnn.Desconectar();
            linea = this.ultimalinea();
        }

        private Linea ultimalinea()
        {
            Linea linea = new Linea();
            cnn.Conectar();
            const string query = "Select top 1 * from lineas order by linea_id desc";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Linea linea1 = new Linea
                {
                    linea_id = Convert.ToInt32(reader["linea_id"]),
                    linea_numero = Convert.ToInt32(reader["linea_numero"])                                 
                };
                linea = linea1;
            }
            cnn.Desconectar();
            return linea;
        }

        public void Put(out Linea linea, int id, Linea linea1) 
        {
            linea=linea1;
            cnn.Conectar();
            const string query = "Update lineas set linea_numero = @linea_numero where linea_id = @id";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@linea_numero", linea.linea_numero);
            cmd.ExecuteNonQuery();
            cnn.Desconectar();
            this.Get(out linea, id);
        }

        public void Delete(int id) 
        {
            try
            {
                cnn.Conectar();
                const string query = "Delete from lineas where linea_id = @id";
                SqlCommand cmd = new SqlCommand(query, cnn.Con());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cnn.Desconectar();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
