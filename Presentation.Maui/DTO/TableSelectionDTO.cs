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
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public FileIdentity FileIdentity { get; set; }
        public bool IsChecked { get; set; } = true;

    }
}
