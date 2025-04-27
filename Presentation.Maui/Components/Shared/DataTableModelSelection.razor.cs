using FileManager.DAO;
using Microsoft.AspNetCore.Components;
using Presentation.Maui.DTO;
using Presentation.Maui.Service;

namespace Presentation.Maui.Components.Shared
{
    public partial class DataTableModelSelection : ComponentBase
    {
        [Parameter]
        public DataFilterDTO DataFilter { get; set; }
        private DirectoryInfo _dir { get => DirectoryManagerService._dir; }
        [Parameter]
        public EventCallback<List<TableSelectionDTO>> OnTableDataChangeCallBack { get; set; }
        private List<TableSelectionDTO> DataTableFiles { get; set; }

        private List<TableSelectionDTO> _files { get; set => SetTableFiles(value); }
        //private void SetTableFiles(List<TableSelectionDTO> value)
        //{
        //    _files =    
        //}

        private IEnumerable<TableSelectionDTO> GetTableFiles()
        => _dir.GetFiles()
            .Where(x => Predicate(x))
            .Select(s => new TableSelectionDTO()
            {
                FileIdentity = FileIdentity.Instance(s.FullName, _dir),
                FileName = s.Name,
                FileSize = s.Length,
                IsChecked = true
            });
        private void CheckBoxChanged(ChangeEventArgs e , FileIdentity fi )
        {
            _files.ForEach(x => {
                if(x.FileIdentity.Equals(fi.Id))
                    x.IsChecked = e.Value.ToString() == "true" ? true : false;
            });
        }
        protected override void OnParametersSet()
        {
            List<FileIdentity> checkedFiles = new List<FileIdentity>();
            if (this._files != null  && this._files.Any())
            {
                this._files.ToList().ForEach(x =>
                {
                    if (x.IsChecked)
                        checkedFiles.Add(x.FileIdentity);
                });
            }

            _files = GetTableFiles().ToList();

            _files.ForEach(f => f.IsChecked = checkedFiles.Any(x => x.Id.Equals(f.FileIdentity.Id) == false)
                ? false
                : true
            );
                
        }

        private bool Predicate(FileInfo dto)
        {
            if (DataFilter == null || String.IsNullOrEmpty(DataFilter.Text))
                return true;
            else
            {
                switch (DataFilter.FilterOption)
                {
                    case DataFilterOption.Contains:
                        return DataFilter.GetPerdicate().Invoke(dto.Name);
                    case DataFilterOption.BiggerThan:
                        return DataFilter.GetPerdicate().Invoke(dto.Length.ToString());
                    case DataFilterOption.SmallerThan:
                        return DataFilter.GetPerdicate().Invoke(dto.Length.ToString());
                    case DataFilterOption.Extension:
                        return DataFilter.GetPerdicate().Invoke(dto.Extension);
                    default:
                        return DataFilter.GetPerdicate().Invoke(dto.Name);
                }
            }

          
        }
    }
}
