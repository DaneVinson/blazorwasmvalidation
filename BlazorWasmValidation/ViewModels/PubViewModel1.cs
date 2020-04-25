using PubsAndBeersDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmValidation.ViewModels
{
    public class PubViewModel1 : ViewModelBase
    {
        public PubViewModel1(IPubsService service)
        {
            Service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void AddTap()
        {
            Pub.OnTap.Add(new Beer());
            IsValid = Validator?.Invoke() ?? true;
            StateChanged?.Invoke();
        }

        public async Task Save()
        {

            IsValid = Validator?.Invoke() ?? true;
        }

        public async Task Initialize(int id)
        {
            Pub = await Service.GetPub(id);
        }


        public Pub Pub { get; set; }
        public Action StateChanged { get; set; }
        public Func<bool> Validator { get; set; }


        private readonly IPubsService Service;
    }
}
