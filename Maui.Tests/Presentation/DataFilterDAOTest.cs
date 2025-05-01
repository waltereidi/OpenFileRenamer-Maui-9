using ApplicationService.DAO;
using ApplicationService.Interfaces;

namespace Maui.Tests.Presentation
{
    [TestClass]
    public sealed class DataFilterDAOTest
    {
        [TestMethod]
        public void ContainsReturnPredicate()
        {
            IDataFilter df = new DataFilterDAO("t" , "Contains");
            var p = df.GetPerdicate();
            Assert.IsTrue(p.Invoke("test"));
        }
        [TestMethod]
        public void BiggerThanReturnPredicate()
        {
            IDataFilter df = new DataFilterDAO("5", "BiggerThan");
            var p = df.GetPerdicate();
            Assert.IsTrue(p.Invoke("6"));
        }
        [TestMethod]
        public void ExtensionMatchContainsPredicate()
        {
            IDataFilter df = new DataFilterDAO("cs", "Extension");
            var p = df.GetPerdicate();
            Assert.IsTrue(p.Invoke("csv"));
        }

    }
}
