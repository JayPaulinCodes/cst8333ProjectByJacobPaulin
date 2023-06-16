/* 
 * Author: Jacob Paulin
 * Date: Jun 1, 2023
 * Modified: Jun 13, 2023
 * Description: WPF Project to provide CRUD operations 
 * for CSV files
 * 
 * CsvHelper version 30.0.1 downloaded with NuGet Package Manager from:
 * https://www.nuget.org/packages/CsvHelper#readme-body-tab
 * 
 * This program was created with help from CsvHelper documents:
 * https://joshclose.github.io/CsvHelper/
 * https://joshclose.github.io/CsvHelper/examples/
 */

using cst8333ApplicationByJacobPaulin.BusinessLayer.Models;
using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace cst8333ApplicationByJacobPaulin.PersistenceLayer
{
    /// <summary>
    /// Class which uses CsvHelper to interact with a CSV file
    /// </summary>
    /// <author>Jacob Paulin</author>
    public class CsvHandler
    {
        #region Variables
        public string FilePath { get; set; }
        public CsvConfiguration? Config { get; set; }
        public LinkedList<VegetableRecord>? Contents { get; set; }
        #endregion

        /// <summary>
        /// Constructor to initialize the CsvHandler taking
        /// the file path, and optionally the CSV config
        /// </summary>
        /// <param name="filePath">Path to the CSV file</param>
        /// <param name="csvConfig">Config object </param>
        /// <author>Jacob Paulin</author>
        public CsvHandler(string filePath, CsvConfiguration? csvConfig)
        {
            FilePath = filePath;
            Config = csvConfig;

            RefreshContent();
        }

        #region Methods
        /// <summary>
        /// Refreshes the content list with the current CSV path
        /// </summary>
        /// <author>Jacob Paulin</author>
        public void RefreshContent()
        {
            Log("Refreshing content");
            Contents = ReadCsv<VegetableRecord, VegetableRecordMap>(FilePath, Config);
        }

        /// <summary>
        /// Writes the current CSV handler's contents to the specified path
        /// </summary>
        /// <param name="filePath">The path to the csv file</param>
        /// <param name="config">Optional parameter for reader configuration</param>
        /// <returns>Boolean indicating success or failure of the operation</returns>
        /// <author>Jacob Paulin</author>
        public bool WriteContents(string filePath, IReaderConfiguration? config = null)
        {
            Log($"Trying to write content to file {filePath}");
            if (Contents == null)
            {
                Log($"Content was null, failed to write");
                return false;
            }
            return WriteCsv<VegetableRecord>(filePath, Contents, config);
        }

        /// <summary>
        /// Writes a provided list of records to a specified CSV file
        /// </summary>
        /// <typeparam name="T">The type of the enumerable object</typeparam>
        /// <param name="filePath">The path to the csv file</param>
        /// <param name="data">The list of records to write</param>
        /// <param name="config">Optional parameter for reader configuration</param>
        /// <returns>Boolean indicating success or failure of the operation</returns>
        /// <author>Jacob Paulin</author>
        public static bool WriteCsv<T>(string filePath, LinkedList<T> data, IReaderConfiguration? config = null)
            where T : class
        {
            // Validate the filePath variable
            if (string.IsNullOrWhiteSpace(filePath)) { return false; }

            // Using a try/catch block to handle any errors
            try
            {
                // If the parameter config is supplied use it, otherwise use pre-defined defaults
                // Using the dynamic keyword because the type will either be CultureInfo or ReaderConfiguration
                dynamic cultureConfig = config == null ? CultureInfo.InvariantCulture : config;

                Log($"Attempting to open and write to file at path \"{filePath}\"");
                // Utilizing the using statement to automatically dispose once done, even on the occurrence of an exception
                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, cultureConfig))
                {
                    Log($"Writing header for class \"{typeof(T).Name}\"");
                    csv.WriteHeader<T>();
                    csv.NextRecord();

                    int currentIndex = 0;
                    for (LinkedListNode<T> node = data.First; node != null; node = node.Next)
                    {
                        Log($"Writing entry #{currentIndex + 1} of data list");
                        csv.WriteRecord(node.Value);
                        csv.NextRecord();
                        currentIndex++;
                    }

                    Log($"Finised writing data list to file \"{filePath}\"");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log($"An error occurred in the WriteCsv method: \"{ex.Message}\"");
                return false;
            }
        }

        /// <summary>
        /// Reads a CSV file at a specified path and converts it to a list for the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the enumerable object</typeparam>
        /// <typeparam name="TClass">The ClassMap for the CSV reader</typeparam>
        /// <param name="filePath">The path to the csv file</param>
        /// <param name="config">Optional parameter for reader configuration</param>
        /// <returns>Returns null if an error occurs, otherwise returns a LinkedList of type T</returns>
        /// <author>Jacob Paulin</author>
        public LinkedList<T>? ReadCsv<T, TClass>(string filePath, IReaderConfiguration? config = null)
            // Using generic type parameters we can allow this method to be dynamic to the user's need
            // (I feel like this may useful for future projects)
            // https://learn.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2013/512aeb7t(v=vs.120)?redirectedfrom=MSDN
            where T : class
            where TClass : ClassMap
        {
            // Validate the filePath variable
            if (string.IsNullOrWhiteSpace(filePath)) { return null; }

            // Using a try/catch block to handle any errors
            try
            {
                // If the parameter config is supplied use it, otherwise use pre-defined defaults
                // Using the dynamic keyword because the type will either be CultureInfo or ReaderConfiguration
                dynamic cultureConfig = config == null ? CultureInfo.InvariantCulture : config;

                Log($"Attempting to open and read from file at path \"{filePath}\"");
                // Utilizing the using statement to automatically dispose once done, even on the occurrence of an exception
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, cultureConfig))
                {
                    Log($"Registering the class map of \"{typeof(TClass).Name}\" for the csv helper");
                    csv.Context.RegisterClassMap<TClass>();
                    Log($"Retrieving records from the csv helper as class \"{typeof(T).Name}\"");
                    var records = csv.GetRecords<T>();
                    Log($"Converting the IEnumerable<{typeof(T).Name}> object to a LinkedList<{typeof(T).Name}> object");
                    return new LinkedList<T>(records);
                }
            }
            catch (Exception ex)
            {
                Log($"An error occurred in the ReadCsv method: \"{ex.Message}\"");
                return null;
            }
        }

        /// <summary>
        /// Simplyfied log method to add consistient formatting for all logs
        /// </summary>
        /// <param name="msg">The message to log</param>
        /// <author>Jacob Paulin</author>
        private static void Log(string msg) => Debug.WriteLine($"[Written By Jacob Paulin] CsvHandler.cs: {msg}");
        #endregion
    }
}
