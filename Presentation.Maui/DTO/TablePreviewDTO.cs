using Presentation.Maui.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Maui.DTO
{
    public class TablePreviewDTO
    {
        [DataTable("File Name")]
        public string FileName { get; set; }
        [DataTable("Size")]
        public string FileSize { get; set; }
        [DataTable(Enum.DataTableCustomColumn.HiddenColumn )]
        public string FileIdentity { get; set; }
        
    }
}
