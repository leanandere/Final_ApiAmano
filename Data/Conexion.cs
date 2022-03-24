using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Final_ApiAmano.Data
{
    public class Conexion
    {
        private readonly SqlConnection cnn = new SqlConnection("Data Source = DESKTOP-TI1DTD5\\SQLEXPRESS; Initial Catalog = final; Integrated Security = True");

        public void Conectar() 
        {
            cnn.Open();
        }

        public void Desconectar() 
        { 
            cnn.Close();
        }

        public SqlConnection Con() 
        { 
            return cnn; 
        }
    }
}
