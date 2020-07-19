using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PubsAndBeersDomain;

namespace PubsApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<IPubsService, PubsService>()
                .AddSingleton<AbstractValidator<Pub>, PubAsyncValidator>()
                .AddSingleton<AbstractValidator<Beer>, BeerValidator>()
                .AddControllers()
                // Automatic validation doesn't work well with async validators
                //.AddFluentValidation(config =>
                //{
                //    config.AutomaticValidationEnabled = true;
                //    config.ImplicitlyValidateChildProperties = true;
                //    config.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                //    config.RegisterValidatorsFromAssemblyContaining<Beer>();
                //})
                .ConfigureApiBehaviorOptions(options =>
                {
                    // Enable/disable automatic validation
                    options.SuppressModelStateInvalidFilter = true;
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        return new BadRequestObjectResult(
                                        context
                                            .ModelState
                                            .Select(kv => $"{kv.Key}:{string.Join(',', kv.Value.Errors.Select(m => m.ErrorMessage))}")
                                            .ToArray());
                    };
                });

        }
    }
}
