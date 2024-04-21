using DepartAdmin.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepartAdmin.DAL.Context;

public partial class DepartAdminContext : DbContext
{
    public DepartAdminContext(DbContextOptions <DepartAdminContext> options) : base(options) { }

    #region"Entities"

    public DbSet <Inquilino> Inquilino { get; set; }
    public DbSet <Pago> Pago { get; set; }

    #endregion
}