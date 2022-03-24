using Final_ApiAmano.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Final_ApiAmano.Data
{
    public class DataTipo
    {
        public Conexion cnn = new Conexion();

        public void Get(out List<Tipo> tipos)
        {
            tipos = new List<Tipo>();
            cnn.Conectar();
            const string query = "Select * from tipos";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tipo tipo = new Tipo
                {
                    tipo_id = Convert.ToInt32(reader["tipo_id"]),
                    tipo_nombre = Convert.ToString(reader["tipo_nombre"])
                };
                tipos.Add(tipo);
            }
            cnn.Desconectar();
        }

        public void Get(out Tipo tipo, int id)
        {
            tipo = new Tipo();
            cnn.Conectar();
            const string query = "Select * from tipos where tipo_id = @id";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tipo tipo1 = new Tipo
                {
                    tipo_id = Convert.ToInt32(reader["tipo_id"]),
                    tipo_nombre = Convert.ToString(reader["tipo_nombre"]),
                };
                tipo = tipo1;
            }
            cnn.Desconectar();
        }

        public void Post(out Tipo tipo, Tipo tipo1)
        {
            tipo = tipo1;
            cnn.Conectar();
            const string query = "Insert into tipos values (@tipo_nombre)";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("@tipo_nombre", tipo.tipo_nombre);
            cmd.ExecuteNonQuery();
            cnn.Desconectar();
            tipo = this.ultimotipo();
        }

        private Tipo ultimotipo()
        {
            Tipo tipo = new Tipo();
            cnn.Conectar();
            const string query = "Select top 1 * from tipos order by tipo_id desc";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tipo tipo1 = new Tipo
                {
                    tipo_id = Convert.ToInt32(reader["tipo_id"]),
                    tipo_nombre = Convert.ToString(reader["tipo_nombre"])
                };
                tipo = tipo1;
            }
            cnn.Desconectar();
            return tipo;
        }

        public void Put(out Tipo tipo, int id, Tipo tipo1)
        {
            tipo = tipo1;
            cnn.Conectar();
            const string query = "Update tipos set tipo_nombre = @tipo_nombre where tipo_id = @id";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@tipo_nombre", tipo.tipo_nombre);
            cmd.ExecuteNonQuery();
            cnn.Desconectar();
            this.Get(out tipo, id);
        }

        public void Delete(int id)
        {
            try
            {
                cnn.Conectar();
                const string query = "Delete from tipos where tipo_id = @id";
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