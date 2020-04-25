using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PubsAndBeersDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmValidation.ViewModels
{
    public class PubViewModel4 : ViewModelComponentBase
    {
        [Inject] public IPubsService Service { get; set; }

        public PubViewModel4()
        { }


        public void AddTap()
        {
            Pub.OnTap.Add(new Beer());
            IsValid = Context?.Validate() ?? true;
            StateHasChanged();
        }

        public async Task Initialize(int id)
        {
            Pub = await Service.GetPub(id);
        }

        public async Task Save()
        {
            IsValid = Context?.Validate() ?? true;
            if (!IsValid) { return; }
        }


        public Pub Pub { get; set; }


        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                IsValid = Context.Validate();
                StateHasChanged();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await Initialize(4);

            Context = new EditContext(Pub);
            Context.OnFieldChanged += (o, e) =>
            {
                IsValid = Context.Validate();
                StateHasChanged();
            };
        }
    }
}
