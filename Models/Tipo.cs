using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_ApiAmano.Models
{
    public class Tipo
    {
        [Key]
        public int tipo_id { get; set; }
        public string tipo_nombre { get; set; }
    }
}
