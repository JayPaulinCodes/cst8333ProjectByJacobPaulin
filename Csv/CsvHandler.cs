using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cst8333ProjectByJacobPaulin.Models;
using System.Collections;
using System.Reflection;

namespace cst8333ProjectByJacobPaulin.Csv
{
    internal class CsvHandler
    {
        #region Variables
        public string FilePath { get; set; }
        public CsvConfiguration? Config { get; set; }

        public Type RecordType { get; set; }
        public Type RecordMapType { get; set; }

        public IList? Contents { get; set; }
        #endregion

        #region Constructors
        private CsvHandler(string filePath, CsvConfiguration? csvConfig)
        {
            FilePath = filePath;
            Config = csvConfig;

            RefreshContent();
        }

        private CsvHandler(string filePath) : this(filePath, null) { }
        #endregion

        public void RefreshContent() 
        {
            Contents = (IList?)GetType()
                .GetMethod("ReadCsv", BindingFlags.Public | BindingFlags.Instance)
                .MakeGenericMethod(RecordType, RecordMapType)
                .Invoke(this, new object[] { FilePath, Config });
        }

        #region Static Methods
        public static object Create<Record, RecordMap>(string filePath, CsvConfiguration? csvConfig)
            where Record : class
            where RecordMap : ClassMap
        {

            return new CsvHandler(filePath, csvConfig)
            {
                RecordType = typeof(Record),
                RecordMapType = typeof(RecordMap)
            };
        }

        public static object Create<Record, RecordMap>(string filePath)
            where Record : class
            where RecordMap : ClassMap
        {

            return new CsvHandler(filePath)
            {
                RecordType = typeof(Record),
                RecordMapType = typeof(RecordMap)
            };
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
        public static List<T>? ReadCsv<T, TClass>(string filePath, IReaderConfiguration? config = null)
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

                Console.WriteLine($"[Written by Jacob Paulin] Attempting to open and read from file at path \"{filePath}\"");
                // Utilizing the using statement to automatically dispose once done, even on the occurrence of an exception
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, cultureConfig))
                {
                    Console.WriteLine($"[Written by Jacob Paulin] Registering the class map of \"{typeof(TClass).Name}\" for the csv helper");
                    csv.Context.RegisterClassMap<TClass>();
                    Console.WriteLine($"[Written by Jacob Paulin] Retrieving records from the csv helper as class \"{typeof(T).Name}\"");
                    var records = csv.GetRecords<RecordType>();
                    Console.WriteLine($"[Written by Jacob Paulin] Converting the IEnumerable<{typeof(T).Name}> object to a List<{typeof(T).Name}> object");
                    return records.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in the ReadCsv method: \"{ex.Message}\"");
                return null;
            }
        }
        #endregion

    }
}
