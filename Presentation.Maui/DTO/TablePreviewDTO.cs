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
        [DataTableColumnName("File Name")]
        public string FileName { get; set; }
        [DataTableColumnName("Size")]
        public long FileSize { get; set; }
        [DataTableHiddenColumn]
        public string FileIdentity { get; set; }
        
    }
}
