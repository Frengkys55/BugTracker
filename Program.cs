using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorDB;
using BugTracker;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IBlazorDbFactory, BlazorDbFactory>();
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<Tools.Misc.AccessTokenHelper>();
builder.Services.AddSingleton<Tools.Misc.LocalStorageHelper>();

await builder.Build().RunAsync();
