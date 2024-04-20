using DepartAdmin.DAL.Core;
using System.ComponentModel.DataAnnotations;

namespace DepartAdmin.DAL.Entities;

public partial class Inquilino : BaseEntity
{
    public Inquilino()
    {
        Pagos = new HashSet<Pago>();
    }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Cedula { get; set; }

    public int NumeroDepartamento { get; set; }

    public string? NumeroTelefonico { get; set; }
    [Phone]

    public bool UserMod { get; set; }

    public DateTime ModifyDate { get; set; }

    public DateTime CreationDate { get; set; }

    public int CreationUser { get; set; }

    public string? UserDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; }
}