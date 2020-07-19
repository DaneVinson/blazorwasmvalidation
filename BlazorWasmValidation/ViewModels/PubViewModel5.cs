using FluentValidation;
using PubsAndBeersDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmValidation.ViewModels
{
    public class PubViewModel5 : ViewModelBase
    {
        public PubViewModel5(IPubsService service)
        {
            Service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void AddTap()
        {
            Pub.OnTap.Add(new Beer());
            Console.WriteLine($"Validator is null: {Validator == null}");
            IsValid = Validator?.Invoke() ?? true;
            StateChanged?.Invoke();
        }

        public Task Save()
        {
            IsValid = Validator?.Invoke() ?? true;
            return Task.FromResult(0);
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
