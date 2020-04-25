using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmValidation.ViewModels
{
    public class ViewModelBase
    {
        public bool IsBusy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
        public bool IsValid { get; set; }
    }
}
