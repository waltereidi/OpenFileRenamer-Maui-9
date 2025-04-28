using FileManager.DAO;
using Presentation.Maui.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Maui.DTO
{
    public class TableSelectionDTO
    {
        public class TableRows
        {
            public string FileName { get; set; }
            public long FileSize { get; set; }
            public FileIdentity FileIdentity { get; set; }
            public bool IsChecked { get; set; } = true;
        }
        public DirectoryInfo Dir;

        public DataFilterDTO DataFilter;
        public List<TableSelectionDTO.TableRows> Rows { get; set; }

        public TableSelectionDTO(DirectoryInfo dir, DataFilterDTO filter)
        {
            Dir = dir;
            DataFilter = filter;
        }
        public void CheckBoxChanged(FileIdentity fi , bool value)
            => Rows.ForEach(x => {
                if (x.FileIdentity.Equals(fi.Id))
                    x.IsChecked = value;
            });
        private IEnumerable<TableSelectionDTO.TableRows> GetTableFiles()
            => Dir.GetFiles()
                .Where(x => Predicate(x))
                .Select(s => new TableSelectionDTO.TableRows()
                {
                    FileIdentity = FileIdentity.Instance(s.FullName, Dir),
                    FileName = s.Name,
                    FileSize = s.Length,
                    IsChecked = true
                });

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
