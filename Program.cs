using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorDB;
using BugTracker;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var singletonInitializer = new TaskCompletionSource<bool>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddSingleton<Tools.Misc.LocalStorageHelper>();
builder.Services.AddSingleton<Tools.Misc.AccessTokenHelper>(provider => {
    var localStorageHelper = provider.GetService<Tools.Misc.LocalStorageHelper>();
    return new Tools.Misc.AccessTokenHelper(localStorageHelper!);
});

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IBlazorDbFactory, BlazorDbFactory>();

await Task.Delay(200);
await builder.Build().RunAsync();
