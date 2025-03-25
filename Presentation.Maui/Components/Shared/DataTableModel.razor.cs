using Microsoft.AspNetCore.Components;
using Presentation.Maui.Attributes;
using System.Reflection;


namespace Presentation.Maui.Components.Shared
{
    public partial class DataTableModel : ComponentBase
    {
        private record ColumnDef(int index , MemberInfo originator , bool visible , string columnName , Guid ColumnId);
        private readonly Guid Id;
        private List<ColumnDef> _columns { get; set; }
        
        [Parameter]
        public List<object> _dataSource { get; set; }        
        [Parameter]
        public Type _type { get; set; }

        private List<MemberInfo> GetPropertyMember()
            => _type.GetMembers()
                .Where(x => x.MemberType == MemberTypes.Property)
                .ToList();

        public DataTableModel() 
        { 
            Id = Guid.NewGuid();
        }
        
        protected override Task OnParametersSetAsync()
        {
            RenderTable(); 
            return base.OnParametersSetAsync();
        }
        
        public void RenderTable()
        {
            if (_type == null)
                throw new ArgumentNullException(nameof(Type));

            _columns = GetColumnDefinition();

            if (_dataSource != null && _dataSource.Any() && _dataSource.First().GetType().Name != nameof(_type))
                throw new InvalidDataException(nameof(_dataSource));

            if (_dataSource != null && _dataSource.Any())
                RenderData();

        }

        private void RenderData()
        {

        }

        private List<ColumnDef> GetColumnDefinition()
            => GetPropertyMember()
                .Select((s, index) => new ColumnDef(index , s , IsColumnVisible(s) , GetColumnName(s), Guid.NewGuid()))
                .ToList();

        private string GetColumnName(MemberInfo m)
            => !m.GetCustomAttributesData()
                .Any(x => x.AttributeType.Name == nameof(DataTableColumnNameAttribute)) 
                ?m.Name 
                :m.GetCustomAttributesData()
                        .First(x => x.AttributeType.Name == nameof(DataTableColumnNameAttribute))
                        .ConstructorArguments.First().Value.ToString();


        private bool IsColumnVisible(MemberInfo m)
            => !m.GetCustomAttributesData()
                .Any(x => x.AttributeType.Name == nameof(DataTableHiddenColumnAttribute));
    }
}
