using Microsoft.AspNetCore.Components.Forms;
using PubsAndBeersDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorWasmValidation.ViewModels
{
    public class PubViewModel2 : ViewModelBase
    {
        public PubViewModel2(IPubsService service)
        {
            Service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void AddTap()
        {
            Pub.OnTap.Add(new Beer());
            StateChanged?.Invoke();
        }

        public async Task Save(EditContext context)
        {
            var errors = context.GetValidationMessages().ToArray();
            if (errors.Length > 0)
            {
                Console.WriteLine($"Save bloked due to {errors.Length} errors");
            }
            else { Console.WriteLine($"Save"); }
        }
        
        public async Task Initialize(int id)
        {
            Pub = await Service.GetPub(id);
        }


        public Pub Pub { get; set; }
        public Action StateChanged { get; set; }


        private readonly IPubsService Service;
    }
}
