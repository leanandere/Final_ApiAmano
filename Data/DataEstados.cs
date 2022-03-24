using Final_ApiAmano.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Final_ApiAmano.Data
{
    public class DataEstados
    {
        public Conexion cnn = new Conexion();


        public void Put(out Estado estado, int id, Estado estado1)
        {
            estado = estado1;
           // estado = this.BuscarEstado(id);
            bool est = false;
            if (!estado.estado)
            {
                est = true;
            }
            cnn.Conectar();
            const string query = "Update estados set estado = @estado where estados.estado_id = @id";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("@id", estado.estado_id);
            cmd.Parameters.AddWithValue("@estado", est);

            cmd.ExecuteNonQuery();

            cnn.Desconectar();


          //  this.Get(out estado, id);


        }


        private Estado BuscarEstado(int id)
        {
            Estado estado = new Estado();
            cnn.Conectar();
            const string query = "Select top 1 * from estados where estado_id=@id order by estado_id desc";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Estado est = new Estado {
                    estado_id = Convert.ToInt32(reader["estado_id"]),
                    estado=Convert.ToBoolean(reader["estado"]),
                    nota = Convert.ToString(reader["nota"])
                };
              
            }
            cnn.Desconectar();
            return estado;
        }


    }
}
