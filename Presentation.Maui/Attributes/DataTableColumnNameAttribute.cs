using Presentation.Maui.Enum;

namespace Presentation.Maui.Attributes
{
    public class DataTableColumnNameAttribute : Attribute
    {
        public readonly string ColumnName;
        
        public DataTableColumnNameAttribute(string name)
        {
            ColumnName = name;
        }

    }
}
