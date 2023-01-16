using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ARMiniCore.Backend.Models
{
    public class Contrato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContratoId { get; set; }
        public int ClienteId { get; set; }
        public string NombreContrato { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get;set; }
        public Cliente Cliente { get; set; }
    }
}
