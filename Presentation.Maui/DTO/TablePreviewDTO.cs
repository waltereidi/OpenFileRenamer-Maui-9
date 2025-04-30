using Presentation.Maui.Attributes;


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
