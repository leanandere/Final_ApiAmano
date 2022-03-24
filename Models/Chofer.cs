using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_ApiAmano.Models
{
    public class Chofer
    {   
        [Key]
        public int chofer_id { get; set; }
        public string chofer_nombre { get; set; }
        public string chofer_apellido { get; set; }
        public string chofer_dni { get; set; }
        public string chofer_telefono { get; set; }
    }
}
