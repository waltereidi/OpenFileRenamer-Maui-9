using Microsoft.AspNetCore.Components;
using Presentation.Maui.Interfaces;

namespace Presentation.Maui.Shared
{
    public abstract class DataTableModel : ComponentBase , IDataTableModel
    {
        public readonly Guid Id;
        public readonly Type type; 
        
        public DataTableModel() 
        { 
            Id = new Guid();
        }

        public void AddRow()
        {
            throw new NotImplementedException();
        }

        public void CleanDataTable()
        {
            throw new NotImplementedException();
        }

        public T GetData<T>()
        {
            throw new NotImplementedException();
        }

        public string GetId()
        {
            throw new NotImplementedException();
        }

        public string[] GetTableColumns()
        {
            throw new NotImplementedException();
        }

        public void RemoveRow()
        {
            throw new NotImplementedException();
        }

        public void SelectAllRows(int count)
        {
            throw new NotImplementedException();
        }

        public void SelectRow(int index)
        {
            throw new NotImplementedException();
        }

        public void SetDataSource()
        {
            throw new NotImplementedException();
        }

        protected override void OnParametersSet()
        {

        }

    

    }
}
