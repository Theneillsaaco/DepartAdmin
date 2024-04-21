using DepartAdmin.DAL.Core;
using System.ComponentModel.DataAnnotations;

namespace DepartAdmin.DAL.Entities;

public partial class Inquilino : BaseEntity
{
    public Inquilino()
    {
        Pagos = new HashSet<Pago>();
    }


    [Required(ErrorMessage = "El campo {0} es requerido.")]
    public string? FirstName { get; set; }


    [Required(ErrorMessage = "El campo {0} es requerido.")]
    public string? LastName { get; set; }


    [Required(ErrorMessage = "El campo {0} es requerido.")]
    public string? Cedula { get; set; }


    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
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