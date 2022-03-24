using Final_ApiAmano.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Final_ApiAmano.Data
{
    public class DataColectivo
    {
        public Conexion cnn = new Conexion();

        public void Get(out List<Colectivo> colectivos)  //getall
        {
            colectivos = new List<Colectivo>();
            cnn.Conectar();
            const string query = "Select * from colectivos inner join datos on colectivos.colectivo_datos = datos.datos_id inner join estados on colectivos.colectivo_estado = estados.estado_id";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Datos datos1 = new Datos
                {
                    datos_id = Convert.ToInt32(reader["datos_id"]),
                    datos_marca = Convert.ToString(reader["datos_marca"]),
                    datos_modelo = Convert.ToString(reader["datos_modelo"]),
                    datos_anio = Convert.ToInt32(reader["datos_anio"])
                };

                Estado est = new Estado
                {
                    estado_id = Convert.ToInt32(reader["estado_id"]),
                    estado = Convert.ToBoolean(reader["estado"]),
                    nota= Convert.ToString(reader["nota"])
                };
                Colectivo colectivo = new Colectivo
                {
                    colectivo_id = Convert.ToInt32(reader["colectivo_id"]),
                    colectivo_dominio = Convert.ToString(reader["colectivo_dominio"]),
                    colectivo_tipo = Convert.ToInt32(reader["colectivo_tipo"]),
                    colectivo_linea = Convert.ToInt32(reader["colectivo_linea"]),
                    colectivo_chofer = Convert.ToInt32(reader["colectivo_chofer"]),
                    datos = datos1,
                    estado = est
                };
                colectivos.Add(colectivo);
            }
            cnn.Desconectar();
        }
        public void Get(out Colectivo colectivo, int id)  // get por id
        {
            colectivo = new Colectivo();
            cnn.Conectar();
            const string query = "Select * from colectivos inner join datos on colectivos.colectivo_datos = datos.datos_id inner join estados on colectivos.colectivo_estado = estados.estado_id where colectivos.colectivo_id=@id ";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Datos datos1 = new Datos
                {
                    datos_id = Convert.ToInt32(reader["datos_id"]),
                    datos_marca = Convert.ToString(reader["datos_marca"]),
                    datos_modelo = Convert.ToString(reader["datos_modelo"]),
                    datos_anio = Convert.ToInt32(reader["datos_anio"])
                };
                Estado est = new Estado
                {
                    estado_id = Convert.ToInt32(reader["estado_id"]),
                    estado = Convert.ToBoolean(reader["estado"]),
                    nota = Convert.ToString(reader["nota"])
                };

                Colectivo colectivo1 = new Colectivo
                {
                    colectivo_id = Convert.ToInt32(reader["colectivo_id"]),
                    colectivo_dominio = Convert.ToString(reader["colectivo_dominio"]),
                    colectivo_tipo = Convert.ToInt32(reader["colectivo_tipo"]),
                    colectivo_linea = Convert.ToInt32(reader["colectivo_linea"]),
                    colectivo_chofer = Convert.ToInt32(reader["colectivo_chofer"]),
                    datos = datos1,
                    estado = est
                };

                colectivo = colectivo1;
            }
            cnn.Desconectar();
        }

        public void Post(out Colectivo colectivo, Colectivo colectivo1) 
        {
            colectivo = colectivo1;
            
            cnn.Conectar();
            const string query = "Insert into datos values (@datos_marca, @datos_modelo, @datos_anio)";           
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("@datos_marca", colectivo.datos.datos_marca);
            cmd.Parameters.AddWithValue("@datos_modelo", colectivo.datos.datos_modelo);
            cmd.Parameters.AddWithValue("@datos_anio", colectivo.datos.datos_anio);
            cmd.ExecuteNonQuery();

            cnn.Desconectar();

            int datosid = this.Ultimodato();

            cnn.Conectar();

            const string query3 = "Insert into estados values (@estado, @nota)";
            SqlCommand cmd3 = new SqlCommand(query3, cnn.Con());
            cmd3.Parameters.AddWithValue("@estado", 1);
            cmd3.Parameters.AddWithValue("@nota", colectivo.estado.nota);
            cmd3.ExecuteNonQuery();

            cnn.Desconectar();

            int estadoid = this.Ultimoestado();

            cnn.Conectar();
            const string query2 = "Insert into colectivos (colectivo_dominio,colectivo_tipo,colectivo_linea,colectivo_chofer,colectivo_datos,colectivo_estado)values (@colectivo_dominio, @colectivo_tipo, @colectivo_linea,@colectivo_chofer,@colectivo_datos,@colectivo_estado)";
            SqlCommand cmd2 = new SqlCommand(query2, cnn.Con());
            cmd2.Parameters.AddWithValue("@colectivo_dominio", colectivo.colectivo_dominio);
            cmd2.Parameters.AddWithValue("@colectivo_tipo", colectivo.colectivo_tipo);
            cmd2.Parameters.AddWithValue("@colectivo_linea", colectivo.colectivo_linea);
            cmd2.Parameters.AddWithValue("@colectivo_chofer", colectivo.colectivo_chofer);
            cmd2.Parameters.AddWithValue("@colectivo_datos", datosid);
            cmd2.Parameters.AddWithValue("@colectivo_estado", estadoid);
           
            cmd2.ExecuteNonQuery();
            
            cnn.Desconectar();

            colectivo = this.Ultimocolectivo();
        }

        private int Ultimodato()
        {
            int datos = 0;
            cnn.Conectar();
            const string query = "Select top 1 datos_id from datos order by datos_id desc";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                datos = Convert.ToInt32(reader["datos_id"]);                                   
            }
            cnn.Desconectar();
            return datos;
        }

        private int Ultimoestado()
        {
            int estado = 0;
            cnn.Conectar();
            const string query = "Select top 1 estado_id from estados order by estado_id desc";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                estado = Convert.ToInt32(reader["estado_id"]);
            }
            cnn.Desconectar();
            return estado;
        }


        private Colectivo Ultimocolectivo() 
        {
            Colectivo colectivo = new Colectivo();
            cnn.Conectar();
            const string query = "Select top 1 * from colectivos inner join datos on colectivos.colectivo_datos = datos.datos_id inner join estados on colectivos.colectivo_estado = estados.estado_id order by colectivo_id desc";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Datos datos1 = new Datos
                {
                    datos_id = Convert.ToInt32(reader["datos_id"]),
                    datos_marca = Convert.ToString(reader["datos_marca"]),
                    datos_modelo = Convert.ToString(reader["datos_modelo"]),
                    datos_anio = Convert.ToInt32(reader["datos_anio"])
                };

                Colectivo colectivo1 = new Colectivo()
                {
                    colectivo_id = Convert.ToInt32(reader["colectivo_id"]),
                    colectivo_dominio = Convert.ToString(reader["colectivo_dominio"]),
                    colectivo_tipo = Convert.ToInt32(reader["colectivo_tipo"]),
                    colectivo_linea = Convert.ToInt32(reader["colectivo_linea"]),
                    colectivo_chofer = Convert.ToInt32(reader["colectivo_chofer"]),

                };
                Estado est = new Estado
                {
                    estado_id = Convert.ToInt32(reader["estado_id"]),
                    estado = Convert.ToBoolean(reader["estado"]),
                    nota = Convert.ToString(reader["nota"])
                };
                colectivo1.datos = datos1;
                colectivo1.estado = est;
                colectivo = colectivo1;              
            }
            cnn.Desconectar();
            return colectivo;
        }

        public void Put(out Colectivo colectivo, int id, Colectivo colectivo1) 
        {
            colectivo = colectivo1;
            cnn.Conectar();
            const string query = "Update datos set datos_marca = @datos_marca, datos_modelo = @datos_modelo, datos_anio = @datos_anio where datos.datos_id = @id";
            SqlCommand cmd = new SqlCommand(query, cnn.Con());
            cmd.Parameters.AddWithValue("@id", colectivo.datos.datos_id);
            cmd.Parameters.AddWithValue("@datos_marca", colectivo.datos.datos_marca);
            cmd.Parameters.AddWithValue("@datos_modelo", colectivo.datos.datos_modelo);
            cmd.Parameters.AddWithValue("@datos_anio", colectivo.datos.datos_anio);
            cmd.ExecuteNonQuery();

           
            const string query3 = "Update colectivos set colectivo_dominio = @colectivo_dominio, colectivo_tipo = @colectivo_tipo, colectivo_linea = @colectivo_linea, colectivo_chofer = @colectivo_chofer where colectivos.colectivo_id = @id";
            SqlCommand cmd3 = new SqlCommand(query3, cnn.Con());
            cmd3.Parameters.AddWithValue("@id", id);
            cmd3.Parameters.AddWithValue("@colectivo_dominio", colectivo.colectivo_dominio);
            cmd3.Parameters.AddWithValue("@colectivo_tipo", colectivo.colectivo_tipo);
            cmd3.Parameters.AddWithValue("@colectivo_linea", colectivo.colectivo_linea);
            cmd3.Parameters.AddWithValue("@colectivo_chofer", colectivo.colectivo_chofer);
            cmd3.ExecuteNonQuery();
          

            const string query2 = "Update estados set nota = @nota where estados.estado_id = @id";
            SqlCommand cmd2 = new SqlCommand(query2, cnn.Con());
            cmd2.Parameters.AddWithValue("@id", colectivo.estado.estado_id);
            cmd2.Parameters.AddWithValue("@nota", colectivo.estado.nota);
            cmd2.ExecuteNonQuery();
            cnn.Desconectar();


            this.Get(out colectivo, id);


        }


        public void Delete(int id) 
        {
            try
            {
                cnn.Conectar();
                const string query = "delete from colectivos where colectivo_id=@id";
                SqlCommand cmd = new SqlCommand(query, cnn.Con());
                cmd.Parameters.AddWithValue("@id",id);
                cmd.ExecuteNonQuery();
                cnn.Desconectar();
            }
            catch (Exception e)
            {

                throw;
            }
        }


    }
}
