using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_ApiAmano.Models
{
    public class Estado
    {
        [Key]
        public int estado_id { get; set; }
        public bool estado { get; set; }
        public string nota { get; set; }
    }
}
