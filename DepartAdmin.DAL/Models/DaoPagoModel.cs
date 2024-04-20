namespace DepartAdmin.DAL.Models
{
    public class DaoPagoModel
    {
        #region"Inquilino"

        public int UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int NumeroDepartamento { get; set; }

        #endregion
        public int NumeroDeposito { get; set; }

        public DateTime FechaMudanza { get; set; }

        public DateTime? FechaPago { get; set; }

        public decimal MontoPagado { get; set; }

        public bool Retrasado { get; set; }
    }
}