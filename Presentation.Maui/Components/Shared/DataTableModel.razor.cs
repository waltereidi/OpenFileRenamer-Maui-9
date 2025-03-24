using Microsoft.AspNetCore.Components;
using Presentation.Maui.Attributes;
using Presentation.Maui.Enum;
using System.Reflection;


namespace Presentation.Maui.Components.Shared
{
    public partial class DataTableModel : ComponentBase
    {
        private record ColumnDef(int index , MemberInfo originator , bool visible , string columnName );
        public readonly Guid Id;
        [Parameter]
        public object DataSource { get; set; }
        
        [Parameter]
        public Type Type { get; set; }

        private List<MemberInfo> GetPropertyMember()
            => Type.GetMembers()
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
            var columns = GetColumnDefinition();


        }

        private List<ColumnDef> GetColumnDefinition()
        {
            var members = GetPropertyMember();

            return members.Select((s, index) => new ColumnDef(index , s , IsColumnVisible(s) , GetColumnName(s)))
                .ToList();
        }
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
