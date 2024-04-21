using System.ComponentModel.DataAnnotations;

namespace DepartAdmin.Sever.Models
{
    public class InquilinoModel
    {
        public int UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Cedula { get; set; }

        public int NumeroDepartamento { get; set; }

        public string? NumeroTelefonico { get; set; }
        [Phone]

        public DateTime CreationDate { get; set; }
    }
}