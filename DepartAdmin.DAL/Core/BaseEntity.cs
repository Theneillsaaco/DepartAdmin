using System.ComponentModel.DataAnnotations;

namespace DepartAdmin.DAL.Core;
public abstract class BaseEntity
{
    [Key]
    public int UserId { get; set; }
}