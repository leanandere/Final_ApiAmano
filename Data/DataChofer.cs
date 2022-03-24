using Final_ApiAmano.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Final_ApiAmano.Data
{
    public class DataChofer
    {
        public Conexion cnn = new Conexion();

        public void Get(out List<Chofer>choferes) 
        {
            choferes = new List<Chofer>();
            cnn.Conectar();
            const string query = "Select * from choferes";
            SqlCommand cmd = new SqlCommand(query,cnn.Con());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                Chofer chofer = new Chofer {
                    chofer_id = Convert.ToInt32(reader["chofer_id"]),
                    chofer_nombre=Convert.ToString(reader["chofer_nombre"]),
                    chofer_apellido=Convert.ToString(reader["chofer_apellido"]),
                    chofer_dni=Convert.ToString(reader["chofer_dni"]),
                    chofer_telefono=Convert.ToString(reader["chofer_telefono"]),
                };
                choferes.Add(chofer);
            }
            cnn.Desconectar();
        }

        public void Get(out Chofer chofer, int id) 
        {
            chofer = new Chofer();
            cnn.Conectar();
            const string query = "Select * from choferes where chofer_id = @id ";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Chofer chofer1 = new Chofer
                {
                    chofer_id = Convert.ToInt32(reader["chofer_id"]),
                    chofer_nombre = Convert.ToString(reader["chofer_nombre"]),
                    chofer_apellido = Convert.ToString(reader["chofer_apellido"]),
                    chofer_dni = Convert.ToString(reader["chofer_dni"]),
                    chofer_telefono = Convert.ToString(reader["chofer_telefono"]),
                };
                chofer=chofer1;
            }
            cnn.Desconectar();
        }

        public void Post(out Chofer chofer, Chofer chofer1) 
        {
            chofer = chofer1;
            cnn.Conectar();
            const string query = "Insert into choferes values (@chofer_nombre, @chofer_apellido, @chofer_dni, @chofer_telefono)";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("@chofer_nombre", chofer.chofer_nombre);
            cmd.Parameters.AddWithValue("@chofer_apellido", chofer.chofer_apellido);
            cmd.Parameters.AddWithValue("@chofer_dni", chofer.chofer_dni);
            cmd.Parameters.AddWithValue("@chofer_telefono", chofer.chofer_telefono);
            cmd.ExecuteNonQuery();
            cnn.Desconectar();
            chofer = this.Ultimochofer();

        }

        private Chofer Ultimochofer()
        {
            Chofer chofer = new Chofer();
            cnn.Conectar();
            const string query = "Select top 1 * from choferes order by chofer_id desc";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Chofer chofer1 = new Chofer
                {
                    chofer_id = Convert.ToInt32(reader["chofer_id"]),
                    chofer_nombre = Convert.ToString(reader["chofer_nombre"]),
                    chofer_apellido = Convert.ToString(reader["chofer_apellido"]),
                    chofer_dni = Convert.ToString(reader["chofer_dni"]),
                    chofer_telefono = Convert.ToString(reader["chofer_telefono"]),
                };
                chofer = chofer1;
            }
            cnn.Desconectar();
            return chofer;

        }

        public void Put(out Chofer chofer,int id,Chofer chofer1) 
        {
            chofer = chofer1;
            cnn.Conectar();
            const string query = "Update choferes set chofer_nombre = @chofer_nombre, chofer_apellido = @chofer_apellido, chofer_dni = @chofer_dni, chofer_telefono = @chofer_telefono where chofer_id = @id";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@chofer_nombre", chofer.chofer_nombre);
            cmd.Parameters.AddWithValue("@chofer_apellido", chofer.chofer_apellido);
            cmd.Parameters.AddWithValue("@chofer_dni", chofer.chofer_dni);
            cmd.Parameters.AddWithValue("@chofer_telefono", chofer.chofer_telefono);
            cmd.ExecuteNonQuery();
            cnn.Desconectar();
            this.Get(out chofer, id);

        }

        public void Delete(int id) 
        {
            try
            {
                cnn.Conectar();
                const string query = "Delete from choferes where chofer_id = @id";
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
