using DepartAdmin.DAL.Dao;
using DepartAdmin.DAL.Context;
using DepartAdmin.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region"Registro del contexto"

builder.Services.AddDbContext<DepartAdminContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AdminDepartContext")));

#endregion

#region"Registro de componentes Daos"

builder.Services.AddTransient<IDaoInquilino, DaoInquilino>();
builder.Services.AddTransient<IDaoPago, DaoPago>();

#endregion


builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();