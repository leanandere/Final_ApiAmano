using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_ApiAmano.Models
{
    public class Linea
    {
        [Key]
        public int linea_id { get; set; }
        public int linea_numero { get; set; }
    }
}
