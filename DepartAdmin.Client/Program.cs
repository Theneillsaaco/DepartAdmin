using CurrieTechnologies.Razor.SweetAlert2;
using DepartAdmin.Client;
using DepartAdmin.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5177") });

//Referencia a los servicios
builder.Services.AddScoped<IInquilinoService, InquilinoService>();

//Services NuGet
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
