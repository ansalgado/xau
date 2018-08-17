using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xau.Models
{
    public class Entrega
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Peso (gr)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Peso { get; set; }
        public int RecolectorID { get; set; }
        public int ProveedorID { get; set; }

        // Navigation Properties
        public Proveedor Proveedor { get; set; }
        public Recolector Recolector { get; set; }
    }
}
