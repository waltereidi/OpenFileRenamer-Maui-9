using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Maui.Shared
{
    public abstract class DataTableModel : ComponentBase
    {
        public readonly Guid Id;
        public readonly Type type; 
        public DataTableModel() 
        { 
            Id = new Guid();
        }
        private void BuildTable<T>()
        {


        }
        public T GetData<T>()
        {
            throw new Exception();
        }
        protected override void OnParametersSet()
        {

        }



    }
}
