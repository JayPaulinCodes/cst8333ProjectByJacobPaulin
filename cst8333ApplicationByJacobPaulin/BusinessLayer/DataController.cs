/* 
 * Author: Jacob Paulin
 * Date: Jun 1, 2023
 * Modified: July 19, 2023
 * Description: A business layer class to interact 
 * with the CSV data and CSV handler
 */

using cst8333ApplicationByJacobPaulin.PersistenceLayer.Daos;
using cst8333ApplicationByJacobPaulin.PersistenceLayer.Managers;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace cst8333ApplicationByJacobPaulin.BusinessLayer
{
    /// <summary>
    /// Business class to provide CRUD operations for the DB.
    /// </summary>
    /// <author>Jacob Paulin</author>
    public class DataController
    {
        private IVegetableRecordDao dao = null;

        /// <summary>
        /// Constructor where we initialize a instance of the dao
        /// </summary>
        /// <author>Jacob Paulin</author>
        public DataController()
        {
            dao = new VegetableRecordDaoImpl();
        }

        /// <summary>
        /// (C)RUD - Creates a new record in the DB
        /// </summary>
        /// <param name="vegetableRecord">The record to populate to the DB</param>
        /// <returns>Boolean representing the sucess of the operation</returns>
        /// <author>Jacob Paulin</author>
        public async Task<bool> CreateVegetableRecord(VegetableRecord vegetableRecord)
        {
            CleanString(vegetableRecord.RefDate, true);
            CleanString(vegetableRecord.Geo, true);
            CleanString(vegetableRecord.DGUID, true);
            CleanString(vegetableRecord.TypeOfProduct, true);
            CleanString(vegetableRecord.TypeOfStorage, true);
            CleanString(vegetableRecord.UOM, true);
            ValidateInt(vegetableRecord.UOMID, true);
            CleanString(vegetableRecord.ScalarFactor, true);
            ValidateInt(vegetableRecord.ScalarId, true);
            CleanString(vegetableRecord.Vector, true);
            CleanString(vegetableRecord.Coordinate, true);
            ValidateInt(vegetableRecord.Value, true);
            CleanString(vegetableRecord.Status, true);
            CleanString(vegetableRecord.Symbol, true);
            CleanString(vegetableRecord.Terminated, true);
            ValidateInt(vegetableRecord.Decimals, true);

            try
            {
                await dao.CreateAsync(vegetableRecord);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// CR(U)D - Updates an existing record in the DB
        /// </summary>
        /// <param name="vegetableRecord">The record to update in the DB</param>
        /// <returns>Boolean representing the sucess of the operation</returns>
        /// <author>Jacob Paulin</author>
        public async Task<bool> UpdateVegetableRecord(VegetableRecord vegetableRecord)
        {
            CleanString(vegetableRecord.RefDate, true);
            CleanString(vegetableRecord.Geo, true);
            CleanString(vegetableRecord.DGUID, true);
            CleanString(vegetableRecord.TypeOfProduct, true);
            CleanString(vegetableRecord.TypeOfStorage, true);
            CleanString(vegetableRecord.UOM, true);
            ValidateInt(vegetableRecord.UOMID, true);
            CleanString(vegetableRecord.ScalarFactor, true);
            ValidateInt(vegetableRecord.ScalarId, true);
            CleanString(vegetableRecord.Vector, true);
            CleanString(vegetableRecord.Coordinate, true);
            ValidateInt(vegetableRecord.Value, true);
            CleanString(vegetableRecord.Status, true);
            CleanString(vegetableRecord.Symbol, true);
            CleanString(vegetableRecord.Terminated, true);
            ValidateInt(vegetableRecord.Decimals, true);

            try
            {
                await dao.UpdateAsync(vegetableRecord);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// CRU(D) - Deletes a record from the DB
        /// </summary>
        /// <param name="vegetableRecord">The record to delete from the DB</param>
        /// <returns>Boolean representing the sucess of the operation</returns>
        /// <author>Jacob Paulin</author>
        public async Task<bool> DeleteVegetableRecord(VegetableRecord vegetableRecord)
        {
            ValidateInt(vegetableRecord.Id, false);
            try
            {
                await dao.DeleteAsync(vegetableRecord);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// C(R)UD - Reads all records from the DB
        /// </summary>
        /// <returns>A list of records in the DB</returns>
        /// <author>Jacob Paulin</author>
        public async Task<List<VegetableRecord>> ReadAllVegetableRecord()
        {
            return (await dao.ReadAllAsync()).ToList();
        }

        /// <summary>
        /// C(R)UD - Reads a specific record from the DB
        /// </summary>
        /// <returns>The record from the DB with the specified ID</returns>
        /// <author>Jacob Paulin</author>
        public async Task<VegetableRecord> ReadByIdVegetableRecord(int id)
        {
            return await dao.ReadByIdAsync(id);
        }

        /// <summary>
        /// Cleans a provided string to trim it and validate it
        /// </summary>
        /// <param name="str">The string to clean</param>
        /// <param name="canBeNull">Can the stirng be empty or null?</param>
        /// <returns>The cleaned string</returns>
        /// <author>Jacob Paulin</author>
        private static string? CleanString(string? str, bool canBeNull)
        {
            if (!canBeNull && string.IsNullOrEmpty(str))
            {
                throw new Exception("String is null or empty");
            }

            return str == null ? str : str.Trim();
        }

        /// <summary>
        /// Validates a integer
        /// </summary>
        /// <param name="value">The int to validate</param>
        /// <param name="canBeNegative">Can the int be negative or null?</param>
        /// <returns>The validated int or null if invalid</returns>
        /// <author>Jacob Paulin</author>
        private static int? ValidateInt(int? value, bool canBeNegative)
        {
            if (!canBeNegative && value < 0)
            {
                throw new Exception("Integer cannot be negative");
            }

            if (!canBeNegative && value == null)
            {
                throw new Exception("Integer cannot be null");
            }

            return value;
        }
    }
}
