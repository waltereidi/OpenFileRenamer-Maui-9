using FileManager.DAO;
using Microsoft.AspNetCore.Components;
using Presentation.Maui.DTO;

namespace Presentation.Maui.Components.Shared
{
    public partial class DataTableModelSelection : ComponentBase
    {

        [Parameter]
        public TableSelectionDTO DataTableFiles { get; set; }

        private void CheckBoxChanged(ChangeEventArgs e , FileIdentity fi )
            => DataTableFiles.CheckBoxChanged(fi, (bool)e.Value);
        //protected override void OnParametersSet()
        //{
        //    List<FileIdentity> checkedFiles = new List<FileIdentity>();
        //    if (this._files != null  && this._files.Any())
        //    {
        //        this._files.ToList().ForEach(x =>
        //        {
        //            if (x.IsChecked)
        //                checkedFiles.Add(x.FileIdentity);
        //        });
        //    }
            
        //    var files = GetTableFiles().ToList();

        //    _files.ForEach(f => f.IsChecked = checkedFiles.Any(x => x.Id.Equals(f.FileIdentity.Id) == false)
        //        ? false
        //        : true
        //    );
                
        //}


    }
}
