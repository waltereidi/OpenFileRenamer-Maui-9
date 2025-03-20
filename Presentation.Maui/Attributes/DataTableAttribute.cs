using Presentation.Maui.Enum;

namespace Presentation.Maui.Attributes
{
    public class DataTableAttribute : Attribute
    {
        public DataTableCustomColumn _attribute;
        public string _customName; 
        public DataTableAttribute(DataTableCustomColumn customProperty) 
        {
            _attribute = customProperty; 
        }
        public DataTableAttribute(DataTableCustomColumn customProperty , string customName )
        {
            _attribute = customProperty;
            _customName = customName;
        }
        public DataTableAttribute(string customName)
        {
            _attribute = DataTableCustomColumn.None;
            _customName = customName;
        }
    }
}
