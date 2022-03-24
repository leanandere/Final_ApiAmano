using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_ApiAmano.Models
{
    public class Datos
    {
        [Key]
        public int datos_id { get; set; }
        public string datos_marca { get; set; }
        public string datos_modelo { get; set; }
        public int datos_anio { get; set; }
    }
}
