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
        public DirectoryInfo Dir { get; private set; }

        public DataFilterDTO DataFilter { get; private set; }
        public List<TableSelectionDTO.TableRows> Rows { get; set; }
        public void SetDataFilter(DataFilterDTO d)
        {
            DataFilter = d;
            GetTableFiles();
        }
        public void SetDir(DirectoryInfo d )
        {
            if (d.Exists && d.FullName != Dir.FullName && d.GetFiles().Any())
            {
                Dir = d;
                GetTableFiles();
            }

        }
        public TableSelectionDTO(DirectoryInfo dir, DataFilterDTO filter)
        {
            Dir = dir;
            DataFilter = filter;
            GetTableFiles();
        }
        public void CheckBoxChanged(FileIdentity fi , bool value)
            => Rows.ForEach(x => {
                if (x.FileIdentity.Equals(fi.Id))
                    x.IsChecked = value;
            });
        
        private void GetTableFiles()
        {
            List<FileIdentity> checkedFiles = (this.Rows != null && this.Rows.Any())
                ? this.Rows.Where(x => x.IsChecked)
                    .Select(s => s.FileIdentity).ToList() 
                    : new();

            Rows = Dir.GetFiles()
                .Where(x => Predicate(x))
                .Select(s => new TableSelectionDTO.TableRows()
                {
                    FileIdentity = FileIdentity.Instance(s.FullName, Dir),
                    FileName = s.Name,
                    FileSize = s.Length,
                    IsChecked = true
                }).ToList();

            Rows.ForEach(f => f.IsChecked = checkedFiles.Any(x => x.Id.Equals(f.FileIdentity.Id) == false)
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
