using Microsoft.AspNetCore.Components;
using Presentation.Maui.DTO;
using Presentation.Maui.Service;

namespace Presentation.Maui.Components.Shared
{
    public partial class DataTableModelSelection : ComponentBase
    {
        private DirectoryInfo _dir { get => DirectoryManagerService._dir; }
        private IEnumerable<TableSelectionDTO> _files { get => GetDirectoryFiles(); }
        public DataTableModelSelection()
        {
            if (!_dir.Exists || !_dir.GetFiles().Any())
                Navigation.NavigateTo($"/");

        }
        private IEnumerable<TableSelectionDTO> GetDirectoryFiles()
        => _dir.GetFiles().Select(s=>new TableSelectionDTO()
            {
                FileIdentity = s.FullName,
                FileName = s.Name,
                FileSize = s.Length
            });
        

        //    private record ColumnDef(int index , MemberInfo originator , bool visible , string columnName , Guid ColumnId);
        //    private readonly Guid Id;
        //    private List<ColumnDef> _columns { get; set; }

        //    public List<object> DataSource = new();     
        //    [Parameter]
        //    public Type Type { get; set; }
        //    [Parameter] 
        //    public EventCallback<Type> TypeChanged { get; set; }

        //    [Parameter] 
        //    public Expression<Func<Type>> TypeExpression { get; set; }
        //    private List<MemberInfo> GetPropertyMember()
        //        => Type.GetMembers()
        //            .Where(x => x.MemberType == MemberTypes.Property)
        //            .ToList();
        //    private async Task OnValueChanged(Type value)
        //    => await this.TypeChanged.InvokeAsync(value);
        //    public DataTableModel() 
        //    { 
        //        Id = Guid.NewGuid();
        //    }

        //    protected override Task OnParametersSetAsync()
        //    {
        //        RenderTable(); 
        //        return base.OnParametersSetAsync();
        //    }

        //    public void RenderTable()
        //    {
        //        if (Type == null)
        //            throw new ArgumentNullException(nameof(Type));

        //        _columns = GetColumnDefinition();

        //        if (DataSource != null && DataSource.Any() && DataSource.First().GetType().Name != nameof(Type))
        //            throw new InvalidDataException(nameof(DataSource));

        //        if (DataSource != null && DataSource.Any())
        //            RenderData();

        //    }

        //    private void RenderData()
        //    {

        //    }

        //    private List<ColumnDef> GetColumnDefinition()
        //        => GetPropertyMember()
        //            .Select((s, index) => new ColumnDef(index , s , IsColumnVisible(s) , GetColumnName(s), Guid.NewGuid()))
        //            .ToList();

        //    private string GetColumnName(MemberInfo m)
        //        => !m.GetCustomAttributesData()
        //            .Any(x => x.AttributeType.Name == nameof(DataTableColumnNameAttribute)) 
        //            ?m.Name 
        //            :m.GetCustomAttributesData()
        //                    .First(x => x.AttributeType.Name == nameof(DataTableColumnNameAttribute))
        //                    .ConstructorArguments.First().Value.ToString();


        //    private bool IsColumnVisible(MemberInfo m)
        //        => !m.GetCustomAttributesData()
        //            .Any(x => x.AttributeType.Name == nameof(DataTableHiddenColumnAttribute));
        //}
    }
}
