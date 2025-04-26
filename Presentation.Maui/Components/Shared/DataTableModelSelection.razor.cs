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
        private IEnumerable<TableSelectionDTO> _files { get => GetTableFiles(); }
        private IEnumerable<TableSelectionDTO> GetTableFiles()
        => _dir.GetFiles()
            .Where(x => Predicate(x))
            .Select(s => new TableSelectionDTO()
            {
                FileIdentity = s.FullName,
                FileName = s.Name,
                FileSize = s.Length,
                IsChecked = true
            });
        private void CheckBoxChanged(ChangeEventArgs e , string FileId)
        {

            Console.WriteLine("");
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
