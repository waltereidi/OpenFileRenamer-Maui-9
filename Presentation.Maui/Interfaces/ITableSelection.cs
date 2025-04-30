
using FileManager.DAO;
using Presentation.Maui.DTO;

namespace Presentation.Maui.Interfaces
{
    public interface ITableSelection
    {
        public void SetDataFilter(DataFilterDTO d);
        public void CheckBoxChanged(FileIdentity fi, bool value);
        public List<TableSelectionDTO.TableRows> GetRows();
        public IEnumerable<TableSelectionDTO.TableRows> GetCheckedRows();
    }
}
