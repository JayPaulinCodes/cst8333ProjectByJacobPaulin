/* 
 * Author: Jacob Paulin
 * Date: Jun 1, 2023
 * Modified: July 19, 2023
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
        /// Test method to verify we can add rows to the database
        /// </summary>
        /// <author>Jacob Paulin</author>
        [TestMethod]
        public async Task TestRecordAddition()
        {
            // Initialize the Data Controler (business layer)
            DataController controller = new DataController();

            // Get a list of current DB records
            List<VegetableRecord> startRecords = await controller.ReadAllVegetableRecord();

            // Make a new record and insert into DB
            VegetableRecord newRecord = new VegetableRecord();
            _ = await controller.CreateVegetableRecord(newRecord);

            // Get a list of updated DB records
            List<VegetableRecord> updatedRecords = await controller.ReadAllVegetableRecord();

            // Ensure the new list is 1 more than old one
            Assert.IsTrue(updatedRecords.Count == startRecords.Count + 1);

            // Clean up
            _ = await controller.DeleteVegetableRecord(updatedRecords.Last());
        }
    }
}