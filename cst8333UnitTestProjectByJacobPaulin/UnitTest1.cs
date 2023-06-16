/* 
 * Author: Jacob Paulin
 * Date: Jun 1, 2023
 * Modified: Jun 13, 2023
 */

using cst8333ApplicationByJacobPaulin.BusinessLayer;

namespace cst8333UnitTestProjectByJacobPaulin
{
    /// <summary>
    /// The class for our test cases
    /// </summary>
    /// <author>Jacob Paulin</author>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test method to verify that the operation will fail
        /// when passed a invalid path on the SaveToCsv() method.
        /// </summary>
        /// <author>Jacob Paulin</author>
        [TestMethod]
        public void TestInvalidFilePathOnWrite()
        {
            // Initialize the Data Controler (business layer)
            DataController controller = new DataController();

            // Run the operation with a invalid file path
            bool operation = controller.SaveToCsv("");

            // It better be false
            Assert.IsFalse(operation);
        }
    }
}