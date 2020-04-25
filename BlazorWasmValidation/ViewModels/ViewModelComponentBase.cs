using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmValidation.ViewModels
{
    public class ViewModelComponentBase : ComponentBase
    {
        public EditContext Context { get; set; }
        public bool IsBusy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
        public bool IsValid { get; set; }
    }
}
