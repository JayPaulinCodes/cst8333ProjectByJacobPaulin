using cst8333ApplicationByJacobPaulin.BusinessLayer;

namespace cst8333UnitTestProjectByJacobPaulin
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInvalidFilePathOnWrite()
        {
            DataController controller = new DataController();

            bool operation = controller.SaveToCsv("");

            Assert.IsFalse(operation);
        }
    }
}