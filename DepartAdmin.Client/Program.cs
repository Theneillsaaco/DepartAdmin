using DepartAdmin.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DepartAdmin.Client.Services;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5177") });

builder.Services.AddScoped<IInquilinoServices, InquilinoServices>();

//Services Nutget

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
