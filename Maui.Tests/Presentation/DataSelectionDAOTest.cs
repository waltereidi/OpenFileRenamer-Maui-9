using ApplicationService.DAO;
using ApplicationService.Interfaces;


namespace Maui.Tests.Presentation
{
    [TestClass]
    public class DataSelectionDAOTest : Configuration
    {
   
        private ITableSelection Dao; 
        public DataSelectionDAOTest()
        {
            var filter = new DataFilterDAO("", "Contains");
            Dao = new TableSelectionDAO(_testDirPath , filter);
        }

        [TestMethod]
        public void TestGetRowsReturnAFile()
        {
            var result = Dao.GetRows();
            Assert.IsTrue(result.Count() > 0);
        }
        [TestMethod]
        public void TestCheckRowRetunsFileUnchecked()
        {
            var result = Dao.GetRows();
            var file = result.First(x => x.IsChecked);
            Dao.CheckBoxChanged(file.FileIdentity , false);

            Assert.IsTrue( Dao.GetRows().Count(x=>x.IsChecked == false) == 1 );
        }
        [TestMethod]
        public void UncheckFileAndFilterRecordsCheckState()
        {
            var result = Dao.GetRows();
            var file = result.First(x => x.IsChecked);
            Dao.CheckBoxChanged(file.FileIdentity, false);
            Dao.SetDataFilter(new DataFilterDAO("t", "Contains"));
            Assert.IsFalse(Dao.GetRows().First().IsChecked);
        }
    }
}
