using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PubsAndBeersDomain;
using BlazorWasmValidation.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorWasmValidation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services
                    .AddTransient<IPubsService, PubsService>()
                    .AddTransient<PubViewModel1>()
                    .AddTransient<PubViewModel2>()
                    .AddTransient<PubViewModel3>();

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
