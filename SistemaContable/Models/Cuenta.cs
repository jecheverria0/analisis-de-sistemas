namespace SistemaContable.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public int Numcuenta { get; set; }
        public string TipoCuenta { get; set; }
        public string Tipomoneda { get; set; }
        public decimal MontoApertura { get; set; }
        public int Banco { get; set; }
    }
}
