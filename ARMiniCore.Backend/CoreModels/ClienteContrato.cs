using System;

namespace ARMiniCore.Backend.CoreModels
{
    public class ClienteContrato
    {
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string NombreContrato { get; set; }
        public double Monto{ get; set; }
        public DateTime Fecha{ get; set; }

    }
}
