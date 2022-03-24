using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_ApiAmano.Models
{
    public class Colectivo
    {
        [Key]
        public int colectivo_id { get; set; }
        public string colectivo_dominio { get; set; }
        public int colectivo_tipo { get; set; }
        public int colectivo_linea { get; set; }
        public int colectivo_chofer { get; set; }
        [ForeignKey("colectivo_datos")]
        public virtual Datos datos { get; set; }
        [ForeignKey("colectivo_estado")]
        public virtual Estado estado { get; set; }
    }
}
