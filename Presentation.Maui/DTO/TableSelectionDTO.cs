using FileManager.DAO;
using Presentation.Maui.Interfaces;

namespace Presentation.Maui.DTO
{
    public class TableSelectionDTO : DataHandler , ITableSelection
    {
        public class TableRows
        {
            public string FileName { get; set; }
            public long FileSize { get; set; }
            public FileIdentity FileIdentity { get; set; }
            public bool IsChecked { get; set; } = true;
        }
        public TableSelectionDTO(DirectoryInfo dir, DataFilterDTO filter)
            :base(dir)
        {
            Rows = new();
            DataFilter = filter;
            GetTableFiles();
        }

        private DataFilterDTO DataFilter { get; set; }
        private List<TableSelectionDTO.TableRows> Rows { get;set; }
        public List<TableSelectionDTO.TableRows> GetRows()
            => Rows;
        public IEnumerable<TableSelectionDTO.TableRows> GetCheckedRows()
            => Rows.Where(x => x.IsChecked);

        public void SetDataFilter(DataFilterDTO d)
        {
            DataFilter = d;
            GetTableFiles();
        }
        public void CheckBoxChanged(FileIdentity fi , bool value)
            => Rows.ForEach(x => {
                if (x.FileIdentity.Equals(fi.Id))
                    x.IsChecked = value;
            });
        private List<TableSelectionDTO.TableRows> ReCheckFiles(List<TableSelectionDTO.TableRows> rows)
        {
            List<FileIdentity> checkedFiles = this.Rows.Where(x => x.IsChecked)
                    .Select(s => s.FileIdentity).ToList();
                
            rows.ForEach(f => f.IsChecked = checkedFiles.Any(x => x.Id.Equals(f.FileIdentity.Id) == false)
                ? false
                : true );

            return rows;
        }
        private void GetTableFiles()
        {
            var rows = Dir.GetFiles()
                .Where(x => Predicate(x))
                .Select(s => new TableSelectionDTO.TableRows()
                {
                    FileIdentity = FileIdentity.Instance(s.FullName, Dir),
                    FileName = s.Name,
                    FileSize = s.Length,
                    IsChecked = true
                }).ToList();

            Rows = ReCheckFiles(rows); 
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
