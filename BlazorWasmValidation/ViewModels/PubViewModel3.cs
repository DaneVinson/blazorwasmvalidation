using PubsAndBeersDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmValidation.ViewModels
{
    public class PubViewModel3
    {
        public PubViewModel3(IPubsService service)
        {
            Service = service ?? throw new ArgumentNullException(nameof(service));
        }


        public async Task Initialize(int id)
        {
            Pub = await Service.GetPub(id);
        }

        public async Task Save()
        {

        }

        public Pub Pub { get; set; }
        public Action StateChanged { get; set; }

        private readonly IPubsService Service;
    }
}
