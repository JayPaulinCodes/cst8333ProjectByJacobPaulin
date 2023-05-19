/* Author: Jacob Paulin
 * Date: May 17, 2023
 * Modified: May 19, 2023
 * Description: Simple program that reads entries in a csv file and creates a list
 * of objects from that data, then prints it to the console.
 * 
 * CsvHelper version 30.0.1 downloaded with NuGet Package Manager from:
 * https://www.nuget.org/packages/CsvHelper#readme-body-tab
 * 
 * This program was created with help from CsvHelper documents:
 * https://joshclose.github.io/CsvHelper/
 * https://joshclose.github.io/CsvHelper/examples/
 */

using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace cst8333ProjectByJacobPaulin
{
    internal class Program
    {
        // Define some constants
        internal const string CSV_FILE_PATH = "Dataset/32100260.csv";
        internal static readonly CsvConfiguration CSV_CONFIGURATION = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",",
            Comment = '#',
            HasHeaderRecord = true
        };

        /// <summary>
        /// Main method called when the program runs
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <author>Jacob Paulin</author>
        static void Main(string[] args)
        {
            // Call the ReadCsv method with our constants
            List<VegetableRecord>? records = ReadCsv<VegetableRecord, VegetableRecordMap>(CSV_FILE_PATH, CSV_CONFIGURATION);

            // Check the output for null
            if (records == null) { return; }

            // Loop through the returned list and print outputs
            foreach (VegetableRecord record in records)
            {
                int recordCount = records.IndexOf(record) + 1;
                // Stop after the first 200 records for poc
                if (recordCount > 200) { break; }
                Console.WriteLine($"[Written by Jacob Paulin] Record #{recordCount} = {record.ToPrettyString()}\n");
            }
        }

        /// <summary>
        /// Reads a CSV file at a specified path and converts it to a list for the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the enumerable object</typeparam>
        /// <typeparam name="TClass">The ClassMap for the CSV reader</typeparam>
        /// <param name="filePath">The path to the csv file</param>
        /// <param name="config">Optional parameter for reader configuration</param>
        /// <returns>Returns null if an error occurs, otherwise returns a List of type T</returns>
        /// <author>Jacob Paulin</author>
        static List<T>? ReadCsv<T, TClass>(string filePath, IReaderConfiguration? config = null)
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
                dynamic cultureConfig = (config == null) ? CultureInfo.InvariantCulture : config;

                Console.WriteLine($"Attempting to open and read from file at path \"{filePath}\"");
                // Utilizing the using statement to automatically dispose once done, even on the occurance of an exception
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, cultureConfig))
                {
                    csv.Context.RegisterClassMap<TClass>();
                    var records = csv.GetRecords<T>();
                    return records.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in the ReadCsv method: \"{ex.Message}\"");
                return null;
            }
        }
    }
}