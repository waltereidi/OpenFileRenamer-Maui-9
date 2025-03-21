using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Maui.Components.Shared.Inputs
{
    public partial class AlsoNumberedTextInput
    {
        private bool IsNumber { get; set; } = false;
        public string Text { get => GetText(); }

        public void ChangeToNumberTextInput() => IsNumber = true;
        public void ChangeToTextInput() => IsNumber = false;    
        public AlsoNumberedTextInput()
        {

        }
        public string GetText()
        {
            long number = 0;
            
            if (!String.IsNullOrEmpty(Text) && long.TryParse(Text, out number) && IsNumber)
                return number.ToString();
            else if (IsNumber && number == 0)
                return string.Empty; 
            else
                return Text;
        }


        [Parameter]
        public string ClassName { get; set; }
        [Parameter]
        public string PlaceHolder { get; set; }
        [Parameter]
        public string AriaLabel { get; set; }
        [Parameter]
        public string AriaDescribedBy { get; set; }

    }
    
}
