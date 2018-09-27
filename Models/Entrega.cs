using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xau.Models
{
    public class Entrega
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Entrega")]
        public DateTime Fecha { get; set; }

        // user Id from the AspNetUser table
        public string OwnerID { get; set; }

        [Display(Name = "Peso (gr)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Peso { get; set; }

        [Display(Name = "Ley")]
        public decimal LeyRecuperable { get; set; }

        // Ley Analitica se calcula: -0.5
        // Peso Fino (aka Puro, Total Fino) se calcula: (PesoBruto x LeyRecupreable ) 1000

        public int RecolectorID { get; set; }

        [Display(Name = "Proveedor")]
        public int ProveedorID { get; set; }

        // Navigation Properties
        public Proveedor Proveedor { get; set; }
        public Recolector Recolector { get; set; }

        public EntregaStatus status { get; set; }

        public decimal CalcularFino(decimal bruto, decimal ley)
        {
            return ((bruto * ley) / 1000);
        }
    }
}

public enum EntregaStatus
{
    pendiente,
    aceptada
}