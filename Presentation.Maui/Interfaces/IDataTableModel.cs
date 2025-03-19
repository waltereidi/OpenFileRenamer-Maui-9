using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Maui.Interfaces
{
    public interface IDataTableModel
    {
        string[] GetTableColumns();
        T GetData<T>();
        string GetId();
        void SelectRow(int index); 
        void SelectAllRows(int count);
        void SetDataSource();
        void AddRow();
         void RemoveRow();
        void CleanDataTable();
        
    }
}
