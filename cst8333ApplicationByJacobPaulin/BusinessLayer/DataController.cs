/* 
 * Author: Jacob Paulin
 * Date: Jun 1, 2023
 * Modified: Jun 13, 2023
 * Description: A business layer class to interact 
 * with the CSV data and CSV handler
 */

using cst8333ApplicationByJacobPaulin.BusinessLayer.Models;
using cst8333ApplicationByJacobPaulin.PersistenceLayer;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace cst8333ApplicationByJacobPaulin.BusinessLayer
{
    /// <summary>
    /// Business class to provide CRUD operations
    /// for the CSV dataset.
    /// </summary>
    /// <author>Jacob Paulin</author>
    public class DataController
    {
        /// <summary>
        /// Instance of the persistence layer used to access the CSV data
        /// </summary>
        /// <author>Jacob Paulin</author>
        private static CsvHandler CSV = new CsvHandler("./Csv/Dataset/32100260.csv", new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",",
            Comment = '#',
            HasHeaderRecord = true,
            NewLine = Environment.NewLine
        });

        /// <summary>
        /// The path of the file that is currently being read
        /// </summary>
        /// <author>Jacob Paulin</author>
        public string FilePath
        {
            get
            {
                return CSV.FilePath;
            }

            set
            {
                Log($"Changing CSV file path from \"{CSV.FilePath}\" to \"{value}\"");
                CSV.FilePath = value;
            }
        }

        #region Methods
        /// <summary>
        /// Simplyfied log method to add consistient formatting for all logs
        /// </summary>
        /// <param name="msg">The message to log</param>
        /// <author>Jacob Paulin</author>
        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] DataController.cs: {msg}");

        /// <summary>
        /// Creates the provided record in the CSV file and saves it
        /// </summary>
        /// <param name="record"></param>
        /// <returns>Returns a boolean indicating if the action succeeded</returns>
        /// <author>Jacob Paulin</author>
        public bool CreateRecord(VegetableRecord record)
        {
            Log($"(ReadRecords) Trying to create record");

            if (CSV.Contents == null)
            {
                Log($"(ReadRecords) Contents doesn't exist");
                return false;
            }

            CSV.Contents.AddLast(record);

            Log($"(ReadRecords) Trying to save contents");
            bool operation = CSV.WriteContents(CSV.FilePath);
            if (operation)
            {
                Log($"(ReadRecords) Save operaton succeeded");
            }
            else
            {
                Log($"(ReadRecords) Save operaton failed");
            }

            return operation;
        }

        /// <summary>
        /// Operation to retreive all the records from the CSV file
        /// </summary>
        /// <returns>Returns a linked list of all the CSV records</returns>
        /// <author>Jacob Paulin</author>
        public LinkedList<VegetableRecord>? ReadRecords()
        {
            Log($"(ReadRecords) Trying to read contents of  \"{FilePath}\"");
            CSV.RefreshContent();
            if (CSV.Contents != null)
            {
                Log($"(ReadRecords) Read operaton succeeded");
            }
            else
            {
                Log($"(ReadRecords) Read operaton failed");
            }
            return CSV.Contents;
        }

        /// <summary>
        /// Retrieves record at specific index in the linked list of all records
        /// </summary>
        /// <param name="index">The index to retrieve a record from</param>
        /// <returns>The record at the provided index or null if none are found</returns>
        /// <author>Jacob Paulin</author>
        public VegetableRecord? ReadRecordAtIndex(int index)
        {
            Log($"(ReadRecordAtIndex) Trying to read index {index} of \"{FilePath}\"");
            CSV.RefreshContent();
            if (CSV.Contents != null)
            {
                try
                {
                    VegetableRecord record = CSV.Contents.ElementAt(index);
                    Log($"(ReadRecordAtIndex) Read operaton succeeded");
                    return record;
                }
                catch (Exception e)
                {
                    Log($"(ReadRecordAtIndex) Read operaton failed");
                    Debug.WriteLine(e.StackTrace);
                    return null;
                }
            }
            else
            {
                Log($"(ReadRecordAtIndex) Read operaton failed");
                return null;
            }
        }

        /// <summary>
        /// Replaces a specific record in the CSV file
        /// </summary>
        /// <param name="oldRecord">The old record to replace</param>
        /// <param name="newRecord">The new record to replace the old</param>
        /// <returns>Boolean representing if the operation succeeded</returns>
        /// <author>Jacob Paulin</author>
        public bool UpdateRecord(VegetableRecord oldRecord, VegetableRecord newRecord)
        {
            Log($"(UpdateRecord) Trying to update record");
            CSV.Contents.Find(oldRecord).Value = newRecord;
            Log($"(UpdateRecord) Trying to save contents");
            bool operation = CSV.WriteContents(CSV.FilePath);
            if (operation)
            {
                Log($"(UpdateRecord) Save operaton succeeded");
            }
            else
            {
                Log($"(UpdateRecord) Save operaton failed");
            }
            return operation;
        }

        /// <summary>
        /// Removes a record from the CSV file
        /// </summary>
        /// <param name="record">The record to remove</param>
        /// <returns>Boolean representing if the operation succeeded</returns>
        /// <author>Jacob Paulin</author>
        public bool DeleteRecord(VegetableRecord record)
        {
            Log($"(DeleteRecord) Trying to delete record");
            CSV.Contents.Remove(record);
            Log($"(DeleteRecord) Trying to save contents");
            bool operation = CSV.WriteContents(CSV.FilePath);
            if (operation)
            {
                Log($"(DeleteRecord) Save operaton succeeded");
            }
            else
            {
                Log($"(DeleteRecord) Save operaton failed");
            }
            return operation;
        }

        /// <summary>
        /// Save the current contents of the list in memory to a specified file
        /// </summary>
        /// <param name="filePath">The name of the file to save to</param>
        /// <returns>Boolean representing if the operation succeeded</returns>
        /// <author>Jacob Paulin</author>
        public bool SaveToCsv(string filePath)
        {
            Log($"(SaveToCsv) Trying to save contents to file \"{filePath}\"");
            CSV.RefreshContent();
            bool operation = CSV.WriteContents(filePath);
            if (operation)
            {
                Log($"(SaveToCsv) Save operaton succeeded");
            }
            else
            {
                Log($"(SaveToCsv) Save operaton failed");
            }
            return operation;
        }
        #endregion
    }
}
