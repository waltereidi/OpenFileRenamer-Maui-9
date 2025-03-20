using Microsoft.AspNetCore.Components;
using Presentation.Maui.Enum;
using System.Reflection;


namespace Presentation.Maui.Components.Shared
{
    public partial class DataTableModel : ComponentBase
    {
        private record ColumnDef(int index , MemberInfo originator );
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
            GetColumnDefinition();


        }

        private List<ColumnDef> GetColumnDefinition()
        {
            var members = GetPropertyMember();

            return members.Select((s, index) => new ColumnDef(index , s))
                .ToList();
        }




    }
}
