using DepartAdmin.DAL.Core;

namespace DepartAdmin.DAL.Entities;

public partial class Pago : BaseEntity
{
    public int NumeroDeposito { get; set; }

    public DateTime FechaMudanza { get; set; }

    public DateTime? FechaPago { get; set; }

    public decimal MontoPagado { get; set; }

    public bool Retrasado { get; set; }

    public virtual Inquilino? User { get; set; }

    public virtual Inquilino? Inquilino { get; set; }
}